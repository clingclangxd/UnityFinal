using UnityEngine;
using UnityEngine.UI;

public class BallThrower : MonoBehaviour
{
    public GameObject ball; 
    public Transform throwPoint; 
    public RouletteWheel rouletteWheel; 

    public Text winningNumberText; 

    private bool isBallThrown = false;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !isBallThrown)
        {
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        
        GameObject thrownBall = Instantiate(ball, throwPoint.position, Quaternion.identity);

        
        thrownBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500f);

        isBallThrown = true;
    }

    
    public void BallStopped(int winningNumber)
    {
        
        winningNumberText.text = "Winning Number: " + winningNumber;
    }
}
