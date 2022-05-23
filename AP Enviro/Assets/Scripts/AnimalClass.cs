using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalClass : MonoBehaviour
{
    [SerializeField] private Transform movePoint; // point where animal wants to move
    [SerializeField] private LayerMask waterLayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start sim");
        movePoint.parent = null;
        
    }
    // Update is called once per frame
    void Update()
    {
        randomlyMoveToValidSpot();
    }

    /* this is making me want to cry - randrll
    *   
    *   generates 2 integers from -1 - 1, one being vertical and one being horizontal based on the diagram below
    *   
    *  -1 0 1
    *   0 X 
    *   1
    *
    */

    public void randomlyMoveToValidSpot() {
        Debug.Log("Moving");
        int horizontal = (int) NewRandomNumber(-1,2);
        int vertical = (int) NewRandomNumber(-1,2);
        Debug.Log("Horizontal: " + horizontal + "\nVertical: " + vertical + "\nShould move now...");
        movePoint.position += new Vector3(horizontal, vertical, 0f);
                 
    }

    public IEnumerator loopMovementFunctionBecauseUnityIsStupid() {
        while (true) {
            Debug.Log("loop start");
            randomlyMoveToValidSpot();
            Debug.Log("Before wait");
            yield return new WaitForSecondsRealtime(5);
            Debug.Log("loop end");
        }
    }

    /*
    0 = dead
    1 = sick
    2 = okay
    3 = very healthy

    Walkable (not done): checks if tile is walkable
    reproduce(done): returns if two animals reproduce 
    test(done): just for testing random things
    move(not done): not done bc calls walkable with is not done
        1. create rng 1-4,
        2. check if random direction is walkable. if true, move there. If false, go back to step 1
    
    move and reproduce should be called in update()

    */
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

    public static int  NewRandomNumber(int min, int max)
    {
        int randomNumber;
        int lastNumber;
        randomNumber = Random.Range(min, max);
        return randomNumber;
    }


    public static bool reproduce(int hp, int x1, int y1, int x2, int y2, int distance)
    {
       if (Mathf.Abs(x1 - x2) <= distance && Mathf.Abs(y1 - y2) <= distance)
       {

            if(hp == 3)
            {
                if(NewRandomNumber(1,10) <= 8)
                {
                    return true;
                }
            }
            if(hp == 2)
            {
                if(NewRandomNumber(1,10) <= 5)
                {
                    return true;
                }
            }
            if(hp == 1)
            {
                if(NewRandomNumber(1,10) == 1)
                {
                    return true;
                }
            }
            
       }
       return false;
    }


    //method for testing
    public static void test()
    {
        Debug.Log("healty");
        for (int i = 0; i < 10; i++)
        {
            if (reproduce(3, 1, 1, 1, 1, 10))
            {
                Debug.Log("reproduce");
            }
            else
            {
                Debug.Log("reproduce failed");
            }
        }

        Debug.Log("okay");
        for (int i = 0; i < 10; i++)
        {
            if (reproduce(2, 1, 1, 1, 1, 10))
            {
                Debug.Log("reproduce");
            }
            else
            {
                Debug.Log("reproduce failed");
            }
        }
    }
    //uses rng numbers to move
    //1 is right
    //2 is left
    //3 is up
    //4 is down

    //check if tile in walkable 
    //if so move there, if not generate a new num/direction and check if the tile is walkable 
    
    
    public void move(int increaseX, int increaseY)
    {
        bool moved = false;

        while (!moved)
        {
            int direction = NewRandomNumber(1, 4);
            if (direction == 1)
            {
                //call walkable to see if right is open if so move there
                moved = true; //only if we moved
            }
            else if (direction == 2)
            {
                //call walkable to see if left is open if so move there
                moved = true; //only if we moved
            }
            else if (direction == 3)
            {
                //call walkable to see if up is open if so move there
                moved = true; //only if we moved 
            }
            else
            {
                //call walkable to see if down is open if so move there
                moved = true; //only if we moved
            }
        }
    }
}
