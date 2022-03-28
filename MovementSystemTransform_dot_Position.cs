using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private Controls control;

    //Control variables
    [Space]
    // private Vector2 movementInputs;
    // private Vector2 mouseInputs;
    public float speed;

    private Vector3 newpos;

    private void OnEnable() {
        control.Enable();
    }

    private void OnDisable() {
        control.Disable();
    }
    
    void Awake() {
        control = new Controls();
        Debug.Log("Control System Loaded" + control);
    }

    void Update() {
        Vector2 movementInputs = control.Movement.Moving.ReadValue<Vector2>();
        Vector2 mouseInputs = control.Movement.Look.ReadValue<Vector2>();

        Debug.Log(movementInputs + ";" + mouseInputs);

        transform.position = newpos;
        newpos = transform.position;
        newpos.x += movementInputs.x * Time.deltaTime * speed;
        newpos.z += movementInputs.y * Time.deltaTime * speed;
    }
}
