using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityFeed : MonoBehaviour {

    public GameObject KillFeed;
    public GameObject ContentPanel;
    public Image image;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddMessage("Test", "Test", image, Color.red, 5f);
        }
    }

    void AddMessage(string leftMessage, string rightMessage, Image image, Color color, float lifeTime)
    {
        var text = Instantiate(KillFeed, ContentPanel.transform);

        var activityText = text.GetComponent<ActivityText>();
        activityText.InitText(leftMessage, rightMessage, image, color, lifeTime);
    }

}
