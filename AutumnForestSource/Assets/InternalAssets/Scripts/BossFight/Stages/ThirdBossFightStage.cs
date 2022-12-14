using AutumnForest.BossFight.Raccoon;
using AutumnForest.Other;
using CreaturesAI;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight
{
    public class ThirdBossFightStage : State
    {
        //health barPresets
        [SerializeField] private HealthBarPreset raccoonPreset;
        [SerializeField] private HealthBar bossHealthBar;

        public float StateTransitionDelay { get; }

        public void EnterState(StateMachine stateMachine)
        {
            RaccoonStateMachine raccoonStateMachine = GlobalServiceLocator.GetService<RaccoonStateMachine>();

            raccoonPreset.HealthTarget = raccoonStateMachine.GetComponent<Health>();
            GlobalServiceLocator.GetService<MainCameraBrain>().SetTargets(raccoonStateMachine.gameObject);
            bossHealthBar.SetPreset(raccoonPreset);
            raccoonStateMachine.StateChoosing();
        }

        public void ExitState(StateMachine stateMachine) { bossHealthBar.gameObject.SetActive(false); }

        public void UpdateState(StateMachine stateMachine) { }
    }
}