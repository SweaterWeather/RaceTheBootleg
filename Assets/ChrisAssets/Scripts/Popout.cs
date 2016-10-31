using UnityEngine;
using System.Collections;

/// <summary>
/// This script causes the pop-out sliders to pop-out.
/// </summary>
public class Popout : MonoBehaviour {

    /// <summary>
    /// Time remaining until the pop-out pops-out.
    /// </summary>
    float timeTill = 3f;
	
	/// <summary>
    /// Pop the pop-out out of pop the pop-pop-out.
    /// </summary>
	void Update () {
        timeTill -= Time.deltaTime;
        if(timeTill <= 0 && timeTill > -1)
        {
            RectTransform rt = GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x + Time.deltaTime * 800, rt.sizeDelta.y);

            transform.localPosition += new Vector3(0, Time.deltaTime * 5, 0);
        }
	}
}
