using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    //Parallax effect for the menu background
    //Cool stuff

    private float length, startPos;
    public float parallaxEffect;
    public GameObject cam;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x; //Length of sprite
    }

    void Update()
    {
        float tempDist = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect; //Distance that the background moves

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z); //parallax position
        cam.transform.Translate(Vector3.right * (parallaxEffect * Time.deltaTime)); //Camera movement


        if (tempDist > startPos + length) startPos += length; //Background keeps repeating itself
        else if (tempDist < startPos - length) startPos -= length;
    }
}
