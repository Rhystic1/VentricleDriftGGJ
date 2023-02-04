using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{
    public static AudioDirector Instance;
    private FMOD.Studio.EventInstance EngineSpeedSound;
    private FMOD.Studio.EventInstance BPMSound;
    private FMOD.Studio.EventInstance StrafeSound;
    private FMOD.Studio.EventInstance RadarSound;
    public FMODUnity.EventReference EngineSpeedEvent;
    public FMODUnity.EventReference BPMEvent;
    public FMODUnity.EventReference StrafeEvent;
    public FMODUnity.EventReference RadarEvent;



    [SerializeField]
    [Range(0f, 1f)]
    private float EngineSpeed;
    [SerializeField]
    [Range(0f, 1f)]
    private float BPM;
    [SerializeField]
    [Range(0f, 1f)]
    private float Strafe;
    [SerializeField]
    [Range(0f, 1f)]
    private float Proximity;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        EngineSpeedSound = FMODUnity.RuntimeManager.CreateInstance(EngineSpeedEvent);
        BPMSound = FMODUnity.RuntimeManager.CreateInstance(BPMEvent);
        StrafeSound = FMODUnity.RuntimeManager.CreateInstance(StrafeEvent);
        RadarSound = FMODUnity.RuntimeManager.CreateInstance(RadarEvent);
        EngineSpeedSound.start();
        BPMSound.start();
        StrafeSound.start();
        RadarSound.start();
    }

    void Update()
    {
        EngineSpeedSound.setParameterByName("EngineSpeed", EngineSpeed);
        BPMSound.setParameterByName("BPM", BPM);
        StrafeSound.setParameterByName("Strafe", Strafe);
        RadarSound.setParameterByName("Proximity", Proximity);
    }

    public void ChangeEngineSpeed(float speed)
    {
        EngineSpeed = Mathf.Clamp(speed, 0f, 1f);
    }

    public void ChangeBPMSpeed(float speed)
    {
        BPM = Mathf.Clamp(speed, 0f, 1f);
    }

    public void ChangeStrafeSpeed(float speed)
    {
        Strafe = Mathf.Clamp(speed, 0f, 1f);
    }
    public void ChangeRadarSpeed(float speed)
    {
        Proximity = Mathf.Clamp(speed, 0f, 1f);
    }
}