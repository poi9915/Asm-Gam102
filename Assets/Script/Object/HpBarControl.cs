using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarControl : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    public void UpdateHp(float value, float maxValue)
    {
        slider.value = value / maxValue;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}