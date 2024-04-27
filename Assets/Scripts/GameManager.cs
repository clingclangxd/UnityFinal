using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    
    public Player player;
    public Dealer dealer;

    
    public Deck deck;

    
    public int startingBalance = 1000;

    
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    
    void Start()
    {
        
        player.InitializePlayer(startingBalance);

        
        dealer.InitializeDealer();

        
        StartRound();
    }

    
    public void StartRound()
    {
        
        player.playerHand.ClearHand();
        dealer.dealerHand.ClearHand();
        player.ResetBet();

        
        deck.InitializeDeck();
        deck.ShuffleDeck();

        
        player.playerHand.AddCard(deck.DealCard());
        player.playerHand.AddCard(deck.DealCard());
        dealer.dealerHand.AddCard(deck.DealCard());
        dealer.dealerHand.AddCard(deck.DealCard());

        
        UIManager.instance.UpdateUI();
    }

    
    public void PlayerHit()
    {
        
        player.playerHand.AddCard(deck.DealCard());

        
        CheckRoundOutcome();
    }

    
    public void PlayerStand()
    {
        
        dealer.PlayTurn();

        
        CheckRoundOutcome();
    }

    
    public void PlayerDoubleDown()
    {
        
        player.PlaceBet(player.bet * 2);

        
        player.playerHand.AddCard(deck.DealCard());

        
        PlayerStand();
    }


    
    private void CheckRoundOutcome()
    {
        
        int playerHandValue = player.playerHand.CalculateHandValue();
        int dealerHandValue = dealer.dealerHand.CalculateHandValue();

        
        if (playerHandValue == 21 && player.playerHand.cards.Count == 2 && !(dealerHandValue == 21 && dealer.dealerHand.cards.Count == 2))
        {
            
            player.AddWinnings(player.bet * 3); 
            UIManager.instance.UpdateUI();
            return;
        }
        else if (playerHandValue > 21)
        {
            
            UIManager.instance.UpdateUI();
            return;
        }

        
        while (dealerHandValue < 17)
        {
            dealer.dealerHand.AddCard(deck.DealCard());
            dealerHandValue = dealer.dealerHand.CalculateHandValue();
        }

        
        if (dealerHandValue > 21)
        {
            
            player.AddWinnings(player.bet * 2); 
            UIManager.instance.UpdateUI();
            return;
        }

        
        if (playerHandValue > dealerHandValue)
        {
            
            player.AddWinnings(player.bet * 2); 
        }
        else if (playerHandValue < dealerHandValue)
        {
            
        }
        else
        {
            
            player.balance += player.bet;
        }

        UIManager.instance.UpdateUI();
    }
}
