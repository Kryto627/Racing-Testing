using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Acceleration : MonoBehaviour {

    public float maxSpeed;
    public float acceleration;

    private Rigidbody rb;
    private float throttle;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        throttle = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        rb.AddForce(transform.forward * acceleration * throttle, ForceMode.Acceleration);

        Vector3 velocity = rb.velocity;
        if (velocity.magnitude > maxSpeed) {
            rb.velocity = velocity.normalized * maxSpeed;
        }
    }
}