using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;
using System;

public class FirebaseDatabaseController : MonoBehaviour
{
    //Firebase
    private DatabaseReference dbRef;

    public List<DataSnapshot> reverseList { private set; get; }

    public UserData userDataTransfer { private set; get; }
    
    ////////////////////////////// isDataLoadedPlayer
    public event Action onDataLoadedPlayer;

    private bool isDataLoadedPlayer;

    public bool IsDataLoadedPlayer
    {
        get
        {
            return isDataLoadedPlayer;
        }

        private set
        {
            isDataLoadedPlayer = value;

            if (isDataLoadedPlayer)
            {
                onDataLoadedPlayer?.Invoke();
            }


        }

    }

    ////////////////////////////// isDataLoadedScore
    public event Action onDataLoadedScore;

    private bool isDataLoadedScore;
    public bool IsDataLoadedScore
    {
        get
        {
            return isDataLoadedScore;
        }

        private set
        {
            isDataLoadedScore = value;

            if (isDataLoadedScore)
            {
                onDataLoadedScore?.Invoke();
            }
        }

    }


    private void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

        StartCoroutine(LoadData(DataHolder.firebaseUser.UserId.ToString()));

        StartCoroutine(LoadAllUserByScore());
    }

    private IEnumerator LoadAllUserByScore()
    {
        IsDataLoadedScore = false;

        reverseList = new List<DataSnapshot>();

        Debug.Log("LoadAllUserByScore");

        var user = dbRef.Child("users").OrderByChild("bestTime").GetValueAsync();

        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogError(user.Exception);
        }
        else if (user.Result.Value == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;

            foreach (DataSnapshot clidSnapshot in snapshot.Children)
            {
                Debug.Log("clidSnapshot");
                reverseList.Add(clidSnapshot);
            }

            reverseList.Reverse();

            IsDataLoadedScore = true;
        }
    }

    private IEnumerator LoadData(string userID)
    {
        IsDataLoadedPlayer = false;

        var user = dbRef.Child("users").Child(userID).GetValueAsync();

        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.Log("you");
            Debug.Log(user.Exception);
        }
        else if (user.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;

            userDataTransfer = new UserData(snapshot.Child("id").Value.ToString(),
                snapshot.Child("nickName").Value.ToString(),
                int.Parse(snapshot.Child("goldCoins").Value.ToString()),
                int.Parse(snapshot.Child("avatarIcon").Value.ToString()),
                int.Parse(snapshot.Child("bestTime").Value.ToString()),
                int.Parse(snapshot.Child("car").Value.ToString())
                );

            IsDataLoadedPlayer = true;


        }
    }

    public void ChangeCurrentUser(string id, string nickName, int goldCoins, int avatarIcon, float bestTime, int car)
    {
        userDataTransfer = new UserData(id, nickName, goldCoins, avatarIcon, bestTime, car);

        SaveData(id, nickName, goldCoins, avatarIcon, bestTime, car);

    }

    public void SaveData(string id, string nickName, int goldCoins, int avatarIcon, float bestTime, int car)
    {
        UserData user2229 = new UserData( id,  nickName,  goldCoins,avatarIcon,  bestTime,  car);

        string json = JsonUtility.ToJson(user2229);

        dbRef.Child("users").Child(id).SetRawJsonValueAsync(json);

    }

}
