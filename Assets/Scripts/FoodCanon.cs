using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCanon : MonoBehaviour
{
    [SerializeField] public GameObject[] food;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(FireFood),0.5f, 0.5f);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FireFood() 
    { 
    int randomFood = Random.Range(0,food.Length);
    GameObject newfood = Instantiate(food[randomFood],transform.position, transform.rotation);
        Rigidbody richtung = newfood.GetComponent<Rigidbody>();
        richtung.AddForce(Random.insideUnitSphere*1000);

    
    }
}
