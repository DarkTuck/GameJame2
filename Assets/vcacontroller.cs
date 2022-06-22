using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vcacontroller : MonoBehaviour
{
    private FMOD.Studio.VCA  VcaController;
    public string VcaName;

    private Slider slider;

    void Start()
    {
        VcaController = FMODUnity.RuntimeManager.GetVCA("vca:/ + VcaName");
        slider = GetComponent<Slider>();
    }

    public void SetVolume(float Volume)
    {
        VcaController.setVolume(Volume);
    }
}
