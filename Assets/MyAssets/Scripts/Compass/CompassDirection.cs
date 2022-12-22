using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassDirection : MonoBehaviour
{
    public CompassManager compassManager;

    private Transform target;
    private Vector3 initialRotation;

    private void Awake()
    {
        initialRotation = transform.localEulerAngles;
    }

    void Update()
    {
        if (target == null) return;

        var lookPos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookPos, transform.up);
        transform.localEulerAngles = new Vector3(initialRotation.x, transform.localEulerAngles.y, initialRotation.z);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        compassManager.ShowButton();
    }

    public void RemoveTarget()
    {
        target = null;
        compassManager.HideButton();
    }
}
