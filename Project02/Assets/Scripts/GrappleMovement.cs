using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 75f;

    private DistanceJoint2D joint;
    private HingeJoint2D hingeJoint;
    private Vector3 mousePosition;
    private RaycastHit2D hit;
    public float maxDistance;
    public LayerMask mask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
    }

    void Update()
    {
        //Grapples to sticky surfaces when M1 buttton is held down.
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            hit = Physics2D.Raycast(transform.position, mousePosition-transform.position, maxDistance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
        }
    }
}
