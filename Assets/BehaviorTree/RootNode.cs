using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class RootNode : BaseNode
    {
        public override BTState Action()
        {
            BTState state;
            foreach (var node in _children)
            {
                state = node.Action();
                if (state != BTState.Running)
                    node.Reset();
            }

            return BTState.Success;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}
