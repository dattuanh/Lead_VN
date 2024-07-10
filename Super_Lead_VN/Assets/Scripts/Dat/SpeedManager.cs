using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static float accelerationRate = 0.001f;
    private static float currentSpeed = 0f;
    private static bool isAccelerationRateChanged = false;

    private void Start()
    {
        StartCoroutine(ChangeAccelerationRateAfterTime(60));
    }

    private void Update()
    {
        UpdateSpeed();
    }

    private IEnumerator ChangeAccelerationRateAfterTime(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        accelerationRate = 0.2f;
        isAccelerationRateChanged = true;
    }

    public static void UpdateSpeed()
    {
        currentSpeed += accelerationRate * Time.deltaTime;
    }

    public static float GetCurrentSpeed()
    {
        return currentSpeed;
    }

}
