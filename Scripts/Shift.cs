using UnityEngine;

public class Shift : MonoBehaviour
{
    [SerializeField] private float doubleTapTime = 0.3f; // Maximum time interval between taps to be considered a double-tap
    private float lastTapTime = -1f; // Initialized to -1 to indicate no tap has been registered

    public void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            float currentTime = Time.time;

            // Check for double-tap
            if (lastTapTime >= 0 && currentTime - lastTapTime <= doubleTapTime)
            {
                // Double tap detected
                if (Player_Movement.move_speed > Player_Movement.init_speed)
                {
                    Player_Movement.move_speed = Player_Movement.init_speed;
                    Debug.Log("Speed reset to initial speed");
                }
                else
                {
                    Player_Movement.move_speed += Player_Movement.speed_increase;
                    Debug.Log("Speed increased");
                }

                // Reset lastTapTime to prevent consecutive detections
                lastTapTime = -1f;
            }
            else
            {
                // Record the time of the first tap
                lastTapTime = currentTime;
                Debug.Log("First tap registered at " + currentTime);
            }
        }
    }
}
