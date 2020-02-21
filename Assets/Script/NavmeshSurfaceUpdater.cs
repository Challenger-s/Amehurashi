using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(-103)]
public class NavmeshSurfaceUpdater : MonoBehaviour
{
    NavMeshSurface surface;

    void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        StartCoroutine(TimeUpdate());
    }

    IEnumerator TimeUpdate()
    {
        while (true)
        {
            surface.BuildNavMesh();
            Debug.Log("update");

            yield return new WaitForSeconds(5.0f);
        }
    }

}