using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMode : MonoBehaviour
{
    public float SceneSize;
    float widthScene;
    float heightScene;
    public Camera cam;
    public RectTransform rect;
    private void Start()
    {
      gameObject.transform.localScale *= SceneRate;
    }
    private float SceneRate
    {
        get
        {
            widthScene = cam.pixelWidth;
            heightScene = cam.pixelHeight;
            SceneSize = widthScene / heightScene;
            return SceneSize / 1.8f;
        }
    }
}
