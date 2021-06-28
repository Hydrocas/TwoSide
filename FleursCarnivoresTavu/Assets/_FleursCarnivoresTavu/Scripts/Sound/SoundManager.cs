using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string InsectBuzzEvent = "";
    [FMODUnity.EventRef]
    public string InsectPickEvent = "";
    [FMODUnity.EventRef]
    public string LevelFlipEvent = "";
    [FMODUnity.EventRef]
    public string PlantDieEvent = "";
    [FMODUnity.EventRef]
    public string PlantEatEvent = "";
    [FMODUnity.EventRef]
    public string SeedPickEvent = "";
    [FMODUnity.EventRef]
    public string SeedPlantEvent = "";

    [FMODUnity.EventRef]
    public string UIClick = "";

    [FMODUnity.EventRef]
    public string UIMove = "";

    public void InsectBuzzSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(InsectBuzzEvent, gameObject);
    }

    public void InsectPickSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(InsectPickEvent, gameObject);
    }

    public void LevelFlipSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(LevelFlipEvent, gameObject);
    }

    public void PlantDieSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(PlantDieEvent, gameObject);
    }

    public void PlantEatSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(PlantEatEvent, gameObject);
    }

    public void SeedPickSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(SeedPickEvent, gameObject);

    }

    public void SeedPlantSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(SeedPlantEvent, gameObject);
    }

    public void UIClickSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(UIClick, gameObject);
    }

    public void UIMoveSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(UIMove, gameObject);
    }

}
