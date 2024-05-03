using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject creator;
    public List<Transform> ProcessorPoints;
    public List<Transform> YouPoints;
    public GameObject çipPrefab;
    public TMPro.TextMeshProUGUI myCardTotalCountText;
    public TMPro.TextMeshProUGUI processorCardTotalCountText;

    public int myCardTotalCount;
    public int processorCardTotalCount;
    public int processorPrivTotalCount;
    public int orders;

    public GameObject mainpanel, menuPanel;
    public GameObject mainPanelChild, crushpanelChild, winPanelChild;
    public TMPro.TextMeshProUGUI winMoneyText;
    public GameObject FunctionButtons;
    
    private void Start()
    {
        FunctionButtons.SetActive(false);
        processorCardTotalCountText.text = 0.ToString();

        mainPanelChild.SetActive(true);
        crushpanelChild.SetActive(false);
        winPanelChild.SetActive(false);
    }
    private void FixedUpdate()
    {
        myCardTotalCountText.text = myCardTotalCount.ToString();
        
    }
    public void GetNewCardProp(int count)
    {
        myCardTotalCount += count;
    }
    public IEnumerator StartBlackjack(int betcount)
    {
        var BahisÇipi = GameObject.Instantiate(çipPrefab, Vector3.zero, Quaternion.identity);
        BahisÇipi.transform.position = new Vector3(-2, -6, 0);
        BahisÇipi.GetComponent<Chip>().chipValue = betcount;
        StartCoroutine(BahisÇipi.GetComponent<Chip>().moveChip(new Vector3(-2, -3.5f, 0)));
        for (int i = 5; i > 3; i--)
        {
            if (i == 4)
            {
                var NewCard = Instantiate(CardPrefab, creator.transform.position, Quaternion.identity);
                NewCard.GetComponent<CardMovement>().Who = CardMovement.who.processor;  
                StartCoroutine(NewCard.GetComponent<CardMovement>().move(ProcessorPoints[i].position, true, Quaternion.Euler(ProcessorPoints[i].rotation.x, -90, ProcessorPoints[i].rotation.z)));
                orders++;
            }
            else
            {
                var NewCard = Instantiate(CardPrefab, creator.transform.position, Quaternion.identity);
                NewCard.GetComponent<CardMovement>().Who = CardMovement.who.processor;
                var value = NewCard.GetComponent<CardMovement>().value;
                int newValue = 0;
                if (value != "Q" && value != "K" && value != "J" && value != "A")
                {
                    int.TryParse(value, out newValue);
                    processorCardTotalCount += newValue;
                    processorPrivTotalCount += newValue;
                }
                else if (value == "Q" || value == "K" || value == "A" || value == "J")
                {
                    switch (value)
                    {
                        case "Q":
                            processorCardTotalCount += newValue;
                            processorPrivTotalCount += newValue;
                            break;
                        case "J":
                            processorCardTotalCount += newValue;
                            processorPrivTotalCount += newValue;
                            break;
                        case "K":
                            processorCardTotalCount += newValue;
                            processorPrivTotalCount += newValue;
                            break;
                        case "A":
                            int randomnew = Random.Range(0, 2);
                            if (randomnew == 0)
                            {
                                processorCardTotalCount += newValue;
                                processorPrivTotalCount += newValue;
                            }
                            else
                            {
                                processorCardTotalCount += newValue;
                                processorPrivTotalCount += newValue;
                            }
                            break;
                    }
                }
                processorCardTotalCountText.text = processorPrivTotalCount.ToString();
                StartCoroutine(NewCard.GetComponent<CardMovement>().move(ProcessorPoints[i].position, true, ProcessorPoints[i].rotation));
                orders++;
            }
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);

        for (int i = 5; i > 3; i--)
        {
            var NewCard = Instantiate(CardPrefab, creator.transform.position, Quaternion.identity);
            NewCard.GetComponent<CardMovement>().Who = CardMovement.who.you;
            
            StartCoroutine(NewCard.GetComponent<CardMovement>().move(YouPoints[i].position, true, YouPoints[i].rotation));
            YouPoints.RemoveAt(i);
            yield return new WaitForSeconds(1);
            orders++;
        }
        processorCardTotalCountText.text = processorCardTotalCount.ToString();
        FunctionButtons.SetActive(true);

        Debug.Log("İlkDizmeTamamlandı");
    }
    public void HitCard()
    {
        CreateCard();
    }
    int newcount;
    public void StandRound()
    {
        newcount = processorCardTotalCount + UnityEngine.Random.Range(5, 22);
        processorCardTotalCount = newcount;
        processorCardTotalCountText.text = processorCardTotalCount.ToString();
        Invoke("stand", 1);
    }
    public void stand()
    {
        
        if (newcount > myCardTotalCount && newcount <= 21)
        {
            mainPanelChild.SetActive(false);
            gameEnd("fail");
        }
        if (newcount < myCardTotalCount && myCardTotalCount <= 21)
        {
            mainPanelChild.SetActive(false);
            gameEnd("win");
        }
        if (newcount == myCardTotalCount && myCardTotalCount <= 21)
        {
            mainPanelChild.SetActive(false);
            gameEnd("draw");
        }
        if (newcount > myCardTotalCount && myCardTotalCount <=21)
        {
            mainPanelChild.SetActive(false);
            gameEnd("win");
        }
    }
    public void CreateCard()
    {
        var NewCard = Instantiate(CardPrefab, creator.transform.position, Quaternion.identity);
        NewCard.GetComponent<CardMovement>().Who = CardMovement.who.you;
        StartCoroutine(NewCard.GetComponent<CardMovement>().move(YouPoints[YouPoints.Count - 1].position, true, YouPoints[YouPoints.Count - 1].rotation));
        YouPoints.RemoveAt(YouPoints.Count - 1);
        orders++;
    }
    public void CheckMyCards()
    {
        if (myCardTotalCount > 21)
        {
            Invoke("gameFail", 1);
            mainPanelChild.SetActive(false);
            gameEnd("fail");
        }
    }
    public int totalWin;
    public void gameEnd(string situation)
    {
        switch(situation)
        {
            case "fail":
                crushpanelChild.SetActive(true);
                totalWin = 0;
                break;
            case "win":
                winPanelChild.SetActive(true);
                winMoneyText.text = "You Win : " + FindObjectOfType<MenuManager>().betCount * 2 + "$";
                totalWin = FindObjectOfType<MenuManager>().betCount * 2;
                break;
            case "draw":
                winPanelChild.SetActive(true);
                winMoneyText.text = "Draw";
                totalWin = FindObjectOfType<MenuManager>().betCount;
                break;
        }
    }
    
    public void playagainButton()
    {
        MenuManager menumanager = FindObjectOfType<MenuManager>();
        if (totalWin == 0)
        {
            PlayerPrefs.SetInt("Money", menumanager.betCount);
        }
        else
        {
            PlayerPrefs.SetInt("Money", menumanager.myMoney += totalWin);
        }
        totalWin = 0;
        SceneManager.LoadScene(0);


    }
}
