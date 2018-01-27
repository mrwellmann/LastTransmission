// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.Events;

public class GazeableSystem : MonoBehaviour, IFocusable, IInputClickHandler
{
    public Renderer rendererComponent;

    [System.Serializable]
    public class OnPicked : UnityEvent<float> { }

    public OnPicked OnGazed = new OnPicked();
    public OnPicked OnPickedAngel = new OnPicked();

    private bool gazing = false;

    private void Update()
    {
        if (gazing == false) return;
        UpdatePickedColor(OnGazed);
    }

    private void UpdatePickedColor(OnPicked cb)
    {
        RaycastHit hit = GazeManager.Instance.HitInfo;

        if (hit.transform.gameObject != rendererComponent.gameObject) { return; }

        var texture = (Texture2D)rendererComponent.material.mainTexture;

        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= texture.width;
        pixelUV.y *= texture.height;

        //float angel = 
        //    texture.GetPixel((int)pixelUV.x, (int)pixelUV.y);
        //cb.Invoke(angel);
    }

    public void OnFocusEnter()
    {
        gazing = true;
    }

    public void OnFocusExit()
    {
        gazing = false;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        UpdatePickedColor(OnPickedAngel);
    }
}
