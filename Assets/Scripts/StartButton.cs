using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public Text StartText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update on mouse hover

    void OnMouseEnter()
    {
        StartText.color = Color.white;
    }
    private void OnMouseExit()
    {
        StartText.color = Color.black;
    }
}
