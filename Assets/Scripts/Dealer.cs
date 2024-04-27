using UnityEngine;

public class Dealer : MonoBehaviour
{
    // Reference to the dealer's hand
    public Hand dealerHand;

    // Method to initialize the dealer
    public void InitializeDealer()
    {
        // Initialize the dealer's hand
        dealerHand.ClearHand();
    }

    // Method to handle the dealer's turn
    public void PlayTurn()
    {
        // Reveal the dealer's hidden card
        RevealHiddenCard();

        // Keep hitting until the dealer's hand value is 17 or higher
        while (dealerHand.CalculateHandValue() < 17)
        {
            // Deal a card to the dealer
            dealerHand.AddCard(GameManager.instance.deck.DealCard());
        }
    }

    // Method to reveal the dealer's hidden card
    private void RevealHiddenCard()
    {
        // Make the second card in the dealer's hand visible
        dealerHand.cards[1].gameObject.SetActive(true);
    }
}
