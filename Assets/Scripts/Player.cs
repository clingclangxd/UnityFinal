using UnityEngine;

public class Player : MonoBehaviour
{

    public int balance;

    
    public int bet;

    
    public Hand playerHand;

    
    public void InitializePlayer(int startingBalance)
    {
        balance = startingBalance;
        bet = 0; // Initialize bet to zero
    }

    
    public bool PlaceBet(int amount)
    {
        if (amount <= balance)
        {
            bet = amount;
            balance -= bet;
            return true;
        }
        else
        {
            Debug.Log("Insufficient balance to place bet.");
            return false;
        }
    }

    
    public void AddWinnings(int amount)
    {
        balance += amount;
    }

    
    public void ResetBet()
    {
        bet = 0;
    }

    
    public void Hit()
    {
        
    }

    
    public void Stand()
    {
        
    }

    
    public bool DoubleDown()
    {
        
        if (PlaceBet(bet * 2))
        {
            Hit(); 
            return true;
        }
        else
        {
            return false; 
        }
    }
}
