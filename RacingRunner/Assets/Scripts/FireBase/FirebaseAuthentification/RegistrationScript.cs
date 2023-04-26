using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using TMPro; 
using UnityEngine.UI;
using Firebase.Database;
using UnityEngine.SceneManagement;

public class RegistrationScript : MonoBehaviour
{
    DatabaseReference dbRef;

    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    private const string LOG_IN_MENU_SCENE = "LogInMenu";
    private const string GAME_PLAY_SCENE = "MenuScene";

    [SerializeField]
    private TMP_InputField emailField;
    [SerializeField]
    private TMP_InputField nicknameField;
    [SerializeField]
    private TMP_InputField passwordField;
    [SerializeField]
    private TMP_InputField repeatPasswordField;

    [SerializeField] 
    private TMP_Text errorField;

    //[SerializeField]
    //PlayerDataSO playerData;

    private void Awake()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

        

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Error:" + dependencyStatus);
            }

        });
    }

    private void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;

    }

    public void RegisterButton()
    {
        StartCoroutine(Register(emailField.text, passwordField.text, nicknameField.text));
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {

        

        if(_username == "")
        {
            errorField.text = "Missing name";
        }
        else if(passwordField.text != repeatPasswordField.text)
        {
            errorField.text = "Passwords does not match";
        }
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);

            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            Debug.Log(RegisterTask.Result.Email);

            if (RegisterTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with{RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;

                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register failed";


                errorField.text = message;
            }
            else
            {
                user = RegisterTask.Result;


                if(user !=null)
                {
                    UserProfile profile = new UserProfile { DisplayName = _username};

                    var profileTask = user.UpdateUserProfileAsync(profile);

                    yield return new WaitUntil(predicate: () => profileTask.IsCompleted);


                    if (profileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task with{profileTask.Exception}");
                        FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;

                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                        errorField.text = "_username set failed";
                    }
                    else
                    {
                        //DataHolder.id = user.UserId;
                        //DataHolder.name = user.DisplayName;
                        DataHolder.firebaseUser = user;

                        SaveData();

                        //SceneManager.LoadScene(GAME_PLAY_SCENE);


                    }

                }
            }
        }
        
    }

    private void SaveData()
    {
        UserData userData = new UserData(user.UserId, nicknameField.text, 0, 0,-1);

        string json = JsonUtility.ToJson(userData);
        Debug.Log("work");
        dbRef.Child("users").Child(user.UserId).SetRawJsonValueAsync(json);
    }

    public void GoToLogInMenu()
    {
        SceneManager.LoadScene(LOG_IN_MENU_SCENE);
    }
}
