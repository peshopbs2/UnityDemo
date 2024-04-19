using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{ 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            other.gameObject.GetComponent<PlayerMovement>().IncreasePoints();
            GameObject.Find("Spawner").GetComponent<CollectItemsSpawner>()
                .DecreaseSpheres();
        }
    }
}
