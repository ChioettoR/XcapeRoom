using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassDirection : MonoBehaviour
{
    public Transform target;

    private Vector3 initialRotation;

    private void Awake()
    {
        initialRotation = transform.localEulerAngles;
    }

    void Update()
    {
        var lookPos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookPos, transform.up);
        transform.localEulerAngles = new Vector3(initialRotation.x, transform.localEulerAngles.y, initialRotation.z);
    }
}
