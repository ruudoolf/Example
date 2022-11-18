using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiments : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Person programmierlehrer = new Person();
        programmierlehrer.Age = 4;
        Person dani = new Person();
        programmierlehrer.Age = 25;
        print(dani.Age);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Person
{
    public int Age { get; set;}
    public string Name { get; set; }
    public Person besterFreund;
}