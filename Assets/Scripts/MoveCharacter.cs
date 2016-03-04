using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    private bool bl_nextPointAtTop = false;

    private bool bl_counterClockwise;

    public static float fl_xspeed = 0f;
    public static float fl_yspeed = 0f;
    public static int int_score = 0;

    private const float XSCALE = 0.6f;

    // Use this for initialization
    void Start () {

        fl_xspeed = 0f;
        fl_yspeed = 0f;
        int_score = 0;
        bl_nextPointAtTop = false;
    }

    IEnumerator Left1()
    {

        transform.position += new Vector3(fl_xspeed * XSCALE * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), fl_yspeed * 0.4f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), 0);
        yield return new WaitForFixedUpdate();

        if (transform.position.y <= 3)
        {

            StartCoroutine(Left2());

        }
        else if(transform.position.y <= 7)
        {

            StartCoroutine(Left1());

        }
        else
        {

            fl_xspeed = 0f;
            fl_yspeed = 0f;

            if (bl_nextPointAtTop)
            {
                int_score += 1;
                bl_nextPointAtTop = !bl_nextPointAtTop;
            }
            transform.position = new Vector3(0, 7f, 0);
        }

    }

    IEnumerator Left2()
    {
        transform.position += new Vector3(fl_xspeed * XSCALE * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), fl_yspeed * 0.4f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), 0);
        yield return new WaitForFixedUpdate();

            if(transform.position.y >= 3)
            {

                fl_yspeed = 0.2f;
                fl_xspeed = 0.1f;
                StartCoroutine(Left1());

            }
            else if(transform.position.y <= -3)
            {

                fl_yspeed = -0.2f;
                fl_xspeed = 0.1f;
                StartCoroutine(Left3());

            }
            else //ball is still on path
            {

                fl_xspeed += XSCALE * 0.0045f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed);

                StartCoroutine(Left2());

          }

    }

    IEnumerator Left3()
    {
        transform.position += new Vector3(fl_xspeed * XSCALE * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), fl_yspeed * 0.4f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), 0);
        yield return new WaitForFixedUpdate();

        if (transform.position.y >= -3)
        {

            StartCoroutine(Left2());

        }
        else if (transform.position.y >= -7)
        {

            StartCoroutine(Left3());

        }
        else
        {

            fl_xspeed = 0f;
            fl_yspeed = 0f;
            if (!bl_nextPointAtTop)
            {
                int_score += 1;
                bl_nextPointAtTop = !bl_nextPointAtTop;
            }
            transform.position = new Vector3(0, -7f, 0);
        }

    }

    IEnumerator Right1()
    {
        transform.position += new Vector3(fl_xspeed * XSCALE * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), fl_yspeed * 0.4f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), 0);
        yield return new WaitForFixedUpdate();

        if (transform.position.y <= 3)
        {

           StartCoroutine(Right2());

        }
        else if (transform.position.y <= 7)
        {

            StartCoroutine(Right1());

        }
        else
        {

            fl_xspeed = 0f;
            fl_yspeed = 0f;
            if (bl_nextPointAtTop)
            {
                int_score += 1;
                bl_nextPointAtTop = !bl_nextPointAtTop;
            }
            transform.position = new Vector3(0, 7f, 0);
        }

    }

    IEnumerator Right2()
    {
        transform.position += new Vector3(fl_xspeed * XSCALE * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), fl_yspeed * 0.4f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), 0);
        yield return new WaitForFixedUpdate();

            if (transform.position.y >= 3)
            {

                fl_yspeed = 0.2f;
                fl_xspeed = -0.1f;
                StartCoroutine(Right1());

            }
            else if(transform.position.y <= -3)
            {

                fl_yspeed = -0.2f;
                fl_xspeed = -0.1f;
                StartCoroutine(Right3());

            }
        else //ball is still on path
        {

            fl_xspeed -= XSCALE * 0.0045f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed);

            StartCoroutine(Right2());

        }
    }
    IEnumerator Right3()
    {
        transform.position += new Vector3(fl_xspeed * XSCALE * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), fl_yspeed * 0.4f * Mathf.Abs(RevolvingDoor.fl_targetRotationSpeed), 0);
        yield return new WaitForFixedUpdate();

        if (transform.position.y >= -3)
        {

            StartCoroutine(Right2());

        }
        else if (transform.position.y >= -7)
        {

            StartCoroutine(Right3());

        }
        else
        {

            fl_xspeed = 0f;
            fl_yspeed = 0f;
            if (!bl_nextPointAtTop)
            {
                int_score += 1;
                bl_nextPointAtTop = !bl_nextPointAtTop;
            }
            transform.position = new Vector3(0, -7f, 0);
        }

    }


    // Update is called once per frame
    void Update () {


	
        if (Input.GetKeyDown("left"))
        {

            if (transform.position.y >= 6.97f)
            {
                fl_yspeed = -0.2f;
                fl_xspeed = -0.1f;
                bl_counterClockwise = true;
                transform.position = new Vector3(-0.1f, 6.8f, 0);

                StartCoroutine(Left1());
            }
            else if (transform.position.y <= -6.97f)
            {
                fl_yspeed = 0.2f;
                fl_xspeed = -0.1f;
                bl_counterClockwise = false;
                transform.position = new Vector3(-0.1f, -6.8f, 0);

                StartCoroutine(Left3());
            }
            else //character is running through door
            {

                fl_xspeed = -fl_xspeed;
                fl_yspeed = -fl_yspeed;
                bl_counterClockwise = !bl_counterClockwise;

            }
        }
        else if (Input.GetKeyDown("right"))
        {

            if (transform.position.y >= 6.97f)
            {
                fl_yspeed = -0.2f;
                fl_xspeed = 0.1f;
                bl_counterClockwise = false;
                transform.position = new Vector3(0.1f, 6.8f, 0);

                StartCoroutine(Right1());
            }
            else if (transform.position.y <= -6.97f)
            {
                fl_yspeed = 0.2f;
                fl_xspeed = 0.1f;
                bl_counterClockwise = true;
                transform.position = new Vector3(0.1f, -6.8f, 0);

                StartCoroutine(Right3());
            }
            else //character is running through door
            {

                fl_xspeed = -fl_xspeed;
                fl_yspeed = -fl_yspeed;
                bl_counterClockwise = !bl_counterClockwise;

            }

        }

        if(Input.GetKeyDown("space"))
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        }

    }
}
