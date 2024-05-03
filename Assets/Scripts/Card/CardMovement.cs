using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    public float moveSpeed;
    public string value;

    public CardInfo.CardType cardType;
    public List<Sprite> cardSprites;

    private GameObject childSprite;

    /// <summary>
    public int SortingOrder;
    /// </summary>
    public Vector2 pos;
    public Quaternion rot;

    public List<string> values;
    public enum who {you, processor};
    public who Who;
    private void Awake()
    {
        value = values[Random.Range(0, values.Count)];
        cardType = (CardInfo.CardType)Random.Range(0, 4);
    }
    public void Start()
    {
        childSprite = transform.GetChild(0).gameObject;
        SetValue();
        if (Who == who.you)
        {
            SendNof();
        }
    }
    public void SetValue()
    {
        var gameManager = GameObject.FindObjectOfType<GameManager>();
        SetOrderLayer(gameManager.orders);
        for (int i = 0; i < cardSprites.Count; i++)
        {
            string currentCardQueue = cardType.ToString() + " " + value;
            print(cardSprites[i].name);
            if (cardSprites[i].name == currentCardQueue)
            {
                childSprite.GetComponent<SpriteRenderer>().sprite = cardSprites[i];
                Debug.Log("created : " + currentCardQueue);
                break;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(move(pos,true,rot));
        }
    }
    
    public void SetOrderLayer(int sortingOrder)
    {
        var cardFrontEnd = transform.GetChild(0).gameObject;
        var cardBackEnd = cardFrontEnd.transform.GetChild(0).gameObject;

        cardFrontEnd.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        cardBackEnd.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
    }

    public IEnumerator move(Vector2 target, bool Rotating, Quaternion targetRotation)
    {
        float current = 0;
        float moveTime = moveSpeed;
        while (current < moveTime)
        {
            current += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, current / moveTime);
            if (Rotating)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, current / moveTime);
            }
            yield return null;
        }
        var manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        manager.CheckMyCards();
    }
    public void SendNof()
    {
        int newValue = 0;
        var manager = FindObjectOfType<GameManager>();
        if (value != "Q" && value != "K"&& value != "J" && value != "A")
        {
            int.TryParse(value, out newValue);
            manager.GetNewCardProp(newValue);
        }
        else if(value == "Q" || value == "K" || value == "A" || value == "J")
        {
            switch (value)
            {
                case "Q":
                    manager.GetNewCardProp(10);
                    break;
                case "J":
                    manager.GetNewCardProp(10);
                    break;
                case "K":
                    manager.GetNewCardProp(10);
                    break;
                case "A":
                    int randomnew = Random.Range(0, 2);
                    if (randomnew == 0)
                    {
                        manager.GetNewCardProp(1);
                    }
                    else
                    {
                        manager.GetNewCardProp(11);
                    }
                break;
            }
        }

    }
}
public class CardInfo
{
    public enum CardType {Karo,Kupa,Maça,Sinek};
}
