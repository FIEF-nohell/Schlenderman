using UnityEngine;
public class CollectionLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            UIController.nummer++;
        }
    }
}
