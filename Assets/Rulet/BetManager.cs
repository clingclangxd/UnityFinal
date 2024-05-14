using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{
    public RouletteWheel rouletteWheel;
    public BettingSystem bettingSystem;
    public UIManager uiManager;

    public Button spinButton; 
    public Button stopButton; 

    private void Start()
    {
        
        spinButton.onClick.AddListener(OnSpinButtonClick);
        stopButton.onClick.AddListener(OnStopButtonClick);

        
        stopButton.interactable = false;

        
        rouletteWheel.OnWheelStop += ResolveBets;
    }

    
    private void OnSpinButtonClick()
    {
        
        rouletteWheel.SpinWheel();

        
        stopButton.interactable = true;
    }

    
    private void OnStopButtonClick()
    {
        
        rouletteWheel.StopWheel();

        
        stopButton.interactable = false;
    }

    
    private void ResolveBets(int winningNumber)
    {
        
        var activeBets = bettingSystem.GetActiveBets();

        
        foreach (var bet in activeBets)
        {
            
            if (bet.IsWinningBet(winningNumber))
            {
                
                float payout = bet.amount * bettingSystem.GetPayoutRatio(bet.type);

                
                bettingSystem.UpdateBalance(payout);

                
                uiManager.UpdateOutcomeText("Congratulations! You won " + payout + " on bet " + bet.type);
            }
            else
            {
                
                uiManager.UpdateOutcomeText("Sorry, you lost " + bet.amount + " on bet " + bet.type);
            }
        }

        
        bettingSystem.ClearBets();

        
        uiManager.UpdateBalanceText(bettingSystem.GetBalance());
    }
}
