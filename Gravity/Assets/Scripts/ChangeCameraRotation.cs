using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraRotation : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cinemacineVirtualCamera;

    public float rotationSpeed;
    private Vector3 downRotation;
    CinemachineFramingTransposer framingTransposer;
    private bool flag = true;

    private void Awake()
    {
         framingTransposer = cinemacineVirtualCamera.GetComponentInChildren<CinemachineFramingTransposer>();
        if(framingTransposer == null)
        {
            Debug.LogWarning("nema");
        }
         downRotation = framingTransposer.m_TrackedObjectOffset;
      //   upRotation = new Vector3(0, 5.13f, 0);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
          if (flag == true)
            {
               // framingTransposer.m_TrackedObjectOffset = upRotation;           
            }
            else
            {
                framingTransposer.m_TrackedObjectOffset = downRotation;              
            }
            flag = !flag;
        }
    }


}
