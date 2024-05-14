using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public Text outcomeText; 
    public Text balanceText; 
    public Button spinButton; 
    public Button stopButton;
    public RouletteWheel rouletteWheel; 

    private void Start()
    {
        spinButton.onClick.AddListener(OnSpinButtonClick);
    }

    
    private void OnStopButtonClick()
    {
        
        rouletteWheel.StopWheel();

       
        stopButton.interactable = false;
    }

    private void OnSpinButtonClick()
    {
        
        rouletteWheel.SpinWheel();
    }
    public void UpdateOutcomeText(string message)
    {
        outcomeText.text += message + "\n";
    }

    
    public void UpdateBalanceText(float balance)
    {
        balanceText.text = "Player Balance: " + balance;
    }
}
