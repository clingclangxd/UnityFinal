using UnityEngine;
using System.Collections.Generic;

public class BettingSystem : MonoBehaviour
{
    
    public enum BetType
    {
        Province,
        Region,
        OddEven
    }

    
    public Dictionary<BetType, float> payoutRatios = new Dictionary<BetType, float>()
    {
        { BetType.Province, 35f },
        { BetType.Region, 1f },
        { BetType.OddEven, 1f }
    };

    
    public float balance = 1000f;
    public List<Bet> activeBets = new List<Bet>();

    
    public void PlaceBet(BetType betType, float amount)
    {
        
        if (balance >= amount)
        {
            
            balance -= amount;

            
            activeBets.Add(new Bet(betType, amount));

            Debug.Log("Placed a bet of " + amount + " on " + betType.ToString() + ". Current balance: " + balance);
        }
        else
        {
            Debug.LogWarning("Insufficient balance to place the bet.");
        }
    }

    
    public void ClearBets()
    {
        activeBets.Clear();
        Debug.Log("All bets cleared.");
    }

    
    public float GetBalance()
    {
        return balance;
    }

    
    public float GetPayoutRatio(BetType betType)
    {
        if (payoutRatios.ContainsKey(betType))
        {
            return payoutRatios[betType];
        }
        else
        {
            Debug.LogError("Payout ratio not defined for bet type: " + betType);
            return 0f;
        }
    }

    
    public void UpdateBalance(float payout)
    {
        balance += payout;
    }

    
    public List<Bet> GetActiveBets()
    {
        return activeBets;
    }

    
    public class Bet
    {
        public BetType type;
        public float amount;

        public Bet(BetType type, float amount)
        {
            this.type = type;
            this.amount = amount;
        }

        
        public bool IsWinningBet(int winningNumber)
        {
            
            return false; 
        }
    }
}
