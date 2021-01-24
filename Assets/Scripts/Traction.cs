using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Traction : MonoBehaviour {

    public Vector3 traction;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Vector3 velocity = rb.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        localVelocity.Scale(Vector3.one - traction);
        rb.velocity = transform.TransformDirection(localVelocity);
    }
}