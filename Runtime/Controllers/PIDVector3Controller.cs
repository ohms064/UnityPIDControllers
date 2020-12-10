using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OhmsLibraries.Controllers {
    [System.Serializable]
    public class PIDVector3Controller : PIDController<Vector3> {
        public override Vector3 Seek ( Vector3 seekValue, Vector3 currentValue, float deltaTime ) {
            var proportional = seekValue - currentValue;

            var derivative = ( proportional - lastProportional ) / deltaTime;
            integral += proportional * deltaTime;
            lastProportional = proportional;

            //This is the actual PID formula. This gives us the value that is returned
            var value = pCoeff * proportional + iCoeff * integral + dCoeff * derivative;

            return value;
        }
    }
}
