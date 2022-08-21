using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public class ReturnRunningToFailureNode : AbstractNode
    {
        public override BTState Tick()
        {
            var status = _children[0].Tick();
            if (status == BTState.Running)
                return BTState.Failure;

            _children[1].Tick();
            _children[0].Reset();
            return BTState.Success;
        }

        public override void Reset()
        {
            
        }
    }
}