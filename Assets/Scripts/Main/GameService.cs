using ServiceLocator.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService {  get; private set; }

    [SerializeField] PlayerScriptableObject playerScriptableObject;

    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
    }
    private void Update()
    {
        if (playerService != null)
        {
            playerService.Update();
        }
    }
}
