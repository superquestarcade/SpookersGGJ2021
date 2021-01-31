using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSomTime : MonoBehaviour
{
    public float WhatTimeMate = 2f;
    private void OnEnable()
    {
        StartCoroutine(Hey());
    }

    IEnumerator Hey()
    {
        yield return new WaitForSeconds(WhatTimeMate);
        this.gameObject.SetActive(false);
    }
}
