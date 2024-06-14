using UnityEngine;

public class Shift : MonoBehaviour
{
    public void ShiftToSprint()
    {
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
    }
}
