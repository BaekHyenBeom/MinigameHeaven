using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public Animator animator;

    public float ropeSpeedMultiplier;

    private readonly int hashRopeSpeed = Animator.StringToHash("RopeSpeed");

    private void Start()
    {
        StartCoroutine(CurSpeedChange());
    }
    private IEnumerator CurSpeedChange()
    {
        while (true)
        {
            int curSpeedNum = Random.Range(0, 3);

            switch (curSpeedNum)
            {
                case 0: ropeSpeedMultiplier = 0.75f; Debug.Log("����"); break;
                case 1: ropeSpeedMultiplier = 1.0f; Debug.Log("����"); break;
                case 2: ropeSpeedMultiplier = 1.3f; Debug.Log("����"); break;
                default: ropeSpeedMultiplier = 1.0f; Debug.Log("����"); break;
            }

            animator.SetFloat(hashRopeSpeed, ropeSpeedMultiplier);
            yield return new WaitForSeconds(8.0f);
        }
    }


}
