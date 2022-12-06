using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBillboard : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.current.transform);
    }
}
