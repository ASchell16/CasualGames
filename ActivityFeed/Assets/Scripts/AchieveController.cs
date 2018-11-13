using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveController : MonoBehaviour {

    public AchievementClass achievement;
    const float lifetime = 5;
    private Animator animator;

    public Text TxtName;
    public Image image;

    void Start()
    {
        animator = GetComponent<Animator>();

        Invoke("RemoveAchieve", lifetime);
    }

    public void InitAchieve(AchievementClass Data)
    {
        achievement = Data;
        TxtName.text = Data.achieveName;

        image.sprite = Resources.Load<Sprite>("AchievementSprites/" + Data.Image);
    }

    private void RemoveAchieve()
    {
        Destroy(gameObject);
    }


}
