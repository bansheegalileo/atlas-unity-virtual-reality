using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TelekineticGrab : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    public Transform handTransform; // Corrected declaration
    public LazyLoadReference<GameObject> spot; // Specify the type

    public float maxDistance = 5f; // Maximum grabbing range
    public float forceMultiplier = 10f; // Strength of the pull
    public float minGrabSpeed = 5f; // Minimum pull speed
    public float maxGrabSpeed = 20f; // Maximum pull speed
    public LayerMask interactableLayer; // Layer for grabbable objects

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabbedObject;
    private Rigidbody grabbedRb;
    private bool isGrabbing = false;
    private float holdTime = 0f; // How long the button is held

    void Update()
    {
        if (isGrabbing && grabbedObject)
        {
            MoveObjectToHand();
        }
    }

    public void TryForceGrab()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.distance > maxDistance) return; // Ignore if too far
            
            if (hit.collider.TryGetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(out UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable interactable))
            {
                grabbedObject = interactable;
                grabbedRb = interactable.GetComponent<Rigidbody>();

                if (grabbedRb != null)
                {
                    grabbedRb.useGravity = false; // Disable gravity while pulling
                    isGrabbing = true;
                    holdTime = 0f;
                }
            }
        }
    }

    public void ReleaseGrab()
    {
        if (grabbedObject)
        {
            grabbedRb.useGravity = true;
            grabbedObject = null;
            grabbedRb = null;
        }
        isGrabbing = false;
    }

    private void MoveObjectToHand()
    {
        if (grabbedRb == null || grabbedObject == null) return;

        holdTime += Time.deltaTime;
        float pullSpeed = Mathf.Lerp(minGrabSpeed, maxGrabSpeed, holdTime / 2f); // Increasing force over time
        Vector3 direction = (handTransform.position - grabbedRb.position).normalized;

        grabbedRb.velocity = direction * pullSpeed;

        // Check if the object is close enough to the hand
        if (Vector3.Distance(grabbedRb.position, handTransform.position) < 0.2f)
        {
            AttachObjectToHand();
        }
    }

    private void AttachObjectToHand()
    {
        grabbedRb.velocity = Vector3.zero;
        grabbedRb.useGravity = false;

        grabbedObject.transform.position = handTransform.position;
        grabbedObject.transform.parent = handTransform;
        
        isGrabbing = false;
    }
}
