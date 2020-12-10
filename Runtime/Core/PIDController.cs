using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace OhmsLibraries.Controllers {
    public abstract class PIDController<T> {
        //Our PID coefficients for tuning the controller
#if ODIN_INSPECTOR
        [HorizontalGroup ("PID", LabelWidth = 15), LabelText ("P")]
#endif
        public float pCoeff = .8f,
        iCoeff = .0002f,
        dCoeff = .2f;

        //Variables to store values between calculations
        protected T integral;
        protected T lastProportional;

        //We pass in the value we want and the value we currently have, the code
        //returns a number that moves us towards our goal
        //P = seekValue - currentValue
        //I += P * deltaTime 
        //D = (P - PreviousP) / deltaTime 
        public abstract T Seek (T seekValue, T currentValue, float deltaTime);
        /*
            var proportional = seekValue - currentValue;

            var derivative = ( proportional - lastProportional ) / deltaTime;
            integral += proportional * deltaTime;
            lastProportional = proportional;

            //This is the actual PID formula. This gives us the value that is returned
            var value = pCoeff * proportional + iCoeff * integral + dCoeff * derivative;

            return value;
         * */
    }
}