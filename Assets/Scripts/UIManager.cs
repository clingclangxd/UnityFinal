using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Reference to UI elements
    public static UIManager instance;
    public Text balanceText;
    public Text betText;
    public Text playerHandText;
    public Text dealerHandText;
    public Text messageText;
    public Button hitButton;
    public Button standButton;
    public Button doubleDownButton;

    // Method to update UI with current game state
    public void UpdateUI()
    {
        // Update player's balance
        balanceText.text = "Balance: $" + GameManager.instance.player.balance.ToString();

        // Update current bet
        betText.text = "Bet: $" + GameManager.instance.player.bet.ToString();

        // Update player's hand
        playerHandText.text = "Player Hand: " + GetHandAsString(GameManager.instance.player.playerHand);

        // Update dealer's hand
        dealerHandText.text = "Dealer Hand: " + GetHandAsString(GameManager.instance.dealer.dealerHand);

        // Update message text
        messageText.text = "Message: "; // Clear previous message

        // Enable/disable buttons based on game state
        hitButton.interactable = true; // Enable hit button by default
        standButton.interactable = true; // Enable stand button by default
        doubleDownButton.interactable = true; // Enable double down button by default

        // Disable buttons if the player has blackjack, busted, has insufficient funds, or has already stood
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


    // Method to convert a hand to a string representation
    private string GetHandAsString(Hand hand)
    {
        string handString = "";
        foreach (Card card in hand.cards)
        {
            handString += card.rank.ToString() + " of " + card.suit.ToString() + ", ";
        }
        // Remove the trailing comma and space
        handString = handString.TrimEnd(',', ' ');
        return handString;
    }

    // Method to handle player input for hitting
    public void OnHitButtonClick()
    {
        GameManager.instance.PlayerHit();
        UpdateUI();
    }

    // Method to handle player input for standing
    public void OnStandButtonClick()
    {
        GameManager.instance.PlayerStand();
        UpdateUI();
    }

    // Method to handle player input for doubling down
    public void OnDoubleDownButtonClick()
    {
        GameManager.instance.PlayerDoubleDown();
        UpdateUI();
    }
}
