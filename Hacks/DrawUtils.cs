using System;
using UnityEngine;

public class DrawUtils
{
	public static float rgbTime;

	public static void DrawOutlinedRect(Rect position, Color color, float width)
	{
		DrawRect(new Rect(position.x, position.y, position.width + width, width), color);
		DrawRect(new Rect(position.x, position.y, width, position.height + width), color);

		DrawRect(new Rect(position.x, position.y + position.height, position.width + width, width), color);
		DrawRect(new Rect(position.x + position.width, position.y, width, position.height + width), color);
	}

	public static void DrawRect(Rect position, Color color)
	{
		GUI.skin.box.normal.background = Texture2D.whiteTexture;// texture2D;
		GUI.backgroundColor = color;
		GUI.Box(position, GUIContent.none);
	}

	public static Color RGBCol()
	{
		if (DrawUtils.rgbTime > 180f)
		{
			DrawUtils.rgbTime = 0f;
		}
		return Color.HSVToRGB(DrawUtils.rgbTime / 180f, 1f, 1f);
	}

	public static void Update()
    {
		DrawUtils.rgbTime += 5f * Time.unscaledDeltaTime;
	}

	public static Color Accent()
	{
		return RGBCol();//new Color(25 / 255.0f, 209 / 255.0f, 160 / 255.0f);
	}

	public static void DrawText(Rect position, string text, Color color)
	{
		//GUI.skin.box.normal.background = texture2D;
		GUI.skin.label.normal.background = null;
		GUI.skin.label.onHover.background = null;
		GUI.skin.label.hover.background = null;
		GUI.contentColor = color;
		//GUI.TextArea(position, text);
		GUI.Label(position, text);
	}

	public static string DrawTextField(Rect position, string text, Color color)
    {
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.SetPixel(0, 0, color);
		texture2D.Apply();
		GUI.skin.textField.normal.background = texture2D;
		GUI.skin.textField.hover.background = texture2D;
		GUI.skin.textField.active.background = texture2D;
		GUI.skin.textField.focused.background = texture2D;
		GUI.skin.textField.onHover.background = texture2D;

		GUI.contentColor = color;

		GUI.skin.textField.alignment = TextAnchor.MiddleLeft;
		return GUI.TextField(position, text);
	}

	public static void DrawWindow(int windowID)
    {
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.SetPixel(0, 0, Color.black);
		texture2D.Apply();
		GUI.skin.window.normal.background = texture2D;


		GUI.BringWindowToBack(0);
		GUI.skin.textArea.fontSize = 23;

		// Make a very long rect that is 20 pixels tall.
		// This will make the window be resizable by the top
		// title bar - no matter how wide it gets.

		if (Input.GetKeyDown(KeyCode.T))
		{
			Debug.Log("T was pressed at 3 am in the afternoon amog us irl?");
		}

		GUI.skin.box.normal.background = null;

		GUI.Box(new Rect(0, 0, 120, 20), "");

		if (GUI.Button(new Rect(0, 50, 230, 20), "Inf Vision"))
		{
			//Patches.InfiniteDistance.enabled = !Patches.InfiniteDistance.enabled;
		}



		GUI.DragWindow(new Rect(0, 0, 10000, 20));
	}
}
