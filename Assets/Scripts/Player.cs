using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CanonController))]
public class Player : Alive
{

    public float mvtSpeed = 10;
    PlayerController controller;
    Camera view;
    CanonController canonController;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        controller = GetComponent<PlayerController>();
        view = Camera.main;
        canonController = GetComponent<CanonController>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT INPUT
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * mvtSpeed;
        controller.Move(moveVelocity);

        //LOOK INPUT
        Ray ray = view.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDist;

        if (groundPlane.Raycast(ray, out rayDist)) {
            Vector3 intersect = ray.GetPoint(rayDist);
            //Debug.DrawLine(ray.origin, intersect, Color.red);
            controller.LookAt(intersect);
        }

        //WEAPON INPUT
        if (Input.GetMouseButton(0))
        {
            canonController.Shoot();
        }
    }
}
