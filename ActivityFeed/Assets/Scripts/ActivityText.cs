﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityText : MonoBehaviour {

    // left message [Sprite] right message
    public Text leftText;
    public Text rightText;
    public Image image;

	// Use this for initialization
	void RemoveText () {
        Destroy(gameObject);
	}

    // Update is called once per frame
    public void InitText(string leftMessage, string rightMessage, Image uImage,  Color color, float lifeTime)
    {
        leftText.text = leftMessage;
        leftText.color = color;
        rightText.text = rightMessage;
        rightText.color = color;
        image = uImage;

        Invoke("RemoveText", lifeTime);

    }
}
