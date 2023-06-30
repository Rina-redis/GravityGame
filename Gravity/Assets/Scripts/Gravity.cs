using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject cameraObj;
    public float rotationSpeed;
    private Quaternion upRotation;
    private Quaternion downRotation;
    private int flag = -1;

    private void Start()
    {
        downRotation = cameraObj.transform.rotation;
        upRotation = Quaternion.Euler(-30f, cameraObj.transform.rotation.eulerAngles.y, cameraObj.transform.rotation.eulerAngles.z);
    }

    // Коротше, нам не треба міняти гравітацію для кожного конкретного об'єкта, тому можна просто змінити їй напрям
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Click");
            ReverseGravity();
            flag = -flag;
        }
        
    }

    private void FixedUpdate()
    {
        if (flag == 1)
            cameraObj.transform.rotation = Quaternion.Slerp(cameraObj.transform.rotation, upRotation, rotationSpeed * Time.deltaTime);
        else
            cameraObj.transform.rotation = Quaternion.Slerp(cameraObj.transform.rotation, downRotation, rotationSpeed * Time.deltaTime);
    }

    void ReverseGravity() => Physics.gravity *= -1;
}
