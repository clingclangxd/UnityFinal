using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;
    public Text balanceText;
    public Text betText;
    public Text playerHandText;
    public Text dealerHandText;
    public Text messageText;
    public Button hitButton;
    public Button standButton;
    public Button doubleDownButton;

    
    public void UpdateUI()
    {
        
        balanceText.text = "Balance: $" + GameManager.instance.player.balance.ToString();

        
        betText.text = "Bet: $" + GameManager.instance.player.bet.ToString();

        
        playerHandText.text = "Player Hand: " + GetHandAsString(GameManager.instance.player.playerHand);

        
        dealerHandText.text = "Dealer Hand: " + GetHandAsString(GameManager.instance.dealer.dealerHand);

       
        messageText.text = "Message: "; 

        
        hitButton.interactable = true; 
        standButton.interactable = true; 
        doubleDownButton.interactable = true; 

        
        if (GameManager.instance.player.playerHand.HasBlackjack() ||
            GameManager.instance.player.playerHand.HasBusted() ||
            GameManager.instance.player.balance < GameManager.instance.player.bet ||
            GameManager.instance.player.playerHand.cards.Count >= 5)
        {
            hitButton.interactable = false;
            standButton.interactable = false;
            doubleDownButton.interactable = false;
        }
    }


    
    private string GetHandAsString(Hand hand)
    {
        string handString = "";
        foreach (Card card in hand.cards)
        {
            handString += card.rank.ToString() + " of " + card.suit.ToString() + ", ";
        }
        
        handString = handString.TrimEnd(',', ' ');
        return handString;
    }

    
    public void OnHitButtonClick()
    {
        GameManager.instance.PlayerHit();
        UpdateUI();
    }

    
    public void OnStandButtonClick()
    {
        GameManager.instance.PlayerStand();
        UpdateUI();
    }

    
    public void OnDoubleDownButtonClick()
    {
        GameManager.instance.PlayerDoubleDown();
        UpdateUI();
    }
}
