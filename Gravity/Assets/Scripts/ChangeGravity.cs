using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

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
    public float acceleratedSpeed = 600;
    public bool flag = true;

    [SerializeField]
    private float startSpeed = 600;
    [SerializeField]
    public int maxSpeed = 800;

    [SerializeField]
    private CinemachineVirtualCamera cameraObj;

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
            SwitchCamera();
            ChangingGravity();
        }  
    }

    private void SwitchCamera()
    {
      //  Debug.LogError("aloooo");
        cameraObj.Priority = flag ? 0 : 2; 
    }

    private void IncreaseAcceleration()
    {
        if (acceleratedSpeed < maxSpeed)
        {
            acceleratedSpeed += acceleration * Time.deltaTime ;
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
                rb.AddForce(transform.up * acceleratedSpeed);
            }
        }
        else
        {

            foreach (Rigidbody rb in gravityChangable)
            {
                rb.useGravity = true;
                rb.AddForce(-transform.up * startSpeed);
            }
        }
        flag = !flag;
    }


}
