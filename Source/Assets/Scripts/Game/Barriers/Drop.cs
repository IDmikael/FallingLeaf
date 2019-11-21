using UnityEngine;

public class Drop : Barrier
{
    //Splash effect when drop touches branch
    public ParticleSystem splash;

    public float speed = 0.1f;

    private bool destroy = false;

    protected override void Update()
    {
        if (destroy && !splash.isPlaying)
            Destroy(gameObject);

        //Changes direction from down-up to up-down
        upForceValue = -speed;

        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Branch(Clone)" || collision.gameObject.name == "Rock(Clone)")
        {
            splash.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            destroy = true;
        }
        else
        {
            base.OnTriggerEnter2D(collision);
        }       
    }
}
