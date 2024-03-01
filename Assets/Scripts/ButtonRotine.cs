using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRotine : MonoBehaviour
{
    public void StartRoutine()
    {
        StartCoroutine(Routine());
    }

    public IEnumerator Routine()
    {
        yield return new WaitForSeconds(1);
    }
}
