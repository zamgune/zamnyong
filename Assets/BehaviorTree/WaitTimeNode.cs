using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class WaitTimeNode : BaseNode
    {
        private float _waitTime;
        private float _curTime;

        public WaitTimeNode(float time)
        {
            _curTime = 0;
            _waitTime = time;
        }

        public override BTState Action()
        {
            _curTime += Time.deltaTime;
            if (_curTime < _waitTime)
                return BTState.Running;
            else
                return BTState.Success;
        }

        public override void Reset()
        {
            base.Reset();

            _curTime = 0;
        }
    }
}
