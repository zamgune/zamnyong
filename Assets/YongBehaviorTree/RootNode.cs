using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public class RootNode : AbstractNode
    {
        public override BTState Tick()
        {
            foreach (var child in _children)
            {
                var state = child.Tick();
                if (state != BTState.Running)
                {
                    child.Reset();
                }
            }

            return BTState.Success;
        }
    }
}