using UnityEngine;

public class Background : MonoBehaviour
{
    //states: 
    //0 - normal
    //1 - rain

    public int state = 0;
    
    public void SetState(int newState)
    {
        state = newState;
    }
}
