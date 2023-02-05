using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlatform : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
         transform.Rotate (new Vector3 (0, 0, 20) * Time.deltaTime);
    }
}
