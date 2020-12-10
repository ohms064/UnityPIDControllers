using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace OhmsLibraries.Controllers {
    public abstract class PIDController<T> {
        //Our PID coefficients for tuning the controller
        [HorizontalGroup( "PID", LabelWidth = 15 ), LabelText( "P" )]
        public float pCoeff = .8f;
        [HorizontalGroup( "PID", LabelWidth = 15 ), LabelText( "I" )]
        public float iCoeff = .0002f;
        [HorizontalGroup( "PID", LabelWidth = 15 ), LabelText( "D" )]
        public float dCoeff = .2f;

        //Variables to store values between calculations
        protected T integral;
        protected T lastProportional;

        //We pass in the value we want and the value we currently have, the code
        //returns a number that moves us towards our goal
        //P = seekValue - currentValue
        //I += P * deltaTime 
        //D = (P - PreviousP) / deltaTime 
        public abstract T Seek ( T seekValue, T currentValue, float deltaTime );
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