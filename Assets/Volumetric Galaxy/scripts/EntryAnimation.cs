using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryAnimation : MonoBehaviour
{
    public float startPosition = -315f;
    public float endPosition = -215f;
    public float animationDuration = 3f;

    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Initial position
        transform.position = new Vector3(transform.position.x, transform.position.y, startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the interpolation factor (0 to 1)
        float t = Mathf.Clamp01(elapsedTime / animationDuration);

        // Use SmoothStep for smooth interpolation
        float smoothFactor = Mathf.SmoothStep(0f, 1f, t);

        // Interpolate between start and end positions
        float newPosition = Mathf.Lerp(startPosition, endPosition, smoothFactor);

        // Update camera position on the Z-axis
        transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);

        // Check if the animation is complete
        if (t >= 1.0f)
        {
            // Animation is complete, you may want to perform any additional actions here
        }
    }
}
