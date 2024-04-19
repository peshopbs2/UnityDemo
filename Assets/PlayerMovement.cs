using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private float points = 0.0f;

    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private GameObject spawner;

    private Vector3 offset; //distance between player and camera

    void Start()
    {
        offset = camera.transform.position - transform.position;
    }

    public void IncreasePoints()
    {
        points++;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += movement * speed;

        ChangeCamera(transform);

        CheckGameOver();
    }

    private void ChangeCamera(Transform transform)
    {
        Vector3 targetCamPosition = transform.position + offset;
        camera.transform.position =
            Vector3.Lerp(camera.transform.position, targetCamPosition, 5f);
    }

    private void CheckGameOver()
    {
        var spheres = spawner.GetComponent<CollectItemsSpawner>().Spheres;
        if(spheres > 10)
        {
            Debug.Log("Game over!");
            gameObject.SetActive(false);
        }
    }
}
