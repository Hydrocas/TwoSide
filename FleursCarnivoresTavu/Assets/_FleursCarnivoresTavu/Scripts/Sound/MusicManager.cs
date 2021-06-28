using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //class TimelineInfo
    //{
    //    public int currentMusicBar = 0;
    //    public FMOD.StringWrapper lastMarker = new FMOD.StringWrapper();
    //}

    //TimelineInfo timelineInfo;
    //GCHandle timelineHandle;


    [FMODUnity.EventRef]
    public string musicStateEvent = "";
    FMOD.Studio.EventInstance musicState;
    //FMOD.Studio.EVENT_CALLBACK beatCallback;

    [FMODUnity.EventRef]
    public string ambEvent = "";
    FMOD.Studio.EventInstance amb;

    //[FMODUnity.EventRef]
    //public string InsectBuzzEvent = "";
    //[FMODUnity.EventRef]
    //public string InsectPickEvent = "";
    //[FMODUnity.EventRef]
    //public string LevelFlipEvent = "";
    //[FMODUnity.EventRef]
    //public string PlantDieEvent = "";
    //[FMODUnity.EventRef]
    //public string PlantEatEvent = "";
    //[FMODUnity.EventRef]
    //public string SeedPickEvent = "";
    //[FMODUnity.EventRef]
    //public string SeedPlantEvent = "";

    //[FMODUnity.EventRef]
    //public string UiClick = "";

    //[FMODUnity.EventRef]
    //public string UIMove = "";

    // public GameObject target;

    private FMODUnity.StudioEventEmitter musicEvent;

    //private FMOD.Studio.PARAMETER_ID myParameter;

    // Start is called before the first frame update
    public void Init()
    {
        DontDestroyOnLoad(this.gameObject);

        //timelineInfo = new TimelineInfo();


        musicState = FMODUnity.RuntimeManager.CreateInstance(musicStateEvent);
        //musicState.setCallback(beatCallback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
        musicState.start();

        amb = FMODUnity.RuntimeManager.CreateInstance(ambEvent);
        amb.start();
        //musicEvent::SetParameter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DaySoundState()
    {
        //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("State", 1f);
        musicState.setParameterByName("State", 1f);
        amb.setParameterByName("State", 1f);
    }

    public void NightSoundState()
    {
        //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("State", 2f);
        musicState.setParameterByName("State", 2f);
        amb.setParameterByName("State", 2f);
    }
}
