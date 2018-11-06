using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityText : MonoBehaviour {

    // left message [Sprite] right message
    public Text leftText;
    public Text rightText;

	// Use this for initialization
	void RemoveText () {
        Destroy(gameObject);
	}

    // Update is called once per frame
    void InitText(string leftMessage, string rightMessage, float lifeTime, Color color)
    {
        leftText.text = leftMessage;
        leftText.color = color;
        rightText.text = rightMessage;
        rightText.color = color;

        Invoke("RemoveText", lifeTime);

    }
}
