using JetBrains.Annotations;
using UnityEngine;

namespace StateExt
{
    public static class StatesExtensions
    {
        public static float GetRandomVoiceDelay(this StateMachineBehaviour stateMachineBehaviour)
        {
            return Random.Range(5.0f,10.0f);
        }
    }

}
