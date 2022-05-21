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

    void NewRandomNumber()
    {
        int randomNumber;
        int lastNumber;
        randomNumber = Random.Range(0, 10);
        Debug.Log(randomNumber);
    }

 /*   public void move()
    {
        int randomNumber = randomNumber.Range(1, 4);
        Debug.Log(randomNumber);
        Debug.Log(randomNumber);
        Debug.Log(randomNumber);
        Debug.Log(randomNumber);
    }
 */

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
