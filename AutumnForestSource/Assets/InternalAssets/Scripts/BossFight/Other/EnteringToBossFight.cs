using AutumnForest.BossFight;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.Other;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class EnteringToBossFight : MonoBehaviour, IInteractive
    {
        [SerializeField] private GameObject log;
        [SerializeField] private GameObject healthBar;
        [SerializeField] private float cameraSizeOnBossFight = 7f;

        public UnityEvent OnInteract { get; set; } = new();

        event Action IInteractive.OnInteract
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void Start()
        {
            log.SetActive(false);
            healthBar.SetActive(false);
        }

        public void Interact()
        {
            log.SetActive(true);
            healthBar.SetActive(true);

            MainCameraBrain camera = GlobalServiceLocator.GetService<MainCameraBrain>();

            camera.SetTargets(GlobalServiceLocator.GetService<RaccoonStateMachine>().gameObject);
            camera.ChangeOrthographicSize(cameraSizeOnBossFight);

            GlobalServiceLocator.GetService<BossFightController>().StateMachine.EnableStateMachine();
            GlobalServiceLocator.GetService<BossFightController>().StateChoosing();

            Destroy(this);
        }
    }
}