using UnityEngine;
using System.Collections;

public class SpriteScaler : MonoBehaviour
{
    public float maxSize = 1.5f; // The maximum size multiplier
    public float minSize = 1f; // The minimum size multiplier
    public float duration = 3.0f; // Duration for one cycle of scaling up and down

    private Vector3 originalScale; // Original scale of the sprite

    private void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(ScaleOverTime());
    }

    private IEnumerator ScaleOverTime()
    {
        while (true)
        {
            // Scale up
            yield return ScaleToSize(maxSize, duration / 2);
            // Scale down
            yield return ScaleToSize(minSize, duration / 2);
        }
    }

    private IEnumerator ScaleToSize(float targetSizeMultiplier, float duration)
    {
        Vector3 targetScale = originalScale * targetSizeMultiplier;
        Vector3 scaleStart = transform.localScale;
        float time = 0f;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(scaleStart, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}