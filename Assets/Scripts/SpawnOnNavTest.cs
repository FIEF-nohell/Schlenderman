using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class SpawnOnNavTest : MonoBehaviour
{
    public int NumberOfSpawnables;
    public GameObject Motor;
    public GameObject Breadboard;
    public GameObject Sensor;
    public GameObject Arduino;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;
   
    void Start()
    {
        Manager();        
    }

    void Manager()
    {
        pos1 = GetRandomGameBoardLocation();
        pos2 = GetRandomGameBoardLocation();
        pos3 = GetRandomGameBoardLocation();
        pos4 = GetRandomGameBoardLocation();

        Instantiate(Motor, pos1, Quaternion.identity);
        Instantiate(Breadboard, pos2, Quaternion.identity);
        Instantiate(Sensor, pos3, Quaternion.identity);
        Instantiate(Arduino, pos4, Quaternion.identity);
    }
    
    private Vector3 GetRandomGameBoardLocation()    
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
 
        int maxIndices = navMeshData.indices.Length - 3;
 
        // pick the first indice of a random triangle in the nav mesh
        int firstVertexSelected = UnityEngine.Random.Range(0, maxIndices);
        int secondVertexSelected = UnityEngine.Random.Range(0, maxIndices);
 
        // spawn on verticies
        Vector3 point = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];
 
        Vector3 firstVertexPosition = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];
        Vector3 secondVertexPosition = navMeshData.vertices[navMeshData.indices[secondVertexSelected]];
 
        // eliminate points that share a similar X or Z position to stop spawining in square grid line formations
        if ((int)firstVertexPosition.x == (int)secondVertexPosition.x || (int)firstVertexPosition.z == (int)secondVertexPosition.z)
        {
            point = GetRandomGameBoardLocation(); // re-roll a position - I'm not happy with this recursion it could be better
        }
        else
        {
            // select a random point on it
            point = Vector3.Lerp(firstVertexPosition, secondVertexPosition, UnityEngine.Random.Range(0.05f, 0.95f));
        }

        Debug.DrawRay(point, point.forward * 10, Color.red, 103f);
        Debug.DrawRay(point, point.backwards * 10, Color.red, 103f);
        Debug.DrawRay(point, point.left * 10, Color.red, 103f);
        Debug.DrawRay(point, point.right * 10, Color.red, 103f);
        Debug.DrawRay(point, point.up * 10, Color.red, 103f);
        Debug.DrawRay(point, point.down * 10, Color.red, 103f);

        return point;
    }
}
