using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private Controls control;

    private Rigidbody rb;

    private ConstantForce cf;

    //Control variables
    [Space]
    // private Vector2 movementInputs;
    // private Vector2 mouseInputs;
    public float speed;


    private void OnEnable() {
        control.Enable();
    }

    private void OnDisable() {
        control.Disable();
    }
    
    void Awake() {
        control = new Controls();
        Debug.Log("Control System Loaded" + control);
        rb = GetComponent<Rigidbody>();
        cf = GetComponent<ConstantForce>();
    }

    void Update() {
        Vector2 movementInputs = control.Movement.Moving.ReadValue<Vector2>() * speed * Time.deltaTime;
        Vector2 mouseInputs = control.Movement.Look.ReadValue<Vector2>() * speed * Time.deltaTime;

        Debug.Log(movementInputs + ";" + mouseInputs);

        cf.force = new Vector3(movementInputs.x, 0, movementInputs.y);
    }
}
