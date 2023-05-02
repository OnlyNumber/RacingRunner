using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    [SerializeField]
    private GameObject leaderBoardGrid;

    [SerializeField]
    private LeaderBoardItem _leaderBoardItem;

    [SerializeField]
    private FirebaseDatabaseController _firebase;

    private void Start()
    {
        _firebase.onDataLoadedScore += InitializeLeaderBoard;
    }

    private void InitializeLeaderBoard()
    {
        float timer;

        LeaderBoardItem leaderBoardItemtransfer;

        foreach (var item in _firebase.reverseList)
        {
            timer = float.Parse(item.Child("bestTime").Value.ToString());

            leaderBoardItemtransfer = Instantiate(_leaderBoardItem);

            leaderBoardItemtransfer.transform.SetParent(leaderBoardGrid.transform);

            leaderBoardItemtransfer.nameItem.text = item.Child("nickName").Value.ToString();

            if (timer % 60 > 10)
            {
                leaderBoardItemtransfer.timeItem.text = $" {(int)(timer / 60)} : {(int)(timer % 60)}";
            }
            else
            {
                leaderBoardItemtransfer.timeItem.text = $" {(int)(timer / 60)} : 0{(int)(timer % 60)}";
            }

            //leaderBoardItemtransfer.timeItem.text = item.Child("bestTime").Value.ToString();
        }
    }
}
