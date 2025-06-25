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
            ShowWarning("��尡 �����մϴ�!");
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
            ShowWarning("��尡 �����մϴ�!");
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
        healthText.text = $"ü�� Lv. {data.extraHealthLevel}";
        speedText.text = $"�ӵ� Lv. {data.moveSpeedLevel}";
        goldText.text = $"���� ���: {data.gold}G";
    }
    void ShowWarning(string message)
    {
        StopAllCoroutines(); // �ߺ� ����
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
