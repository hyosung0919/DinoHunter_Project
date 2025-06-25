using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    void Start()
    {
        UpdateGoldText();
    }

    public void UpdateGoldText()
    {
        if (goldText != null)
        {
            int gold = GameDataManager.Instance.data.gold;
            goldText.text = $"ÇöÀç°ñµå: {gold}G";
        }
    }
}
