using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    RaycastHit2D hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Get the Position of the Object
        Vector3 objectPosition = transform.position;

        //Jump over one block
        if (Input.GetButton("Jump"))
        {
            //Move Horizontal (Left and Right)
            if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
            {
                //Move Right
                objectPosition.x = objectPosition.x + 3.20f;

                //Cast a raycast infront of the object, if hit don't move
                hit = Physics2D.Raycast(objectPosition, Vector3.forward);
                if (hit)
                {
                  //Don't Jump
                }
                else
                {
                    //Move to new Position
                    transform.position = objectPosition;
                }

            }
            else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
            {
                //Move Left
                objectPosition.x = objectPosition.x - 3.20f;
                hit = Physics2D.Raycast(objectPosition, Vector3.forward);
                if (hit)
                {
                    //Don't Jump
                }
                else
                {
                    //Move to new Position
                    transform.position = objectPosition;
                }
            }

            //Move Vertical (Up and Down)
            if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
            {
                //Move Up
                objectPosition.y = objectPosition.y + 3.20f;
                hit = Physics2D.Raycast(objectPosition, Vector3.forward);
                if (hit)
                {
                   //Don't Jump
                }
                else
                {
                    //Jump to new Position
                    transform.position = objectPosition;
                }

            }
            else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
            {
                objectPosition.y = objectPosition.y - 3.20f;
                hit = Physics2D.Raycast(objectPosition, Vector3.forward);
                if (hit)
                {
                   //Don't Move
                }
                else
                {
                    //Jump to new Position
                    transform.position = objectPosition;
                }

            }

        }


        //Move Horizontal (Left and Right)
        if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) 
        {
            //Move Right
            objectPosition.x = objectPosition.x + 3.20f;

            //Cast a raycast infront of the object, if hit don't move
            hit = Physics2D.Raycast(objectPosition, Vector3.forward);
            if (hit)
            {
                //If the object infront can be moved, move both
                if(MovingTest(hit, 1))
                {
                 transform.position = objectPosition;
                }

            } else
            {
                //Move to new Position
                transform.position = objectPosition;
            }
            

        } else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) {
            //Move Left
            objectPosition.x = objectPosition.x - 3.20f;
            hit = Physics2D.Raycast(objectPosition, Vector3.forward);
            if (hit)
            {
                //If the object infront can be moved, move both
                if (MovingTest(hit, 3))
                {
                    transform.position = objectPosition;
                }

            }
            else
            {
                //Move to new Position
                transform.position = objectPosition;
            }
        }

        //Move Vertical (Up and Down)
        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            //Move Up
            objectPosition.y = objectPosition.y + 3.20f;
            hit = Physics2D.Raycast(objectPosition, Vector3.forward);
            if (hit)
            {
                //If the object infront can be moved, move both
                if (MovingTest(hit, 0))
                {
                    transform.position = objectPosition;
                }

            }
            else
            {
                //Move to new Position
                transform.position = objectPosition;
            }

        }
        else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            objectPosition.y = objectPosition.y - 3.20f;
            hit = Physics2D.Raycast(objectPosition, Vector3.forward);
            if (hit)
            {
                //If the object infront can be moved, move both
                if (MovingTest(hit, 2))
                {
                    transform.position = objectPosition;
                }

            }
            else
            {
                //Move to new Position
                transform.position = objectPosition;
            }

        }

    }

    //UP = 0, RIGHT = 1, DOWN = 2, LEFT = 3 Checks if the object in front ot the Player can be moved
    public bool MovingTest (RaycastHit2D hit, int direction)
    {
        //Store the found object in a Variable
        GameObject foundObject = hit.collider.gameObject;
        //Store the Position of the found object
        Vector3 thePosition = foundObject.transform.position;
        //Variable for recalculating and raycast testing
        Vector3 theNewPosition = thePosition;

        if (hit.transform.tag == "Movable_Object") 
        {
            switch (direction)
            {
                case 0:
                    //Cast a raycast to the new position of the moving block, if something is there, don't move
                    theNewPosition.y = theNewPosition.y + 3.20f;
                    hit = Physics2D.Raycast(theNewPosition, Vector3.forward);

                    //If is something in the way, don't move one of the objects
                    if (hit)
                    {
                        //Don't Move
                        return (false);
                    
                    //Otherwise move both objects
                    } else
                    {
                        thePosition.y = thePosition.y + 3.20f;
                        foundObject.transform.position = thePosition;
                    }
                   break;

                case 1:
                    //Cast a raycast to the new position of the moving block, if something is there, don't move
                    theNewPosition.x = theNewPosition.x + 3.20f;
                    hit = Physics2D.Raycast(theNewPosition, Vector3.forward);

                    //If is something in the way, don't move one of the objects
                    if (hit)
                    {
                        //Don't Move
                        return (false);

                    //Otherwise move both objects
                    }
                    else
                    {
                        thePosition.x = thePosition.x + 3.20f;
                        foundObject.transform.position = thePosition;
                    }
                   break;

                case 2:
                    //Cast a raycast to the new position of the moving block, if something is there, don't move
                    theNewPosition.y = theNewPosition.y - 3.20f;
                    hit = Physics2D.Raycast(theNewPosition, Vector3.forward);

                    //If is something in the way, don't move one of the objects
                    if (hit)
                    {
                        //Don't Move
                        return (false);

                        //Otherwise move both objects
                    }
                    else
                    {
                        thePosition.y = thePosition.y - 3.20f;
                        foundObject.transform.position = thePosition;
                    }
                   break;

                case 3:
                    //Cast a raycast to the new position of the moving block, if something is there, don't move
                    theNewPosition.x = theNewPosition.x - 3.20f;
                    hit = Physics2D.Raycast(theNewPosition, Vector3.forward);

                    //If is something in the way, don't move one of the objects
                    if (hit)
                    {
                        //Don't Move
                        return (false);

                        //Otherwise move both objects
                    }
                    else
                    {
                        thePosition.x = thePosition.x - 3.20f;
                        foundObject.transform.position = thePosition;
                    }
                   break;
            }
            return (true);
        } else
        {
            return (false);
        }
       
    }
  }

