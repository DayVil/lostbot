using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ParallaxBackground : MonoBehaviour
{
    private readonly Manager _manager = Manager.GetInstance;
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;
    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_manager.StartGame)
        {
            float temp = (cam.transform.position.x * (1 - parallaxEffect));
            float dist = (cam.transform.position.x * parallaxEffect);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

            // Adjust for tilemap size
            if (tilemap != null)
            {
                TilemapRenderer tilemapRenderer = tilemap.GetComponent<TilemapRenderer>();
                float tileSizeX = tilemapRenderer.bounds.size.x / tilemap.cellBounds.size.x;

                if (temp > startpos + tileSizeX)
                {
                    startpos += tileSizeX;
                }
                else if (temp < startpos - tileSizeX)
                {
                    startpos -= tileSizeX;
                }
            }
        }
    }
}
