using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Steering : MonoBehaviour {

    public float steeringSpeed;

    private Rigidbody rb;
    private float steering;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        steering = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0F, steering * steeringSpeed * Time.fixedDeltaTime, 0F));
    }
}