using System.Collections;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    /// <summary>
    /// Holds all static methods for visual FX.
    /// I don't like using start coroutine if the coroutine doesn't exist in the class.
    /// </summary>

    //[Header("Camera")]
    //[SerializeField] Transform camTransform;
    //[SerializeField] AnimationCurve cameraShakeCurve;

    static VFXManager instance;

    void Start()
    {
        instance = this;
    }

    //#region Camera
    //// Method to call camshake coroutine.
    //public static void ShakeCamera(float duration)
    //{
    //    instance.StartCoroutine(instance.ShakeCameraRoutine(duration));
    //}

    //// Coroutine to shake camera in random direction for duration seconds.
    //IEnumerator ShakeCameraRoutine(float duration)
    //{
    //    Vector2 startPos = camTransform.position;

    //    float elapsedTime = 0f;

    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;

    //        // Create multiplier based on animation curve.
    //        float shakeMultiplier = cameraShakeCurve.Evaluate(elapsedTime / duration);

    //        // Shake X and Y axis without affecting the z axis.
    //        Vector2 shakePos = startPos + Random.insideUnitCircle * shakeMultiplier;
    //        camTransform.position = new Vector3(shakePos.x, shakePos.y, -10);

    //        yield return null;
    //    }

    //    // Reset position after shaking.
    //    camTransform.position = new Vector3(startPos.x, startPos.y, -10);
    //}

    //#endregion

    #region Sprite Colour
    // Method to start coroutine for damage flash
    public static void FlashRed(SpriteRenderer spr, float duration)
    {
        // Stop current coroutine
        instance.StopCoroutine(instance.FlashRedRoutine(spr, duration));

        // Start/Renew the new one.
        instance.StartCoroutine(instance.FlashRedRoutine(spr, duration));
    }

    // Currently only works for sprites with colour white. Had issue if multiple coroutines ran at a time.
    IEnumerator FlashRedRoutine(SpriteRenderer spr, float duration)
    {
        if (spr != null)
        {
            spr.color = Color.red;
        }

        yield return new WaitForSeconds(duration);

        if (spr != null)
        {
            spr.color = Color.white;
        }
    }

    public static void IFrames(SpriteRenderer spr, int numberOfFlashes, float duration)
    {
        instance.StartCoroutine(instance.IFramesRoutine(spr, numberOfFlashes, duration));
    }

    IEnumerator IFramesRoutine(SpriteRenderer spr, int numberOfFlashes, float duration)
    {
        Color startColour = spr.color;
        Color tempColour = spr.color;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            tempColour.a = 0.5f;
            spr.color = tempColour;
            yield return new WaitForSeconds(duration / (numberOfFlashes * 2));

            spr.color = startColour;
            yield return new WaitForSeconds(duration / (numberOfFlashes * 2));
        }
    }
    #endregion
}
