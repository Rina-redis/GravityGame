using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    private List<Rigidbody> gravityChangable = new List<Rigidbody>();

    public int koef = 1;
    public bool flag = true;

    private void Start()
    {
        RefreshGravityObjects();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            if (flag)
            {
              //  Debug.Log("Click");
                foreach (Rigidbody rb in gravityChangable)
                {          
                    rb.useGravity = false;
                    rb.AddForce(transform.up * koef);
                }                       
            }
            else
            {

                foreach (Rigidbody rb in gravityChangable)
                {
                   // Rigidbody rb = obj.GetComponent<Rigidbody>();
                   // rb.useGravity = true;
                    rb.AddForce(-transform.up * koef);
                }
            }
            flag = !flag;

        }  
    }

    private void RefreshGravityObjects()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GravityChangable"))
        {
            gravityChangable.Add(obj.GetComponent<Rigidbody>());
        }
    }
}
