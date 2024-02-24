using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace Modules
{
    public class CatMode : Module
    {
        Texture2D texture;
        public CatMode()
        {
            name = "Cat Mode";
            description = "Replaces every texture with Cats";

            string path = Application.dataPath;

            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                path += "/../../";
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                path += "/../";
            }

            path += "Cat.png";

            texture = new Texture2D(10, 10);

            texture.LoadRawTextureData(System.IO.File.ReadAllBytes(path));
            texture.Apply(true, false);

            Debug.Log("Cat = " + texture == null);
        }

        public override void Update()
        {
            foreach (var item in GameObject.FindObjectsOfType<Image>())
            {
                if (item.sprite.texture != texture)
                {
                    item.sprite = Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), Vector2.one * 0.5f);
                }
            }
        }
    }
}
