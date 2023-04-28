using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinishElements : MonoBehaviour
{
    [SerializeField]
    public TMP_Text Txt_Prize;
    [SerializeField]
    public TMP_Text Txt_SumPrize;
    [SerializeField]
    public TMP_Text Txt_FinishPlace;
    [SerializeField]
    public TMP_Text Txt_FinishTime;
    [SerializeField]
    public Button raceButton;

    public void SetActivityUI(bool active)
    {
        raceButton.gameObject.SetActive(active);
        Txt_Prize.gameObject.SetActive(active);
        Txt_SumPrize.gameObject.SetActive(active);
        Txt_FinishPlace.gameObject.SetActive(active);
        Txt_FinishTime.gameObject.SetActive(active);
    }

}
