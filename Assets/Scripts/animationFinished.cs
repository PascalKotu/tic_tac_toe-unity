using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationFinished : MonoBehaviour
{
	private ButtonFunctions parent = default;
    void Start(){
		parent = this.GetComponentInParent<ButtonFunctions>();
    }
	//function is called when animation is done
	public void finished(){
		parent.resume();
	}
}
