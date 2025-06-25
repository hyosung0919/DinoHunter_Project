using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI goldText;

    public int healthCost = 20;
    public int speedCost = 30;
    public int healthUpgradeCost = 20;
    public int speedUpgradeCost = 30;
    public TextMeshProUGUI warningText;

    void Start()
    {
        UpdateUI();
    }

    public void OnUpgradeHealth()
    {
        var data = GameDataManager.Instance.data;

        if (data.gold >= healthCost)
        {
            data.gold -= healthCost;
            data.extraHealthLevel++;
            GameDataManager.Instance.Save();
        }
        else
        {
            ShowWarning("골드가 부족합니다!");
        }

        UpdateUI();
    }

    public void OnUpgradeSpeed()
    {
        var data = GameDataManager.Instance.data;

        if (data.gold >= speedCost)
        {
            data.gold -= speedCost;
            data.moveSpeedLevel++;
            GameDataManager.Instance.Save();
        }
        else
        {
            ShowWarning("골드가 부족합니다!");
        }

        UpdateUI();
    }

    public void OnReset()
    {
        var data = GameDataManager.Instance.data;

        int refund = (data.extraHealthLevel * healthUpgradeCost) +
                     (data.moveSpeedLevel * speedUpgradeCost);

        data.gold += refund;

        data.extraHealthLevel = 0;
        data.moveSpeedLevel = 0;

        GameDataManager.Instance.Save();
        UpdateUI();
    }

    void UpdateUI()
    {
        var data = GameDataManager.Instance.data;
        healthText.text = $"체력 Lv. {data.extraHealthLevel}";
        speedText.text = $"속도 Lv. {data.moveSpeedLevel}";
        goldText.text = $"보유 골드: {data.gold}G";
    }
    void ShowWarning(string message)
    {
        StopAllCoroutines(); // 중복 방지
        StartCoroutine(ShowWarningRoutine(message));
    }

    IEnumerator ShowWarningRoutine(string message)
    {
        warningText.text = message;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningText.gameObject.SetActive(false);
    }

}
