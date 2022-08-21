using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public class RepeatUntilFailureNode : AbstractNode
    {
        public override BTState Tick()
        {
            var state = _children[0].Tick();
            if (state == BTState.Failure)
                return BTState.Failure;

            return BTState.Running;
        }
    }
}