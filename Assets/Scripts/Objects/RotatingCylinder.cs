using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingCylinder : MonoBehaviour
{
    [SerializeField] private int rotationSpeed = 150;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1 * Time.deltaTime * rotationSpeed, Space.Self);


    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent <Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(new Vector3(100, 0, 0));
        }
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Knockout();
        }
    }
}
