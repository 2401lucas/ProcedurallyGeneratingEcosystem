using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(MoveToPosition(transform, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), 0.5f));
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}
