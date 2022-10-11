using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCanon : MonoBehaviour
{
    [SerializeField] public GameObject[] food;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnFoodDoWhile), 0, 0.2f);
    }

    private void FireFood()
    {
        int randomFood = Random.Range(0, food.Length);
        GameObject newfood = Instantiate(food[randomFood], transform.position, transform.rotation);
        Rigidbody direction = newfood.GetComponent<Rigidbody>();
       //direction.AddForce(Random.insideUnitSphere * 1000);
    }

    private void SpawnFoodForEach()
    {
        foreach (GameObject currentFood in food)
        {
            GameObject newfood = Instantiate(currentFood, transform.position, transform.rotation);
            Rigidbody direction = newfood.GetComponent<Rigidbody>();
            direction.AddForce(Random.insideUnitSphere * 1000);
        }
    }
    private void SpawnFoodFor()
    {
        for (int i = 0; i < food.Length; i += 2)
        {
            GameObject newfood = Instantiate(food[i], transform.position, transform.rotation);
            Rigidbody direction = newfood.GetComponent<Rigidbody>();
            direction.AddForce(Random.insideUnitSphere * 1000);

        }
    }
    private void SpawnFoodWhile()
    {
        int i = 0;
        while (i < food.Length)
        {
            GameObject newfood = Instantiate(food[i], transform.position, transform.rotation);
            Rigidbody direction = newfood.GetComponent<Rigidbody>();
            direction.AddForce(Random.insideUnitSphere * 1000);
            i++;
        }
    }
    private void SpawnFoodDoWhile()
    {
        int i = 0;
        do
        {
            GameObject newfood = Instantiate(food[i], transform.position, transform.rotation);
            Rigidbody direction = newfood.GetComponent<Rigidbody>();
            //direction.AddForce(Random.insideUnitSphere * 1000);
            i++;
        }
        while (i < food.Length);
    }
}
