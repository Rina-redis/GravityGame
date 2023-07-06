using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputHandler))]
public class CharacterMover : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private Camera Camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = new Vector3(RotateFromMouseVector().x - transform.position.x, transform.position.y, RotateFromMouseVector().z - transform.position.z);

        MoveTowardTarget(movementVector * targetVector.z);

        Debug.Log(targetVector.x+ " "+ targetVector.y + " " + targetVector.z);
        Debug.Log(movementVector.x + " " + movementVector.y + " " + movementVector.z);


        if (!RotateTowardMouse)
        {
           // RotateTowardMovementVector(movementVector);
        }
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();    
            
        }

    }

    private Vector3 RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            Debug.Log(hitInfo.point);
            target.y = transform.position.y;
            transform.LookAt(target);
            return target;
        }
        return Vector3.zero;
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
       // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); //Demonstrate why this doesn't work
       // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

       // targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;

        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;


        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
}
