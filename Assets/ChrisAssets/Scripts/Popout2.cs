using UnityEngine;
using System.Collections;

/// <summary>
/// This script causes the pop-out sliders to pop-out.
/// </summary>
public class Popout2 : MonoBehaviour
{

    /// <summary>
    /// Time remaining until the pop-out pops-out.
    /// </summary>
    public float timeTill = 3f;

    /// <summary>
    /// The ammount of time that this object will move for.
    /// </summary>
    public float timeMove = -1;

    /// <summary>
    /// An int of 1 or -1 to track the direction this will move in.
    /// </summary>
    public int pos;

    /// <summary>
    /// Whether or not the object will scale up as it moves.
    /// </summary>
    public bool scale = true;

    /// <summary>
    /// Pop the pop-out out of pop the pop-pop-out.
    /// </summary>
    void Update()
    {
        timeTill -= Time.deltaTime;
        if (timeTill <= 0 && timeTill > timeMove)
        {
            RectTransform rt = GetComponent<RectTransform>();
            if (scale) rt.sizeDelta = new Vector2(rt.sizeDelta.x + Time.deltaTime * 800, rt.sizeDelta.y);

            transform.localPosition += new Vector3(Time.deltaTime * 75 * pos, 0, 0);
        }
    }
}
