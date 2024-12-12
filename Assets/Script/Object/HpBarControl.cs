using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarControl : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject fill;
    // Start is called before the first frame update


    public void UpdateHp(float value, float maxValue)
    {
        Image bgImage = fill.GetComponent<Image>();
        // fill.GetComponent<Image>().color = new Color(0.71f, 0.49f, 0.13f);
        slider.value = value / maxValue;

        if (Mathf.Approximately(value, 7))
        {
            bgImage.color = new Color(0.71f, 0.49f, 0.13f);
        }

        if (Mathf.Approximately(value, 3))
        {
            bgImage.color = new Color(0.71f, 0f, 0.05f);
        }

        if (value >8)
        {
            bgImage.color = new Color(0.27f, 0.71f, 0.07f);
        }
        // if (value == 8)
        // {
        //     Image backgroundColor = slider.GetComponentInChildren<Image>();
        //     backgroundColor.color = new Color(0.78f, 0.7f, 0.15f, 0f);
        // }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}