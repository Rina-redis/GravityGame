using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController character;

    public float speed = 6f;

    private void Start()
    {
        character = this.GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3 (horizontal, 0f, vertical);

       // if(direction.magnitude >= 0.1f)
       // {
            character.Move(direction * speed * Time.deltaTime);
      //  }
    }
}
