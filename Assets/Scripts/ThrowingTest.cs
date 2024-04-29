using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingTest : MonoBehaviour
{
    [Header("References")] 
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    public Rigidbody dart;

    [Header("Settings")] 
    public int totalThrows;
    public float throwCooldown;
    
    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey))
            dart.velocity = transform.right * 2 + transform.forward * .18f + transform.up * 0.31f;
        /*if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }*/
    }

    void Throw()
    {
        readyToThrow = false;
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;
        projectileRigidbody.AddForce(forceToAdd, ForceMode.Impulse);
        totalThrows--;
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    void ResetThrow()
    {
        readyToThrow = true;
    }
}
