using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OhmsLibraries.Controllers {
    //Not sure why you would use this, but operations are available so why not.
    [System.Serializable]
    public class PIDColorController : PIDController<Color> {
        public override Color Seek ( Color seekValue, Color currentValue, float deltaTime ) {
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