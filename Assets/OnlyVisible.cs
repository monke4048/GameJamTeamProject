using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// tilemap
using UnityEngine.Tilemaps;
// camera
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class OnlyVisible : MonoBehaviour
{
    // This module display on the screen only the parts of the tilemap that are in the camera view.
    // It is useful to avoid to draw the tilemap when it is not visible.

    // The tilemap to display
    public Tilemap tilemap;
    // The camera to use
    public Camera camera;
    // The camera position
    private Vector3 cameraPosition;
    // The camera size
    private Vector2 cameraSize;
    // The camera bounds
    private BoundsInt cameraBounds;
    // The tilemap bounds
    private BoundsInt tilemapBounds;
    // The tilemap position
    private Vector3Int tilemapPosition;
    // The tilemap size
    private Vector3Int tilemapSize;
    // The tilemap position in the camera bounds
    private Vector3Int tilemapPositionInCameraBounds;

    // Start is called before the first frame update
    void Start()
    {
        // Get the camera position
        cameraPosition = camera.transform.position;
        // Get the camera size (float to vector2)
        cameraSize = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);
        // Get the camera bounds
        cameraBounds = new BoundsInt(
            new Vector3Int(
                Mathf.FloorToInt(cameraPosition.x - cameraSize.x / 2),
                Mathf.FloorToInt(cameraPosition.y - cameraSize.y / 2),
                0
            ),
            new Vector3Int(
                Mathf.CeilToInt(cameraSize.x),
                Mathf.CeilToInt(cameraSize.y),
                1
            )
        );
        // Get the tilemap position
        tilemapPosition = tilemap.origin;
        // Get the tilemap size
        tilemapSize = tilemap.size;
        // Get the tilemap bounds
        tilemapBounds = new BoundsInt(
            tilemapPosition,
            tilemapSize
        );
        // Get the tilemap position in the camera bounds
        tilemapPositionInCameraBounds = new Vector3Int(
            Mathf.Max(tilemapPosition.x, cameraBounds.xMin),
            Mathf.Max(tilemapPosition.y, cameraBounds.yMin),
            0
        );
        // Set the tilemap position
        tilemap.SetTilemapPosition(tilemapPositionInCameraBounds);
        // Set the tilemap size
        tilemap.SetTilemapSize(new Vector3Int(
            Mathf.Min(tilemapPosition.x + tilemapSize.x, cameraBounds.xMax) - tilemapPositionInCameraBounds.x,
            Mathf.Min(tilemapPosition.y + tilemapSize.y, cameraBounds.yMax) - tilemapPositionInCameraBounds.y,
            1
        ));
    }


    // Update is called once per frame
    void Update()
    {
        // Get the camera position
        cameraPosition = camera.transform.position;
        // Get the camera size
        cameraSize = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);
        // Get the camera bounds
        cameraBounds = new BoundsInt(
            new Vector3Int(
                Mathf.FloorToInt(cameraPosition.x - cameraSize.x / 2),
                Mathf.FloorToInt(cameraPosition.y - cameraSize.y / 2),
                0
            ),
            new Vector3Int(
                Mathf.CeilToInt(cameraSize.x),
                Mathf.CeilToInt(cameraSize.y),
                1
            )
        );
        // Get the tilemap position
        tilemapPosition = tilemap.origin;
        // Get the tilemap size
        tilemapSize = tilemap.size;
        // Get the tilemap bounds
        tilemapBounds = new BoundsInt(
            tilemapPosition,
            tilemapSize
        );
        // Get the tilemap position in the camera bounds
        tilemapPositionInCameraBounds = new Vector3Int(
            Mathf.Max(tilemapPosition.x, cameraBounds.xMin),
            Mathf.Max(tilemapPosition.y, cameraBounds.yMin),
            0
        );
        // Set the tilemap position
        tilemap.SetTilemapPosition(tilemapPositionInCameraBounds);
        // Set the tilemap size
        tilemap.SetTilemapSize(new Vector3Int(
            Mathf.Min(tilemapPosition.x + tilemapSize.x, cameraBounds.xMax) - tilemapPositionInCameraBounds.x,
            Mathf.Min(tilemapPosition.y + tilemapSize.y, cameraBounds.yMax) - tilemapPositionInCameraBounds.y,
            1
        ));
    }

}

public static class TilemapExtensions
{
    public static void SetTilemapPosition(this Tilemap tilemap, Vector3Int position)
    {
        tilemap.origin = position;
    }

    public static void SetTilemapSize(this Tilemap tilemap, Vector3Int size)
    {
        tilemap.size = size;
    }
}
