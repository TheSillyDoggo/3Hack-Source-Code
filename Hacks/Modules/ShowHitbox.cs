using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using Gizmos = Popcron.Gizmos;

namespace Modules
{
    
    [System.Serializable]
    class ShowHitbox : Module
    {
        public int a = 11;


        public List<Collider> cols;
        public ShowHitbox()
        {
            name = "Show Hitbox";
            description = "Shows the hitboxes";

            //Start

            var harmony = new HarmonyLib.Harmony("com.Explodingbill.ShowHItbox");

            var mOriginal = AccessTools.Method(typeof(ItemScript), "Start");
            var preFix = SymbolExtensions.GetMethodInfo(() => UpdatePrePatch(null));

            harmony.Patch(mOriginal, new HarmonyMethod(preFix), null);
        }

        public static void UpdatePrePatch(ItemScript __instance)
        {
            if (__instance.name == "Spike(Clone)")
            {
                //cols.Add()
            }
        }

        public override void Update()
        {
            if (enabled)
            {
                Gizmos.Enabled = true;
                Gizmos.FrustumCulling = false;
                
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    //Player/CameraManagement/CameraRaiser/Boom Arm/
                    //GameObject.FindObjectOfType<PlayerScript>().transform.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.name = "PlayerCamera";
                    Gizmos.CameraFilter += cam =>
                    {
                        return cam.name == "Main Camera";
                    };

                    foreach (var item in GameObject.FindObjectsOfType<Collider>())
                    {
                        item.gameObject.AddComponent<DrawTest>();
                    }
                }
            }
        }

        public Vector3[] GetColliderVertexPositions(GameObject _object)
        {
            var vertices = new Vector3[8];
            var thisMatrix = _object.transform.localToWorldMatrix;
            var storedRotation = _object.transform.rotation;
            _object.transform.rotation = Quaternion.identity;

            var extents = _object.GetComponent<Collider>().bounds.extents;
            vertices[0] = thisMatrix.MultiplyPoint3x4(extents);
            vertices[1] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, extents.z));
            vertices[2] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, extents.y, -extents.z));
            vertices[3] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, -extents.z));
            vertices[4] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, extents.z));
            vertices[5] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, -extents.y, extents.z));
            vertices[6] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, -extents.z));
            vertices[7] = thisMatrix.MultiplyPoint3x4(-extents);

            _object.transform.rotation = storedRotation;
            return vertices;
        }
    }
}