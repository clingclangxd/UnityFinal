using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public int myMoney;
    public List<GameObject> allÇips;

    public int betCount;
    public TMPro.TextMeshProUGUI betText;
    public TMPro.TextMeshProUGUI myMoneyText;

    public GameObject mainCanvas;
    public GameObject gameCanvas;
    public GameObject BetButton;

    private void Start()
    {
        if (PlayerPrefs.GetInt("First") == 0)
        {
            PlayerPrefs.SetInt("Money", 1000);
            PlayerPrefs.SetInt("First", 1);
        }
        myMoney = PlayerPrefs.GetInt("Money");
        gameCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
    public void ChipButton(int value)
    {
        SetBet(value);
    }
    private void Update()
    {
        myMoneyText.text = myMoney.ToString() + "$";
        betText.text = betCount.ToString() + "$";
        var m = myMoney;
        if (m > 0)
        {
            allÇips[0].SetActive(true);
            if (m >= 5)
            {
                allÇips[1].SetActive(true);
            }
            else
            {
                allÇips[1].SetActive(false);
            }

            if (m >= 10)
            {
                allÇips[2].SetActive(true);
            }
            else
            {
                allÇips[2].SetActive(false);
            }

            if (m >= 50)
            {
                allÇips[3].SetActive(true);
            }
            else
            {
                allÇips[3].SetActive(false);
            }

            if (m >= 100)
            {
                allÇips[4].SetActive(true);
            }
            else
            {
                allÇips[4].SetActive(false);
            }

            if (m >= 500)
            {
                allÇips[5].SetActive(true);
            }
            else
            {
                allÇips[5].SetActive(false);
            }
        }
        else if (m <= 0)
        {
            for (int i = 0; i < allÇips.Count; i++)
            {
                allÇips[i].SetActive(false);
            }
        }

        if(betCount >= 15 && betCount <= 1000)
        {
            BetButton.SetActive(true);
        }
        else
        {
            BetButton.SetActive(false);
        }
    }
    public void reloadBuck()
    {
        myMoney = 1000;
        PlayerPrefs.SetInt("Money", 1000);
        myMoney = 1000;
        betCount = 0;
    }
    public void SetBet(int bet)
    {
        betCount += bet;
        myMoney -= bet;
        PlayerPrefs.SetInt("Money", myMoney);

    }
    public void ApplyBetButton()
    {
        gameCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        var gameManager = FindObjectOfType<GameManager>();
        var coroutine = gameManager.GetComponent<GameManager>();
        StartCoroutine(coroutine.StartBlackjack(betCount));
    }
}
