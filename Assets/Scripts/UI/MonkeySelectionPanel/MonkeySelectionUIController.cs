using ServiceLocator.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator.UI
{
    public class MonkeySelectionUIController
    {
        private UIService uiService;
        private Transform cellContainer;
        private List<MonkeyCellController> monkeyCellControllers;

        public MonkeySelectionUIController(PlayerService playerService, UIService uIService, Transform cellContainer, MonkeyCellView monkeyCellPrefab, List<MonkeyCellScriptableObject> monkeyCellScriptableObjects)
        {
            this.uiService = uIService;
            this.cellContainer = cellContainer;
            monkeyCellControllers = new List<MonkeyCellController>();

            foreach (MonkeyCellScriptableObject monkeySO in monkeyCellScriptableObjects)
            {
                MonkeyCellController monkeyCell = new MonkeyCellController(playerService, uiService, cellContainer, monkeyCellPrefab, monkeySO);
                monkeyCellControllers.Add(monkeyCell);
            }
        }

        public void SetActive(bool setActive) => cellContainer.gameObject.SetActive(setActive);

    }
}