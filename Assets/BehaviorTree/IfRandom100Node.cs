using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class IfRandom100Node : BaseNode
    {
        private float _rate;

        public IfRandom100Node(float rate)
        {
            _rate = rate;
        }

        public override BTState Action()
        {
            var rn = Random.Range(0, 100);
            if (rn < _rate)
                return BTState.Success;
            else
                return BTState.Failure;
        }
    }
}
