using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction playerContolls;
    Vector2 moveDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerContolls.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        playerContolls.Enable();
    }

    private void OnDisable()
    {
        playerContolls.Disable();
    }
}
