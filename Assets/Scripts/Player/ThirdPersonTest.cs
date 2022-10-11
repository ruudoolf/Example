using UnityEngine;

public class ThirdPersonTest : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;

    private void Jump()
    {
        animator.Play("JumpOneTake");
    }

    private void Run(float xSpeed, float zSpeed)
    {
        animator.SetFloat("xSpeed", xSpeed);
        animator.SetFloat("zSpeed", zSpeed);

        transform.Translate(speed * Time.deltaTime * new Vector3(xSpeed, 0, zSpeed));
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Run(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
