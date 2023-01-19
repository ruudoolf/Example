using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour

{
    [SerializeField] public GameObject food;
    [SerializeField] private int rotationSpeed = 100;
    [SerializeField] private Vector3 shootingDirection = new Vector3(0, 1000, 0);
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject shootingEffect;

    // Update is called once per frame
    private void Update()
    {
        
        float horizontalAxis = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        float verticalAxis = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed * -1;
        transform.Rotate(verticalAxis, horizontalAxis, 0, Space.World);
        if (Input.GetButtonDown("Fire1"))
        {
            AudioManager.Instance.Play("Shot");
            
            GameObject newfood = Instantiate(food, shootPoint.position, shootPoint.rotation);
            Rigidbody direction = newfood.GetComponent<Rigidbody>();
            direction.AddForce(shootPoint.TransformDirection(shootingDirection));
            Instantiate(shootingEffect, shootPoint.position, shootPoint.rotation);

        }
    }
}
