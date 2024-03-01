using UnityEngine;
using System.Collections;

public class ScriptCameraForMAsk : MonoBehaviour
{

    public Camera _camera;
    public int textureSize = 500;

    void Awake()
    {
        _camera.targetTexture.width = textureSize;
        _camera.targetTexture.height = textureSize;
    }
}
