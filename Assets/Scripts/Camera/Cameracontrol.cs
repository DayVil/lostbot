using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private readonly Manager _manager = Manager.GetInstance;
    private Vector3 worldContainerPosition;
    public float cameraSpeed;

    void Start()
    {
        worldContainerPosition = transform.position;
    }

    void Update()
    {
        if (_manager.StartGame)
        {
            return;
        }

        // if (Input.GetKey(KeyCode.W))
        // {
        //     worldContainerPosition.y += cameraSpeed / 10;
        // }

        // if (Input.GetKey(KeyCode.S))
        // {
        //     worldContainerPosition.y -= cameraSpeed / 10;
        // }

        if (Input.GetKey(KeyCode.D))
        {
            worldContainerPosition.x -= cameraSpeed / 10;
        }

        if (Input.GetKey(KeyCode.A))
        {
            worldContainerPosition.x += cameraSpeed / 10;
        }

        transform.position = worldContainerPosition;
    }
}
