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
        
        float horizontalAxis = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        float verticalAxis = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed * -1;
        transform.Rotate(verticalAxis, horizontalAxis, 0, Space.World);
        if (Input.GetButtonDown("Fire1"))
        {
            //AudioManager.Instance.Play("");
            AudioSource audio = GetComponent<AudioSource>();
            audio.pitch = Random.Range(-3, 4);
            audio.Play();
            
            GameObject newfood = Instantiate(food, shootPoint.position, shootPoint.rotation);
            Rigidbody direction = newfood.GetComponent<Rigidbody>();
            direction.AddForce(shootPoint.TransformDirection(shootingDirection));

        }
    }
}
