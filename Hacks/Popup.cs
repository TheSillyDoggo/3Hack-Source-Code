using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Popup
{
    public float Scale;

    public void Update()
    {
        Scale += Time.deltaTime;

        Scale = Mathf.Clamp01(Scale);
    }

    public void Draw()
    {
        DrawUtils.DrawRect(new Rect(0, 0, Screen.width, Screen.height), new Color(0, 0, 0, Scale * 0.3f));
    }
}