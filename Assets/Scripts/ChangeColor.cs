using UnityEngine.UI;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Text text;

    public void OnPress()
    {
        text.color = Color.white;
    }
}
