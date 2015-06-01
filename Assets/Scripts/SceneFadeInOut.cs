using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour {
	public float fadeSpeed = 1.5f;
	private bool sceneStarting = true;

	private Image img; 
	void Start(){
		img = this.GetComponent<Image> ();
	}

	void Awake(){
	}

	void Update(){
		if (this.sceneStarting) {
			StartScene ();
		}
	}

	void FadeToClear(){
		img.color = Color.Lerp (img.color, Color.clear, fadeSpeed*Time.deltaTime);
	}

	void FadeToBlack(){
		img.color = Color.Lerp (img.color, Color.black, fadeSpeed*Time.deltaTime);
	}

	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(img.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			img.color = Color.clear;
			img.enabled = false;
			
			// The scene is no longer starting.
			sceneStarting = false;
		}
	}

	public void EndScene ()
	{
		// Make sure the texture is enabled.
		img.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(img.color.a >= 0.95f)
			// ... reload the level.
			Application.LoadLevel(1);
	}
}
