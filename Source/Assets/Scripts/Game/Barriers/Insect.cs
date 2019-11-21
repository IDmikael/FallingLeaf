using UnityEngine;

public class Insect : Barrier
{
    //left = -1 or right = 1
    public int direction = 1;
    public float speed = 0.03f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("Insect");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.localPosition = new Vector3(transform.localPosition.x + speed * direction,
            transform.localPosition.y, 0);
    }
}
