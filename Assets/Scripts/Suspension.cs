using UnityEngine;

public class Suspension : MonoBehaviour {

    public PIDController controller;
    public float distance;
    public float power;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate() {

        Ray ray = GetRay();

        if (Physics.Raycast(ray, out var hit, distance)) {

            float compression = distance - hit.distance;

            Vector3 force = Vector3.up * power * controller.Update(compression);

            rb.AddForceAtPosition(force, transform.position);
        }
    }

    private Ray GetRay() {
        return new Ray(transform.position, -transform.up);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Ray ray = GetRay();
        Gizmos.DrawLine(ray.origin, ray.GetPoint(distance));
    }
}