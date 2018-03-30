using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitch : MonoBehaviour {

	public Sprite[] sprites;

	private Image image;
	private RectTransform transform;

	void Start () {
		image = GetComponent<Image>();
		transform = GetComponent<RectTransform>();
	}

	public void Show(int index){
		if(index < sprites.Length){
			image.sprite = sprites[index];
		}
	}

	public void Move(){
		transform.position = new Vector2(658f, transform.position.y);
	}
}
