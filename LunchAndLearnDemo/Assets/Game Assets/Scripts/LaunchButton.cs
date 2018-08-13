using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButton : MonoBehaviour {
    
    public List<TargetLauncher> LauncherList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LaunchTargets() {
        foreach(TargetLauncher launcher in LauncherList) {
            launcher.LaunchTargets();
        }
    }
}
