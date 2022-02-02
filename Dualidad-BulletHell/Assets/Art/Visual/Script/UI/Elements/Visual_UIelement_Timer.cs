using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Visual_UIelement_Timer : Visual_UIelement
{
    [SerializeField] TextMeshProUGUI Text;

    [SerializeField] string addText_min, addText_second, addText_milisecond;


    public void SetTimer(int min, int second, int milisecond) { Text.SetText(addText_min + min.ToString() + addText_second + second.ToString() + addText_milisecond + milisecond.ToString()); }

}
