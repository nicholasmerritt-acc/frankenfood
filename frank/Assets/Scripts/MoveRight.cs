using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float velocity = .1f;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Running_b", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocity, Space.World);
    }
}
