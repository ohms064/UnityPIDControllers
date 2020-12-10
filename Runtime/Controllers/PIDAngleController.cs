using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OhmsLibraries.Controllers {
    [System.Serializable]
    public class PIDAngleController : PIDFloatController {

        public override float Seek ( float seekValue, float currentValue, float deltaTime ) {
            if ( seekValue > 180f ) seekValue -= 180f;
            if ( currentValue > 180f ) currentValue -= 180f;
            return base.Seek( seekValue, currentValue, deltaTime );
        }
    }
}
