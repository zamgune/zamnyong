using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public class SequenceNode : AbstractNode
    {
        public override BTState Tick()
        {
            for (int i = _childIndex; i != _children.Count; ++i)
            {
                var child = _children[_childIndex];

                var status = child.Tick();
                if (status != BTState.Success)
                    return status;

                _childIndex++;
            }

            return BTState.Success;
        }
    }
}
