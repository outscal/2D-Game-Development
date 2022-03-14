using UnityEngine;
using UnityEngine.UI;

public class HealthController: MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;

    public void LoseLife()
    {
        if(livesRemaining == 0)
        {
            return;
        }

        livesRemaining--;

        lives[livesRemaining].enabled = false;

        if(livesRemaining == 0)
        {
            Debug.Log("You Lost");
        }
    }
}
