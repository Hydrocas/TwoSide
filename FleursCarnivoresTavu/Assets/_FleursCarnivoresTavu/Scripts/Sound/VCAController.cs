using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCAController : MonoBehaviour
{

    private FMOD.Studio.VCA VcaController1;
    private FMOD.Studio.VCA VcaController2;

    public string VcaName1;
    public string VcaName2;


    // Start is called before the first frame update
    void Start()
    {
        VcaController1 = FMODUnity.RuntimeManager.GetVCA("vca:/" + VcaName1);
        VcaController2 = FMODUnity.RuntimeManager.GetVCA("vca:/" + VcaName2);
    }

    public void MuteFX(bool mute)
    {
        if(!mute) VcaController1.setVolume(1);
        if(mute) VcaController1.setVolume(0);
        //mute = !mute;
    }

    public void MuteMusic(bool mute)
    {
        if (!mute) VcaController2.setVolume(1);
        if (mute) VcaController2.setVolume(0);
    }
}
