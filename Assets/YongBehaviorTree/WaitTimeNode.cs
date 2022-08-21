using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public class WaitTimeNode : AbstractNode
    {
        private float _waitTime;
        private float _waitAccTime;

        public WaitTimeNode(float waitTime)
        {
            _waitTime = waitTime;
        }

        public override BTState Tick()
        {
            if (_waitAccTime < _waitTime)
            {
                _waitAccTime += Time.deltaTime;
                return BTState.Running;
            }
            return BTState.Success;
        }

        public override void Reset()
        {
            base.Reset();
            _waitAccTime = 0f;
        }
    }
}