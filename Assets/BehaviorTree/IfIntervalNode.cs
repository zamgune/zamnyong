using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class IfIntervalNode : BaseNode
    {
        private float _nextTime;
        private float _interval;

        public IfIntervalNode(float interval)
        {
            _nextTime = 0;
            _interval = interval;
        }

        public override BTState Action()
        {
            if (_nextTime < Time.realtimeSinceStartup)
            {
                _nextTime = Time.realtimeSinceStartup + _interval;
                return BTState.Success;
            }
            else
                return BTState.Failure;
        }
    }
}
