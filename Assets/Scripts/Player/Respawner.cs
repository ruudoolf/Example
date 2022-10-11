using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private float fallTimeUntilRespawn = 3f;
    private BasicBehaviour thirdPersonController;
    private FlyBehaviour flyController;
    private float fallTimer;
    private Vector3 respawnPos;

    public void SetSpawnPos(Vector3 newSpawnPos)
    {
        respawnPos = newSpawnPos;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        SetSpawnPos(transform.position);
        thirdPersonController = GetComponent<BasicBehaviour>();
        flyController = GetComponent<FlyBehaviour>();
    }

    private void Respawn()
    {
        ResetTimer();
        transform.position = respawnPos;
    }

    private void ResetTimer()
    {
        fallTimer = fallTimeUntilRespawn;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!thirdPersonController.IsGrounded() && !flyController.IsFlying)
        {
            fallTimer -= Time.deltaTime;
            if (fallTimer < 0)
            {
                Respawn();
            }
        }
        else
        {
            ResetTimer();
        }
    }
}
