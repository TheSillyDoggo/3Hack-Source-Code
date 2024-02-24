using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules
{
    [System.Serializable]
    class Freecam : Module
    {
        public Freecam()
        {
            //0.05
            name = "Freecam";
        }

        public static void DoPatch()
        {
            
        }
        public override void Update()
        {
            
            if (GameObject.Find("CameraManagement") != null && SceneManager.GetActiveScene().name != "Camera Animator")
            {
                GameObject.Find("CameraManagement").transform.GetChild(0).GetChild(0).GetComponent<BoomArm>().enabled = enabled;
                GameObject.Find("CameraManagement").transform.GetChild(0).GetChild(0).GetComponent<BoomArm>().spd = 0.05f;
                GameObject.Find("CameraManagement").transform.GetChild(0).GetChild(0).GetComponent<Animator>().enabled = !enabled;

                Cursor.lockState = Screen.fullScreen ? CursorLockMode.Confined : CursorLockMode.None;

                //GameObject.FindObjectOfType<PlayerScript>().noDeath = false;

                foreach (var item in ModMain.cwm.wnds)
                {
                    if (item.name == "Player")
                    {
                        GameObject.FindObjectOfType<PlayerScript>().noDeath = item.modules[0].enabled;
                    }
                }
            }
        }
    }
}