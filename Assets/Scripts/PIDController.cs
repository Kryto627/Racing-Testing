using UnityEngine;
using System;

[Serializable]
public class PIDController {

    public float KP = 0.2F;
    public float KI = 0.05F;
    public float KD = 1F;
    public float value = 0F;

    private float lastError;
    private float integral;

	public float Update(float error) {
		return Update(error, Time.deltaTime);
	}

	public float Update(float error, float dt) {

		float derivative = (error - lastError) / dt;
		integral += error * dt;
		lastError = error;

		value = Mathf.Clamp01(KP * error + KI * integral + KD * derivative);
		return value;
	}
}