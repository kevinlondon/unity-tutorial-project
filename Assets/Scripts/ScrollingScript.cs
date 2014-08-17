using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

// <summary> Parallax scrolling script for a layer. </summary>
public class ScrollingScript : MonoBehaviour {
    // <summary> Scrolling speed. </summary>
    public Vector2 speed = new Vector2(2, 2);

    // <summary> Moving direction. </summary>
    public Vector2 direction = new Vector2(-1, 0);

    // <summary> Movement should be applied to camera. </summary>
    public bool isLinkedToCamera = false;

    // <summary> Background is infinite. </summary>
    public bool isLooping = false;

    // <summary> List of children with a renderer.
    private List<Transform> backgroundPart;

    void Start()
    {
        // for infinite bg only
        if (isLooping)
        {
            // Get all the children of the layer with a renderer.
            backgroundPart = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Add only the visible children.
                if (child.renderer != null)
                {
                    backgroundPart.Add(child);
                }
            }

            // Sort by position.
            // Note: Get the children from left to right.
            // Need to add a few conditions to handle all the scrolling directions.
            backgroundPart = backgroundPart.OrderBy(
                t => t.position.x
            ).ToList();
        }
    }
    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(
            speed.x * direction.x,
            speed.y * direction.y,
            0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // Move the camera.
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        // Loop!
        if (isLooping)
        {
            // Get the first object.
            // The list is ordered from left (x pos) to right.
            Transform firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null)
            {
                // Check if the child is already partly before the camera.
                // Test the position first because isVisibleFrom is heavier.
                if (firstChild.position.x < Camera.main.transform.position.x)
                {
                    // If the child is already on the left,
                    // test if it's completely outside and should be recycled.
                    if (firstChild.renderer.isVisibleFrom(Camera.main) == false)
                    {
                        // Get the last child pos
                        Transform lastChild = backgroundPart.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

                        // Set position of recycled one to be after last child.
                        // Note: only work for horizontal scrolling currently.
                        firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

                        // Set the recycled child to the last position of the backgroundPart list
                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }
}
