using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour

{
    [SerializeField] public GameObject food;
    [SerializeField] private int rotationSpeed = 100;
    [SerializeField] private Vector3 shootingDirection = new Vector3(0, 1000, 0);
    [SerializeField] private Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        transform.Rotate(-verticalAxis*Time.deltaTime*rotationSpeed, 0, -horizontalAxis * Time.deltaTime*rotationSpeed, Space.World);
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newfood = Instantiate(food, shootPoint.position, shootPoint.rotation);
            Rigidbody direction = newfood.GetComponent<Rigidbody>();
            direction.AddForce(shootPoint.TransformDirection(shootingDirection));

        }
    }
}
