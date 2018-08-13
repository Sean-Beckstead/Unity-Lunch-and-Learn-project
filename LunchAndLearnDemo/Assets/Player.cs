using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text scoreText;
    public Text ShotText;
    private int score = 0;
    private int shots = 0;
		
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            shots++;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.45F, 5f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2500f))
            {
                if (hit.collider.gameObject.tag == "Target")
                {
                    HitTarget(hit.collider.gameObject);
                }
            }
        } else if (Input.GetKeyDown(KeyCode.E)) {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5f))
            {
                if (hit.collider.gameObject.tag == "LaunchButton")
                {
                    hit.collider.gameObject.GetComponent<LaunchButton>().LaunchTargets();
                    score = 0;
                    shots = 0;
                }
            }
        }

        scoreText.text = "Score " + score;
        ShotText.text = "Shots " + shots;
	}


    void HitTarget(GameObject target) {
        Destroy(target);
        score++;
    }	
}
