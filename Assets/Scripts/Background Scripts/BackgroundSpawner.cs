using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    private GameObject[] backgrounds;

    private float lastYPosition;

    void Start()
    {
        GetBackgroundAndSetLastY();
    }

    void GetBackgroundAndSetLastY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");

        lastYPosition = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (lastYPosition > backgrounds[i].transform.position.y)
            {
                lastYPosition = backgrounds[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            if (target.transform.position.y == lastYPosition)
            {
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastYPosition = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
