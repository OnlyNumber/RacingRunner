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
        LeaderBoardItem leaderBoardItemtransfer;

        foreach (var item in _firebase.reverseList)
        {
            leaderBoardItemtransfer = Instantiate(_leaderBoardItem);

            leaderBoardItemtransfer.transform.SetParent(leaderBoardGrid.transform);

            leaderBoardItemtransfer.nameItem.text = item.Child("nickName").Value.ToString();
            leaderBoardItemtransfer.timeItem.text = item.Child("bestTime").Value.ToString();
        }
    }
}
