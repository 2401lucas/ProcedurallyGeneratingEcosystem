using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public float radius;
    public float displayRadius = 1;

    public Vector2 regionSize;

    public int rejectionSamples = 30;
    public int dencity = 30;

    public GameObject tree;
    public LayerMask terrainMask;
    private List<Vector2> points;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckForPoints());
    }

    // Update is called once per frame
    IEnumerator CheckForPoints()
    {
        yield return new WaitForSeconds(2);

        points = PoissionDiskSampling.GeneratePoints(radius, regionSize, rejectionSamples, dencity);
        if (points != null)
        {
            foreach (var point in points)
            {
                if (Physics.Raycast(transform.position + new Vector3(point.x, 20, point.y), Vector3.down,
                    out RaycastHit hitInfo, 50))
                {
                    Instantiate(tree, hitInfo.transform.position, Quaternion.identity);
                }
            }
        }

        yield return null;
    }

    //void OnValidate()
    //{
    //    points = PoissionDiskSampling.GeneratePoints(radius, regionSize, rejectionSamples, dencity);
    //}

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position + new Vector3(regionSize.x/2, 0, regionSize.y/2), new Vector3(regionSize.x, 0, regionSize.y));
    //    if (points != null)
    //    {
    //        foreach (var point in points)
    //        {
    //            Gizmos.DrawSphere(transform.position + new Vector3(point.x, 0, point.y), displayRadius);
    //        }
    //    }
    //}
}
