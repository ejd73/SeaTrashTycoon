using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cameraController : MonoBehaviour
{
    public Transform target;
    private Tilemap tilemap; // Reference to your tilemap
    private float minX, maxX, minY, maxY; // Boundaries for camera movement

    void Start()
    {
        // Get the Tilemap component from the tilemap_base GameObject
        tilemap = GameObject.Find("tilemap_base").GetComponent<Tilemap>();
        
        // Calculate the boundaries based on the tilemap's bounds
        BoundsInt bounds = tilemap.cellBounds;
        Vector3 min = tilemap.CellToWorld(bounds.min);
        Vector3 max = tilemap.CellToWorld(bounds.max);

        minX = min.x;
        maxX = max.x;
        minY = min.y;
        maxY = max.y;

        // Adjust boundaries by camera's orthographic size
        Camera cam = Camera.main; // Get the main camera
        float camHeight = cam.orthographicSize; // Get the orthographic size (half the height)
        float camWidth = camHeight * cam.aspect; // Calculate the width based on the aspect ratio

        minX += camWidth; // Adjust minX
        maxX -= camWidth; // Adjust maxX
        minY += camHeight; // Adjust minY
        maxY -= camHeight; // Adjust maxY
    }

    void Update()
    {
        // Calculate the new position
        float newX = Mathf.Clamp(target.position.x, minX, maxX);
        float newY = Mathf.Clamp(target.position.y, minY, maxY);

        // Set the camera position, preserving the original z-coordinate
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
