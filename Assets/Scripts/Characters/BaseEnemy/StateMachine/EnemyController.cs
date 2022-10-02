using CCS.SoundPlayer;
using Makardwaj.Characters.Enemy.States;

namespace Makardwaj.Characters.Enemy.Base
{
    public class EnemyController : BaseEnemyController
    {
        #region StateMachine

        protected  override void InitializeStateMachine()
        {
            base.InitializeStateMachine();
            _stateMachine.Initialize(PatrolState);
        }

        public override void SpawnBody()
        {
            base.SpawnBody();

            SoundManager.Instance.PlaySFX(MixerPlayer.Interactions, "mushroomDie", 0.5f, false);
        }
        #endregion
    }
}