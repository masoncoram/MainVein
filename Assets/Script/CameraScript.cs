using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public float distance = 4;
    public GameObject player;


    private float fuckThis;

    private Vector3 offset;
	private float difference;
 


    void Start()
    {

       offset = transform.position - player.transform.position;

    }


    void Update()
    {
        

        if(Mathf.Abs(player.transform.position.x - transform.position.x) > distance)
        {
			difference = player.transform.position.x - transform.position.x;
			fuckThis = (Mathf.Abs (difference) - distance) * Mathf.Pow(((Mathf.Abs(difference) - distance) / distance),4) * Mathf.Sign (difference);
            //fuckThis = (Mathf.Sign(difference) * distance - Mathf.Pow(((Mathf.Abs(player.transform.position.x - transform.position.x)-distance)/distance),2));
            transform.position = new Vector3(transform.position.x + fuckThis, transform.position.y, transform.position.z);
        }


    }
}
//(Mathf.Abs(player.transform.position.x - transform.position.x) -      ) / maxDistance



/*
 * 
           fuckThis = (Mathf.Sign(player.transform.position.x - transform.position.x) * distance);
           transform.position = new Vector3(player.transform.position.x - fuckThis, transform.position.y, transform.position.z);
 * 
 * 
 * 
 * 
 */
