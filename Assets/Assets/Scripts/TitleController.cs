﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class TitleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void OnClicedTitleStart(){
		SceneManager.LoadScene ("StartAnimation");
	}
	public void OnClicedTitleBACK(){
		SceneManager.LoadScene ("Title");
	}
}
