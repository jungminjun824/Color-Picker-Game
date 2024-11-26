using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private Image image;

    public Color Color
    {
        set => image.color = value;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }
}
