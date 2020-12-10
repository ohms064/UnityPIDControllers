//The class handles calculating a desired value based on a PID algorithm
//This code is not specific to this game and is instead how PID algorithms work
//in electronics, robotics, and controlling software
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;
namespace OhmsLibraries.Controllers {
    [System.Serializable]
    public class PIDFloatController : PIDController<float> {

        [SerializeField]
        private bool _clampPID = false;

        [SerializeField]
#if ODIN_INSPECTOR
        [MinMaxSlider (-10, 10, true), HideIf ("_clampPID")]
#endif
        private Vector2 _outputClamp = new Vector2 (-1, 1);

        public override float Seek (float seekValue, float currentValue, float deltaTime) {
            float proportional = seekValue - currentValue;

            float derivative = (proportional - lastProportional) / deltaTime;
            integral += proportional * deltaTime;
            lastProportional = proportional;

            //This is the actual PID formula. This gives us the value that is returned
            float value = pCoeff * proportional + iCoeff * integral + dCoeff * derivative;
            if (_clampPID) value = Mathf.Clamp (value, _outputClamp.x, _outputClamp.y);

            return value;
        }
    }
}