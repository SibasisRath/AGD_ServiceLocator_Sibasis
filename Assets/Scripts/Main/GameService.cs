using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService {  get; private set; }
    public SoundService soundService { get; private set; }
    public UIService UIService => uIService;

    public EventService eventService { get; private set; }
    public MapService mapService { get; private set; }

    public WaveService waveService { get; private set; }

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private UIService uIService;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    private void Start()
    {
        // Services:
        public EventService EventService { get; private set; }
        public MapService MapService { get; private set; }
        public WaveService WaveService { get; private set; }
        public SoundService SoundService { get; private set; }
        public PlayerService PlayerService { get; private set; }

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;


        // Scriptable Objects:
        [SerializeField] private MapScriptableObject mapScriptableObject;
        [SerializeField] private WaveScriptableObject waveScriptableObject;
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        // Scene Referneces:
        [SerializeField] private AudioSource SFXSource;
        [SerializeField] private AudioSource BGSource;

        private void Start()
        {
            EventService = new EventService();
            UIService.SubscribeToEvents();
            MapService = new MapService(mapScriptableObject);
            WaveService = new WaveService(waveScriptableObject);
            SoundService = new SoundService(soundScriptableObject, SFXSource, BGSource);
            PlayerService = new PlayerService(playerScriptableObject);
        }

        private void Update()
        {
            PlayerService.Update();
        }
    }
}
