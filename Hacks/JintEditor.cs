using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class JintEditor
{
    public static void PlaceObject(object id, object x, object y, object z,object rotation)
    {
        Debug.Log($"Placing {id} at {x}:{y} with rotation {rotation}");

		Vector3 nousePosWorldVec = StringToVector3(Windows.Creator.editor.GetType().GetField("mousePosWorldInt").GetValue(Windows.Creator.editor).ToString());
		Vector3Int mousePosWorldInt = new Vector3Int(Mathf.RoundToInt(nousePosWorldVec.x), Mathf.RoundToInt(nousePosWorldVec.y), Mathf.RoundToInt(nousePosWorldVec.z));

		bool flag = mousePosWorldInt.x >= 0f && mousePosWorldInt.x < 2000f && (int)y >= -10f && (int)y < 30f;
		bool flag2 = int.Parse(Windows.Creator.editor.GetType().GetMethod("GetTotalItems").Invoke(Windows.Creator.editor, null).ToString()) >= Windows.Creator.editor.objectLimit;

		if (flag && !flag2)
		{
			List<GameObject> list2 = Windows.Creator.editor.levelData[(int)z + 4][(int)x];
			for (int j = 0; j < list2.Count; j++)
			{
				GameObject gameObject2 = list2[j];
				if (gameObject2.transform.position.y == (int)y)
				{
					gameObject2.GetComponentInChildren<ItemScript>().dead = true;
					list2.RemoveAt(j);
					break;
				}
			}
			LevelEditor editor = (LevelEditor)Windows.Creator.editor.GetType().GetField("editor").GetValue(Windows.Creator.editor);

			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(editor.items[(int)id], new Vector3((int)x, (int)y, 0f), Quaternion.identity);
			gameObject3.transform.forward = Vector3.right;
			gameObject3.transform.Rotate(new Vector3((float)(-(float)rotation), 0f, 0f));
			Windows.Creator.editor.levelData[(int)z + 4][(int)x].Add(gameObject3);
			gameObject3.AddComponent<FlatItem>();
			gameObject3.GetComponent<FlatItem>().index = (int)id;
			gameObject3.GetComponent<FlatItem>().x = (int)x;
			gameObject3.GetComponent<FlatItem>().y = (int)y;
			gameObject3.GetComponent<FlatItem>().z = (int)z;
			gameObject3.GetComponent<FlatItem>().angle = (int)rotation;
		}
	}

	public static Vector3 StringToVector3(string sVector)
	{
		// Remove the parentheses
		if (sVector.StartsWith("(") && sVector.EndsWith(")"))
		{
			sVector = sVector.Substring(1, sVector.Length - 2);
		}

		// split the items
		string[] sArray = sVector.Split(',');

		// store as a Vector3
		Vector3 result = new Vector3(
			float.Parse(sArray[0]),
			float.Parse(sArray[1]),
			float.Parse(sArray[2]));

		return result;
	}
}