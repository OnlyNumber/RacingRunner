using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;

public class FirebaseDatabaseControllerMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinsText;

    [SerializeField]
    private GameObject leaderBoardGrid;

    private DatabaseReference dbRef;

    [SerializeField]
    private AvatarController avatarController;

    [SerializeField]
    private LeaderBoardItem _leaderBoardItem;

    public UserData userDataTransfer { private set; get; }

    private void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

        //Debug.Log(DataHolder.firebaseUser.UserId.ToString());

        StartCoroutine(LoadData(DataHolder.firebaseUser.UserId.ToString()));

        StartCoroutine(LoadAllUserByScore());
    }

    private IEnumerator LoadAllUserByScore()
    {
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

            List<DataSnapshot> reverseList = new List<DataSnapshot>();


            foreach (DataSnapshot clidSnapshot in snapshot.Children)
            {
                Debug.Log("clidSnapshot");
                reverseList.Add(clidSnapshot);
            }

            reverseList.Reverse();

            LeaderBoardItem leaderBoardItemtransfer;

            foreach (var item in reverseList)
            {
                leaderBoardItemtransfer = Instantiate(_leaderBoardItem);//.GetComponent<LeaderBoardItem>();

                leaderBoardItemtransfer.transform.SetParent(leaderBoardGrid.transform);

                leaderBoardItemtransfer.nameItem.text = item.Child("nickName").Value.ToString();
                leaderBoardItemtransfer.timeItem.text = item.Child("bestTime").Value.ToString();
            }

            /*for (int i = 0; i < 10; i++)
            {
                if (reverseList.Count > i)
                {
                    leaderBoardFields[i].text = reverseList[i].Child("name").Value.ToString() + ":  " + reverseList[i].Child("score").Value.ToString();
                }
                else
                {
                    leaderBoardFields[i].text = "";
                }
            }*/

            //loadingScreen.GetComponent<HidingPanel>().Fading();

        }


    }

    private IEnumerator LoadData(string userID)
    {
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

            coinsText.text = "Coins: " + userDataTransfer.goldCoins.ToString();

            avatarController.SetAvatarStart(userDataTransfer.avatarIcon);
            //nameText.text = userDataTransfer.name; 

            //scoreText.text = userDataTransfer.score.ToString();
        }
    }

    public void ChangeCurrentUser(string id, string nickName, int goldCoins, int avatarIcon, float bestTime, int car)
    {
        userDataTransfer = new UserData(id, nickName, goldCoins, avatarIcon, bestTime, car);


    }

    public void SaveData(string id, string nickName, int goldCoins, int avatarIcon, float bestTime, int car)
    {
        UserData user2229 = new UserData( id,  nickName,  goldCoins,avatarIcon,  bestTime,  car);

        string json = JsonUtility.ToJson(user2229);

        dbRef.Child("users").Child(id).SetRawJsonValueAsync(json);

    }

}
