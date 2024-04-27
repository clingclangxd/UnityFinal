using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    
    public Suit suit;
    public Rank rank;

    
    public int GetValue()
    {
        
        if ((int)rank >= 10)
            return 10;
        else
            return (int)rank;
    }

    
    public void InitializeCard(Suit s, Rank r)
    {
        suit = s;
        rank = r;
    }
}
