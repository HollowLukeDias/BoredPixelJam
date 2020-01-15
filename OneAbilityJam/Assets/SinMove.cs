using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(RandomMover());
    }

    IEnumerator RandomMover()
    {
        var t = 0f;
        while (true)
        {
            transform.position = new Vector2(Mathf.Sin(t), 0);
            t += Time.deltaTime;
            yield return 0;
        }
    }
}
