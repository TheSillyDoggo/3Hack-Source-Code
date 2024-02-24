using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class Replay
{
    public static List<string> saves = new List<string>();

    public int b;

    public bool a = true, c = false;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            c = !c;
            //SaveState();
            //2.26808:0:2.26808:2.26808:0:2.26808:2.26808:1.532072E-06:2.26808:2.26808:1:2.26808:2.26808:1:2.26808:
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PathFollower.distanceTravelled = 0;
            a = !a;
            //LoadState("2.26808:0:2.26808:2.26808:0:2.26808:2.26808:1.532072E-06:2.26808:2.26808:1:2.26808:2.26808:1:2.26808:");
            //2.26808:0:2.26808:2.26808:0:2.26808:2.26808:1.532072E-06:2.26808:2.26808:1:2.26808:2.26808:1:2.26808:
        }
    }

    public void LateUpdate()
    {
        if (c && !PauseMenuManager.paused)
        {
            if (a)
            {
                SaveState();
            }
            else
            {
                b++;
                LoadState(saves[b]);
            }
        }
        else
        {
            //saves = new List<string>();
        }
    }

    public void SaveState()
    {
        GameObject player = GameObject.Find("Player");
        string s = "";

        s += player.transform.position.x + ":" + player.transform.position.y + ":" + player.transform.position.x + ":";

        for (int child = 0; child < player.transform.childCount; child++)
        {
            s += player.transform.GetChild(child).position.x + ":" + player.transform.GetChild(child).position.y + ":" + player.transform.GetChild(child).position.x + ":";
            for (int childA = 0; childA < player.transform.GetChild(child).childCount; childA++)
            {
                s += player.transform.GetChild(child).GetChild(childA).position.x + ":" + player.transform.GetChild(child).GetChild(childA).position.y + ":" + player.transform.GetChild(child).GetChild(childA).position.x + ":";
            }
        }

        //s += player.GetComponent<PathFollower>().dis
        saves.Add(s);
        Debug.Log("BBBBBB");
    }

    public void LoadState(string str)
    {
        GameObject player = GameObject.Find("Player");
        string s = "";
        string[] parts = str.Split(":".ToCharArray());

        int a = 0;

        //s += player.transform.position.x + ":" + player.transform.position.y + ":" + player.transform.position.x + ":";
        //player.transform.position = new Vector3(float.Parse(parts[a]), float.Parse(parts[a + 1]), float.Parse(parts[a + 2]));

        for (int child = 0; child < player.transform.childCount; child++)
        {
            a += 3;
            //s += player.transform.GetChild(child).position.x + ":" + player.transform.GetChild(child).position.y + ":" + player.transform.GetChild(child).position.x + ":";
            player.transform.GetChild(child).position = new Vector3(float.Parse(parts[a]), float.Parse(parts[a + 1]), float.Parse(parts[a + 2]));
            for (int childA = 0; childA < player.transform.GetChild(child).childCount; childA++)
            {
                a += 3;//s += player.transform.GetChild(child).GetChild(childA).position.x + ":" + player.transform.GetChild(child).GetChild(childA).position.y + ":" + player.transform.GetChild(child).GetChild(childA).position.x + ":";
                player.transform.GetChild(child).GetChild(childA).position = new Vector3(float.Parse(parts[a]), float.Parse(parts[a + 1]), float.Parse(parts[a + 2]));
            }
        }

        //GameObject.FindObjectOfType<PathFollower>().enabled = false;
        Debug.Log("AAAAAA");
    }
}