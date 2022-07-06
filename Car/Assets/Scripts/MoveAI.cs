using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI : MonoBehaviour  // yapay zeka di�er arabalar�n hareketi...
{
    [SerializeField]
    CarController carController;

    int index = 0; // transform u 0'dan ba�latmam�za yar�yor.
    Transform target;

    [SerializeField]
    List<Transform> waypoints; // ara noktalar.

    private void Start()
    {
        target = waypoints[0];
    }

    private void FixedUpdate()
    {
       /* if(!GameState.canMove)        // sonradan kameray� ekleyince yorum sat�r�na �evirdik.
        {
            return;
        }  */


        // pozisyonlar�n�  bakmak
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), Random.Range(10,20)*Time.fixedDeltaTime); // harekete ba�lanmas�. // Random olarak 10 ile 20 aras� atama yapcak

        if(transform.position.x ==target.position.x && transform.position.z ==target.position.z)
        {
            if(index < waypoints.Count - 1 )  // index'in  ara noktalardan k���k -1 olacak..
            {
                index++;
            }
            else
            {
                if(GameState.leverIndex == 2)
                {
                    index = 0;
                }
            }
            target = waypoints[index];
        }
    }
   
}
