using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{

    public GameObject handPrefab;

    public InputDeviceCharacteristics inputDeviceCharacteristics;

    private InputDevice _targetDevice;
    private Animator _handAnim;
    private bool hideHand;
    private SkinnedMeshRenderer _handMesh;

    public void HideHand()
    {
        if (hideHand)
        {
            _handMesh.enabled = !_handMesh.enabled;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitialiseHand();
    }

    private void InitialiseHand()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);

        if(devices.Count > 0)
        {
            _targetDevice = devices[0];

            GameObject spawnedHand = Instantiate(handPrefab, transform);
            _handAnim = spawnedHand.GetComponent<Animator>();
            _handMesh = spawnedHand.GetComponent<SkinnedMeshRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_targetDevice.isValid)
        {
            InitialiseHand();
        }
        else
        {
            UpdateHand();
        }
    }

    private void UpdateHand()
    {
        if(_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerVal))
        {
            _handAnim.SetFloat("Trigger", triggerVal);
        }
        else
        {
            _handAnim.SetFloat("Trigger", 0);

        }

        if(_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripVal))
        {
            _handAnim.SetFloat("Grip", gripVal);
        }
        else
        {
            _handAnim.SetFloat("Grip", 0);

        }
    }

}
