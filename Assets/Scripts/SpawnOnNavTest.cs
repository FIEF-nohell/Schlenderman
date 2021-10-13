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
    public Vector3[] positionArray;
   
    void Start()
    {
        Manager();        
    }

    void Manager()
    {
        for(int i = 0; i < NumberOfSpawnables; i++){
            positionArray[i] = GetRandomGameBoardLocation();
            Debug.Log(positionArray[i]);
        }

        Instantiate(Motor, positionArray[0], Quaternion.identity);
        Instantiate(Breadboard, positionArray[1], Quaternion.identity);
        Instantiate(Sensor, positionArray[2], Quaternion.identity);
        Instantiate(Arduino, positionArray[3], Quaternion.identity);
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

        return point;
    }
}
