using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenVignette_Script : MonoBehaviour {

    Material Vignette;
    GameObject VignetteQuad;
    bool Switch;

    // Use this for initialization
    void Start () {
        VignetteQuad = GameObject.FindGameObjectWithTag("Vignette");
        Vignette = VignetteQuad.GetComponent<Renderer>().material;
        Switch = true;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Switch == true)
        {
            Vignette.color = Color.Lerp(Color.black, Color.white, 0.1f*Time.deltaTime);
            Debug.Log("if statement Works");
        }

	}

    private void OnCollisionEnter(Collision collision)
    {

         Switch = true;
         Debug.Log("Collision");
   
    }
}
