using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    private float acceleration = 9.81f;
    public enum State
    {
        IsFly,
        IsStand
    }

    private List<Rigidbody> gravityChangable = new List<Rigidbody>();

    //public only for debug
    public State currentState = State.IsStand;
    public float currentSpeed = 600;
    public bool flag = true;

    [SerializeField]
    private float startSpeed = 600;
    [SerializeField]
    public int maxSpeed = 800;

    [SerializeField]
    private  GameObject cameraObj;

    private void Start()
    {
        RefreshGravityObjects();
    }

    void Update()
    {
        if (currentState == State.IsFly)
        {
            IncreaseAcceleration();
        }


        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            currentState = State.IsFly;
            ChangingGravity();
        }  
    }

    private void IncreaseAcceleration()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime ;
        } 
    }

    private void RefreshGravityObjects()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GravityChangable"))
        {
            gravityChangable.Add(obj.GetComponent<Rigidbody>());
        }
    }

    private void ChangingGravity()
    {
        if (flag)
        {
            foreach (Rigidbody rb in gravityChangable)
            {   
                rb.useGravity = false;
                rb.AddForce(transform.up * currentSpeed);
            }
        }
        else
        {

            foreach (Rigidbody rb in gravityChangable)
            {
                rb.AddForce(-transform.up * currentSpeed);
            }
        }
        flag = !flag;
    }


}
