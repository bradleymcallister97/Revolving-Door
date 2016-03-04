using UnityEngine;
using System.Collections;

public class RevolvingDoor : MonoBehaviour {

  //  private bool bl_turningRight = true;

    private float fl_rotationSpeed = 1.4f;
    public static float fl_targetRotationSpeed = 1.4f;

    private float fl_speedIncreaseRate = 0.00025f;
    private float fl_acceleration = 0.02f;

    private static float fl_rotationInterval;
    private static int int_timeSinceSwitch;

	// Use this for initialization
	void Start () {

        fl_rotationSpeed = 1.4f;
        fl_targetRotationSpeed = 1.4f;
        fl_rotationInterval = Random.Range((450f / Mathf.Abs(fl_targetRotationSpeed)), 1200f / Mathf.Abs(fl_targetRotationSpeed));
        int_timeSinceSwitch = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        fl_targetRotationSpeed += fl_speedIncreaseRate;
        fl_targetRotationSpeed *= 1 + fl_speedIncreaseRate;

        int_timeSinceSwitch++;

        if(int_timeSinceSwitch > fl_rotationInterval)
        {

            fl_targetRotationSpeed *= -1; //switch target direction

            fl_rotationInterval = Random.Range((450f / Mathf.Abs(fl_targetRotationSpeed)), 1200f / Mathf.Abs(fl_targetRotationSpeed));
            int_timeSinceSwitch = 0;

        }

        if(fl_targetRotationSpeed < 0 && fl_rotationSpeed > fl_targetRotationSpeed) //should rotate left
        {

            fl_rotationSpeed -= (fl_targetRotationSpeed * fl_targetRotationSpeed * fl_acceleration);

        }
        else if(fl_targetRotationSpeed > 0 && fl_rotationSpeed < fl_targetRotationSpeed)
        {

            fl_rotationSpeed += (fl_targetRotationSpeed * fl_targetRotationSpeed * fl_acceleration);

        }

        if(Mathf.Abs(fl_rotationSpeed) > Mathf.Abs(fl_targetRotationSpeed))
        {

            fl_rotationSpeed = fl_targetRotationSpeed;

        }

        transform.Rotate(Vector3.forward * fl_rotationSpeed * 1.2f);

	}



}
