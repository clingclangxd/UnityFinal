using UnityEngine;

public class Dealer : MonoBehaviour
{
    
    public Hand dealerHand;

    
    public void InitializeDealer()
    {
        
        dealerHand.ClearHand();
    }

    
    public void PlayTurn()
    {
        
        RevealHiddenCard();

        
        while (dealerHand.CalculateHandValue() < 17)
        {
            
            dealerHand.AddCard(GameManager.instance.deck.DealCard());
        }
    }

    
    private void RevealHiddenCard()
    {
        
        dealerHand.cards[1].gameObject.SetActive(true);
    }
}
