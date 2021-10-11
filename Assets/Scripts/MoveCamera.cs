using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject player;

    void Update() {
        transform.position = player.transform.position;
    }
}