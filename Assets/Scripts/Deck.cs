using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    public GameObject cardPrefab;

    
    private List<Card> cards = new List<Card>();

    
    public void InitializeDeck()
    {
        
        if (cards.Count > 0)
            cards.Clear();

        
        foreach (Card.Suit suit in System.Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank rank in System.Enum.GetValues(typeof(Card.Rank)))
            {
                
                GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                Card cardComponent = newCard.GetComponent<Card>();

                
                cardComponent.InitializeCard(suit, rank);

                
                cards.Add(cardComponent);
            }
        }
    }

    
    public void ShuffleDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            
            int randomIndex = Random.Range(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    
    public Card DealCard()
    {
        if (cards.Count == 0)
        {
            Debug.LogError("Deck is empty! Cannot deal card.");
            return null;
        }

        
        Card dealtCard = cards[0];
        cards.RemoveAt(0);
        return dealtCard;
    }
}

