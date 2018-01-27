// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.Events;

public class GazeableSystem : MonoBehaviour, IFocusable, IInputClickHandler
{
    public Renderer rendererComponent;
    public TransmitterScript ActiveStation;

    private bool gazing = false;

    private void Update()
    {
        if (gazing == false) return;
        UpdateGazing();
    }

    private void UpdateGazing()
    {
        RaycastHit hit = GazeManager.Instance.HitInfo;

        if (hit.transform.gameObject != rendererComponent.gameObject) { return; }

        Vector3 hitpos = GazeManager.Instance.HitPosition;

        ActiveStation.TransmitterAntenna.transform.LookAt(hitpos);
    }

    public void OnFocusEnter()
    {
        gazing = true;
        //GetComponent<MeshRenderer>().enabled = true;
    }

    public void OnFocusExit()
    {
        gazing = false;
        //GetComponent<MeshRenderer>().enabled = false;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        UpdateGazing();
        ActiveStation.FireMessage();
    }
}
