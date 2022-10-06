using UnityEngine;

public class ThirdPersonTest : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("JumpOneTake");
        }

        animator.SetFloat("xSpeed", Input.GetAxis("Horizontal"));
        animator.SetFloat("zSpeed", Input.GetAxis("Vertical"));
    }
}
