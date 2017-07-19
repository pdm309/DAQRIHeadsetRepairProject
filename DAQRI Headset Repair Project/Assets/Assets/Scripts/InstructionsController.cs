﻿using DAQRI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour
{

    [SerializeField]
    private float maxDistance = 20f;

    [SerializeField]
    private DisplayManager currentDisplayManager;

    [SerializeField]
    private GameObject mainCanvas;

    [SerializeField]
    private GameObject disabledCanvas;

    [SerializeField]//X and Y are screen cordinates on the camera and the z is used for depth/distance from camera forward.
    private Vector3 posAdjustments = new Vector3(0, 0, 0);

    private float initialTimeDelay = .1f;

    [SerializeField]
    public GameObject experienceMenu;
    private GameObject reticle;

    [HideInInspector]
    public bool value;
    [HideInInspector]
    public static bool worldspace;

    public void RepositionCanvas()
    {
        if (!worldspace)
        {
            SwitchUI(false);
            AttachCanvas();
        }
        else
        {
            mainCanvas.SetActive(false);
            SwitchUI(false);
            disabledCanvas.SetActive(true);
            TransformSync();
        }
    }

    public void LaunchBlowUp(GameObject BlowUpCanvas)
    {
        BlowUpCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnCountdownFinished()
    {
        DetachCanvas();
    }
    public void BodySpaceCountDownFinished()
    {
        mainCanvas.SetActive(true);
        mainCanvas.transform.localPosition = Vector3.zero;        
        TransformSync();
        SwitchUI(true);
    }

    private void SwitchUI(bool activate)
    {
        reticle.SetActive(activate);
        experienceMenu.SetActive(activate);
    }

    private void Awake()
    {
        currentDisplayManager = DisplayManager.Instance;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(initialTimeDelay);
        if (reticle == null)
        {
            reticle = FindObjectOfType<Reticle>().gameObject;
        }
        TransformSync();
        AttachWtihoutTimer();
        DetachCanvas();
    }

    private void Update()
    {
        ClampDistance();
    }

    private void ClampDistance()
    {
        float currentDistance = Vector3.Distance(currentDisplayManager.transform.position, transform.position);

        if (currentDistance > maxDistance)
        {
            Vector3 updatedVector = currentDisplayManager.transform.position - transform.position;
            updatedVector = updatedVector.normalized;
            updatedVector *= currentDistance - maxDistance;
            transform.position += updatedVector;
        }
    }

    private void TransformSync()
    {
        Vector3 worldPoint =
            Camera.main.ViewportToWorldPoint(new Vector3(0.5f + posAdjustments.x,
                0.5f + posAdjustments.y,
                posAdjustments.z));
        transform.position = worldPoint;
        transform.eulerAngles = currentDisplayManager.transform.eulerAngles;
    }

    private void AttachCanvas()
    {
        disabledCanvas.SetActive(true);
        TransformSync();
        mainCanvas.transform.position = currentDisplayManager.transform.position + new Vector3(0, 10, 0);
        transform.SetParent(currentDisplayManager.transform, true);
    }
    private void AttachWtihoutTimer()
    {
        TransformSync();
        mainCanvas.transform.position = currentDisplayManager.transform.position + new Vector3(0, 10, 0);
        transform.SetParent(currentDisplayManager.transform, true);
    }

    private void DetachCanvas()
    {
        mainCanvas.transform.localPosition = Vector3.zero;
        transform.SetParent(null, true);
        TransformSync();
        SwitchUI(true);
    }
    public void ChangePostion(GameObject BodyspaceAttach)
    {        
        if (worldspace)
        {
            gameObject.transform.parent = null;
            BodyspaceAttach.SetActive(false);
        }
        else
        {            
            gameObject.transform.parent = BodyspaceAttach.transform;
            BodyspaceAttach.transform.position = currentDisplayManager.transform.position + new Vector3(0, 10, 0);
            gameObject.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            BodyspaceAttach.SetActive(true);
        }
        worldspace = !worldspace;
    }
}