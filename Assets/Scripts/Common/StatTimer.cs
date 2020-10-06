using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTimer : MonoBehaviour
{
    public float timerstat = 0;

    void Update()
    {
        timerstat += Time.deltaTime;
    }
}
