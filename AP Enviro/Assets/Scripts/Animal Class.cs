using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalClass : MonoBehaviour
{
    private int hp = -1;
    private int x = -1;
    private int y = -1;


    public AnimalClass(int hp, int x, int y)
    {
        this.hp = hp;
        this.x = x;
        this.y = y;
    }

    public bool Walkable( /* data that tells us about tiles around animal  */)
    {
        return true;
    }
//generates a random number between 1 and 4
    void NewRandomNumber()
    {
        int randomNumber;
        int lastNumber;
        randomNumber = Random.Range(0, 4);
        Debug.Log(randomNumber);
    }
//uses rng numbers to move
//1 is right
//2 is left
//3 is up
//4 is down

//check if tile in walkable 
//if so move there, if not generate a new num/direction and check if the tile is walkable 
    public void move()
    {
        //1 m
    }
 

    // Start is called before the first frame update
    void Start()
    {
        //move();
        Debug.Log("random numbers are below");
        NewRandomNumber();
        NewRandomNumber();
        NewRandomNumber();
        NewRandomNumber();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
