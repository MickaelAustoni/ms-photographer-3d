using System.Collections;
using UnityEngine;

public class EntryAnimation : MonoBehaviour
{
    public float startPosition = -315f;
    public float endPosition = -215f;
    public float animationDuration = 3f;

    private bool isAnimating = true; // Animation active par défaut

    void Start()
    {
        StartCoroutine(AnimateCamera());
    }

    IEnumerator AnimateCamera()
    {
        // Initial position
        transform.position = new Vector3(transform.position.x, transform.position.y, startPosition);

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
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

            yield return null;
        }

        // Animation is complete
        // Vous pouvez effectuer des actions supplémentaires ici si nécessaire

        // Désactiver le script après l'animation
        isAnimating = false;
    }
}
