using System.Collections;
using UnityEngine;

public class EntryAnimation : MonoBehaviour
{
    public float startPosition = -315f;
    public float endPosition = -215f;
    public float animationDuration = 10f;
    public float decelerationDuration = 1f; // Durée de décélération à la fin

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

            // Calculate the interpolation factor using custom ease-out function
            float t = EaseOut(elapsedTime / animationDuration);

            // Interpolate between start and end positions
            float newPosition = Mathf.Lerp(startPosition, endPosition, t);

            // Update camera position on the Z-axis
            transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);

            yield return null;
        }

        // Animation is complete
        // Vous pouvez effectuer des actions supplémentaires ici si nécessaire

        // Désactiver le script après l'animation
        isAnimating = false;
    }

    // Fonction d'interpolation ease-out personnalisée
    float EaseOut(float x)
    {
        return 1f - Mathf.Pow(1f - x, 3);
    }
}
