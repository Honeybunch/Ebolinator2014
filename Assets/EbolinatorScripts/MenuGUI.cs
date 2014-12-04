using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public Texture mapBG;
	public Texture logo;
	void OnGUI(){
		GUI.DrawTexture(new Rect(0,0,mapBG.width*2,mapBG.height* 2), mapBG);
		GUI.DrawTexture(new Rect(Screen.width/2 - logo.width/2, Screen.height/2 - logo.height/2-200, logo.width, logo.height), logo);
		if(GUI.Button(new Rect(Screen.width/2 - 125, Screen.height/2 - 50, 250, 100), "Begin Infection Campaign")){
			Application.LoadLevel("PlayTest1");
		}
	}
}
