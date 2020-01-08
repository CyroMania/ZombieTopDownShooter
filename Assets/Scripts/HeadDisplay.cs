using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadDisplay : MonoBehaviour
{
    public Image HeadUI;
    public RectTransform InitTransform;

    public Sprite Healthy;
    public Sprite Hurt;
    public Sprite Injured;
    public Sprite Wounded;
    public Sprite Massacred;
    Vector3 initVectorPosition;

    public float AxisXLimit = 1f;
    public float AxisYLimit = 1f;
    private bool isVibrating = false;

    public void UpdateImage()
    {
        int health = PlayerPrefs.GetInt("PlayerHealth");
        if (health > 80)
        {
            HeadUI.sprite = Healthy;
        }
        else if (health > 60)
        {
            HeadUI.sprite = Hurt;
        }
        else if (health > 40)
        {
            HeadUI.sprite = Injured;
        }
        else if (health > 20)
        {
            HeadUI.sprite = Wounded;
        }
        else
        {
            HeadUI.sprite = Massacred;
        }
    }



    private void Update()
    {
        if (!isVibrating)
        {
            isVibrating = true;
            StartCoroutine(Vibrate());
        }
    }

    

    IEnumerator Vibrate()
    {
        float health = PlayerPrefs.GetInt("PlayerHealth");
        float PositionX = gameObject.transform.position.x;
        float PositionY = gameObject.transform.position.y;
        float difference = (300 / health) - 3;
        float NewPositionX = Random.Range(PositionX - difference, PositionX + difference);
        float NewPositionY = Random.Range(PositionY - difference, PositionY + difference);

        Vector3 NewPosition = new Vector3(NewPositionX, NewPositionY, gameObject.transform.position.z);

        while (NewPosition.x > InitTransform.transform.position.x + AxisXLimit || NewPosition.x < InitTransform.transform.position.x - AxisXLimit || NewPosition.y > InitTransform.transform.position.y + AxisYLimit || NewPosition.y < InitTransform.transform.position.y - AxisYLimit)
        {
            NewPositionX = Random.Range(PositionX - difference, PositionX + difference);
            NewPositionY = Random.Range(PositionY - difference, PositionY + difference);
            NewPosition = new Vector3(NewPositionX, NewPositionY, gameObject.transform.position.z);
        }

        gameObject.transform.position = NewPosition;

        yield return new WaitForSeconds(health / 300);
        isVibrating = false;
    }
}
