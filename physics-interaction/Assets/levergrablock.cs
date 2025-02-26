using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HingeGrabInteractable : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    private Rigidbody rb;
    private HingeJoint hinge;
    private RigidbodyConstraints originalConstraints;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();

        // Store original constraints
        originalConstraints = rb.constraints;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Ensure it's physics-based
        rb.useGravity = true;

        // Lock position but allow rotation (only freeze position)
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // Restore original constraints
        rb.constraints = originalConstraints;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase) //
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected && firstInteractorSelecting != null)
        {
            // Get hand position relative to the lever's hinge
            Vector3 handPosition = firstInteractorSelecting.transform.position;
            Vector3 leverPosition = transform.position;

            // Determine force direction relative to the hinge
            Vector3 forceDirection = (handPosition - leverPosition).normalized;

            // Apply torque around the hinge axis (Z-axis is common for levers)
            rb.AddTorque(transform.forward * Vector3.Dot(forceDirection, transform.right) * 10f, ForceMode.Force);
        }
    }
}
