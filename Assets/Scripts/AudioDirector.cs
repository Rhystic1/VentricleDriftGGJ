using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{

    public static AudioDirector Instance;
    private FMOD.Studio.EventInstance EngineSpeedSound;
    private FMOD.Studio.EventInstance MusicSound;
    private FMOD.Studio.EventInstance StrafeSound;
    private FMOD.Studio.EventInstance RadarSound;
    private FMOD.Studio.EventInstance TurningSound;
    private FMOD.Studio.EventInstance ImpactWallSound;
    private FMOD.Studio.EventInstance ImpactEnemySound;
    private FMOD.Studio.EventInstance BoostSound;
    private FMOD.Studio.EventInstance VirusDestroyedSound;
    public FMODUnity.EventReference EngineSpeedEvent;
    public FMODUnity.EventReference MusicEvent;
    public FMODUnity.EventReference StrafeEvent;
    public FMODUnity.EventReference RadarEvent;
    public FMODUnity.EventReference TurningEvent;
    public FMODUnity.EventReference ImpactWallEvent;
    public FMODUnity.EventReference ImpactEnemyEvent;
    public FMODUnity.EventReference BoostEvent;
    public FMODUnity.EventReference VirusDestroyedEvent;



    [SerializeField]
    [Range(0f, 1f)]
    private float EngineSpeed;
    [SerializeField]
    [Range(0f, 1f)]
    private float BPM;
    [SerializeField]
    [Range(0f, 1f)]
    private float MusicLevel;
    [SerializeField]
    [Range(0f, 1f)]
    private float Strafe;
    [SerializeField]
    [Range(0f, 1f)]
    private float Proximity;
    [SerializeField]
    [Range(0f, 1f)]
    private float TurnSpeed;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }

    void Start()
    {
        EngineSpeedSound = FMODUnity.RuntimeManager.CreateInstance(EngineSpeedEvent);
        MusicSound = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
        StrafeSound = FMODUnity.RuntimeManager.CreateInstance(StrafeEvent);
        RadarSound = FMODUnity.RuntimeManager.CreateInstance(RadarEvent);
        TurningSound = FMODUnity.RuntimeManager.CreateInstance(TurningEvent);
        ImpactWallSound = FMODUnity.RuntimeManager.CreateInstance(ImpactWallEvent);
        ImpactEnemySound = FMODUnity.RuntimeManager.CreateInstance(ImpactEnemyEvent);
        BoostSound = FMODUnity.RuntimeManager.CreateInstance(BoostEvent);
        VirusDestroyedSound = FMODUnity.RuntimeManager.CreateInstance(VirusDestroyedEvent);
        EngineSpeedSound.start();
        MusicSound.start();
        StrafeSound.start();
        RadarSound.start();
        TurningSound.start();

        ChangeBPMSpeed(0.5f);
        ChangeMusicLevel(1f);
    }

    void Update()
    {
        EngineSpeedSound.setParameterByName("EngineSpeed", EngineSpeed);
        MusicSound.setParameterByName("BPM", BPM);
        MusicSound.setParameterByName("MusicLevel", MusicLevel);
        StrafeSound.setParameterByName("Strafe", Strafe);
        RadarSound.setParameterByName("Proximity", Proximity);
        TurningSound.setParameterByName("TurnSpeed", TurnSpeed);

    }

    public void ChangeEngineSpeed(float speed)
    {
        EngineSpeed = Mathf.Clamp(speed, 0f, 1f);
    }

    public void ChangeBPMSpeed(float speed)
    {
        BPM = Mathf.Clamp(speed, 0f, 1f);
    }

    public void ChangeMusicLevel(float speed)
    {
        MusicLevel = Mathf.Clamp(speed, 0f, 1f);
    }

    public void ChangeStrafeSpeed(float speed)
    {
        Strafe = Mathf.Clamp(speed, 0f, 1f);
    }
    public void ChangeRadarSpeed(float speed)
    {
        Proximity = Mathf.Clamp(speed, 0f, 1f);
    }
    public void ChangeTurnSpeed(float speed)
    {
        TurnSpeed = Mathf.Clamp(speed, 0f, 1f);
    }
    public void ImpactWall()
    {
        ImpactWallSound.start();
    }
    public void ImpactEnemy()
    {
        ImpactEnemySound.start();
    }    
    public void Boost()
    {
        BoostSound.start();
    }
    public void VirusDestroyed()
    {
        VirusDestroyedSound.start();
    }
}