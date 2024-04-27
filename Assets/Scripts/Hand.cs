using UnityEngine;
using System.Collections.Generic;

public class Hand : MonoBehaviour
{
    
    public List<Card> cards = new List<Card>();

    
    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    
    public int CalculateHandValue()
    {
        int handValue = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            int cardValue = card.GetValue();
            handValue += cardValue;

            
            if (card.rank == Card.Rank.Ace)
                aceCount++;
        }

        
        while (aceCount > 0 && handValue > 21)
        {
            handValue -= 10;
            aceCount--;
        }

        return handValue;
    }

    
    public bool HasBlackjack()
    {
        return (cards.Count == 2 && CalculateHandValue() == 21);
    }

    
    public bool HasBusted()
    {
        return (CalculateHandValue() > 21);
    }

    
    public void ClearHand()
    {
        cards.Clear();
    }
}
