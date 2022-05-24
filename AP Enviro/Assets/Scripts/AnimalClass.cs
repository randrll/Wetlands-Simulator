using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalClass : MonoBehaviour
{
    [SerializeField] private Transform movePoint; // point where animal wants to move
    [SerializeField] private LayerMask waterLayer; // water layer with water cols
    [SerializeField] private LayerMask border; // border layer with border cols

    [SerializeField] private int moveSpeed; // movement speed
    [SerializeField] private float radialSize; // hitbox size
    [SerializeField] private float randomCheckRange; // how big the random selection area is


    [SerializeField] private bool isLand;

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
    *     X 0
    *      -1
    *
    */

    public void randomlyMoveToValidSpot() {    
        int horizontal = (int) Random.Range( -randomCheckRange,randomCheckRange);
        int vertical = (int) Random.Range (-randomCheckRange, randomCheckRange);

        // move to movepoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // move movepoint to valid spot
        if (Vector3.Distance(transform.position, movePoint.position) == 0f) {
            if (isLand == true) {    
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontal, vertical, 0f), radialSize, waterLayer)) {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontal, vertical, 0f), radialSize, border)) {

                        if (horizontal == -1) {
                            transform.localScale = new Vector3(-1f, 1f, 1f);
                        } else {
                            transform.localScale = new Vector3(1f, 1f, 1f);
                        }

                        movePoint.position += new Vector3(horizontal, vertical, 0f);
                    }
                }
            } else {
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontal, vertical, 0f), radialSize, waterLayer)) {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontal, vertical, 0f), radialSize, border)) {

                        if (horizontal == -1) {
                            transform.localScale = new Vector3(-1f, 1f, 1f);
                        } else {
                            transform.localScale = new Vector3(1f, 1f, 1f);
                        }

                        movePoint.position += new Vector3(horizontal, vertical, 0f);
                    }
                }
            }
        }
    }
    /*
    * Draws red circle hitbox for movepoint for above method
    */

    /*
    0 = dead
    1 = sick
    2 = okay

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
    public static int  NewRandomNumber(int min, int max)
    {
        int randomNumber;
        randomNumber = Random.Range(min, max);
        return randomNumber;
    }
}
