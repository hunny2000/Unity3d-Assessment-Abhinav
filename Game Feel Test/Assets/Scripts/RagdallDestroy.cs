using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdallDestroy : MonoBehaviour
{
    public float waitTime = 4f;
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
