using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private DetectionType detectionType;

    private void TryUpdateSpawnPoint(GameObject objectToUpdate)
    {
        if (objectToUpdate.TryGetComponent(out Respawner respawn))
        {
            respawn.SetSpawnPos(respawnPoint.position);
            print("NEW SPAWN POINT");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Triggered by:: " + other.gameObject.name);
        if (detectionType == DetectionType.OnTriggerEnter) TryUpdateSpawnPoint(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collided with: " + collision.gameObject.name);
        if (detectionType == DetectionType.OnCollisionEnter) TryUpdateSpawnPoint(collision.gameObject);
    }

    public enum DetectionType
    {
        OnTriggerEnter,
        OnCollisionEnter
    }
}
