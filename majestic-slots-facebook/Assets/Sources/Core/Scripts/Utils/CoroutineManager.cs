using RMC.Common.Singleton;
using System.Collections;
using UnityEngine;

/// <summary>
/// Allow non-Monobehaviors to call Coroutines
/// </summary>
public class CoroutineManager : SingletonMonobehavior<CoroutineManager>
{
    new public Coroutine StartCoroutine(IEnumerator iEnumerator)
    {
        if (iEnumerator != null)
        {
            return base.StartCoroutine(iEnumerator);
        }

        return null;
    }

    public Coroutine StartCoroutineAfterDelay(IEnumerator iEnumerator, float delayInSeconds)
    {
        return StartCoroutine(Coroutine_AfterDelay(iEnumerator, delayInSeconds));
    }

    private IEnumerator Coroutine_AfterDelay(IEnumerator iEnumerator, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        StartCoroutine(iEnumerator);
    }

    public static Coroutine StartC(IEnumerator iEnumerator)
    {
        return Instance.StartCoroutine(iEnumerator);
    }

    public static void StopC(IEnumerator iEnumerator)
    {
        Instance.StopCoroutine(iEnumerator);
    }

    public static void StopC(Coroutine coroutine)
    {
        Instance.StopCoroutine(coroutine);
    }

    public static Coroutine StartAfterDelay(IEnumerator iEnumerator, float delayInSeconds)
    {
        return Instance.StartCoroutineAfterDelay(iEnumerator, delayInSeconds);
    }
}