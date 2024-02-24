using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Gizmos = Popcron.Gizmos;

public class DrawTest : MonoBehaviour
{
    public void Update()
    {
        Gizmos.Line(transform.position, Vector3.one, Color.green, true);

        Gizmos.Cube(transform.position, transform.rotation, transform.lossyScale);
    }
}
