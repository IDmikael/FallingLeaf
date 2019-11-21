using UnityEngine;

public class LeafController : MonoBehaviour
{
    private Vector2 fingerDownPos;
    private float speedModifier = 1f;

    public float windForce = 0;
    public bool isPlaying = false;

    public void GameOver()
    {
        isPlaying = false;
        Debug.Log("GAME OVER");
    }

    void Update()
    {
        if (!isPlaying)
            return;

        //Handle swipe touch input
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("delta pos: " + touch.deltaPosition.x);
                MoveLeaf(touch.deltaPosition.x);
            }
        }

        //Apply wind force to leaf
        if (windForce != 0)
        {
            MoveLeaf(windForce);
        }
    }

    private void MoveLeaf(float pos)
    {
        //Dont let leaf to move out of the screen
        if (transform.localPosition.x + pos * speedModifier < -235f ||
            transform.localPosition.x + pos * speedModifier > 250f)
        {
            pos = 0;
        }

        transform.localPosition = new Vector3(transform.localPosition.x + pos * speedModifier,
            transform.localPosition.y, 0);
    }
}
