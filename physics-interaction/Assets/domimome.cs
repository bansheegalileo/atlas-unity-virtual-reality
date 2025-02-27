using UnityEngine;

public class ApplyForceOnSelect : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
    private Transform forcePoint; // The point where force is applied

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        // Create an empty GameObject to act as the force application point
        forcePoint = new GameObject("ForcePoint").transform;
        forcePoint.SetParent(transform);

        // Position it at 75% of the object's height
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            Vector3 topPoint = col.bounds.center + new Vector3(0, col.bounds.extents.y * 0.75f, 0);
            forcePoint.position = topPoint;
        }
    }

    public void ApplyForce()
    {
        if (m_Rigidbody != null)
        {
            // Apply force forward from the offset point
            m_Rigidbody.AddForceAtPosition(-transform.right * m_Thrust, forcePoint.position, ForceMode.Impulse);
        }
    }
}
