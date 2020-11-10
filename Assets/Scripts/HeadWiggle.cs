using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadWiggle : MonoBehaviour
{
    private float tempo = 0.0f;
    public float speed = 0.05f;
    public float force = 0.1f;
    public float originPoint = 0.0f;

    float cutWave;
    float horizontalMov;
    float verticalMov;
    Vector3 savePosition;

    // Update is called once per frame
    void Update()
    {
        cutWave = 0.0f;
        horizontalMov = Input.GetAxis("Horizontal");
        verticalMov = Input.GetAxis("Vertical");

        savePosition = transform.localPosition;

        if (Mathf.Abs(horizontalMov) == 0 && Mathf.Abs(verticalMov) == 0)
        {
            tempo = 0.0f;
            //If player isn't walking tempo resets
        }
        else
        {
            cutWave = Mathf.Sin(tempo);
            tempo = tempo + speed;

            if (tempo > Mathf.PI * 2)
            {
                tempo = tempo - (Mathf.PI * 2);
            }

            //If player is walking this will make a sin function of tempo
        }

        if (cutWave != 0)
        {
            float changeMovement = cutWave * force;
            float totalAxis = Mathf.Abs(horizontalMov) + Mathf.Abs(verticalMov);
            totalAxis = Mathf.Clamp(totalAxis, 0.0f, 1.0f);
            changeMovement = totalAxis * changeMovement;
            savePosition.y = originPoint + changeMovement;
            
            //Head movement goes up and down (head wiggle)
        }
        else
        {
            savePosition.y = originPoint;
        }

        transform.localPosition = savePosition;
    }
}
