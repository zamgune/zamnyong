using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public class SelectorNode : AbstractNode
    {
        public override BTState Tick()
        {
            for (int i = _childIndex; i != _children.Count; ++i)
            {
                var child = _children[_childIndex];

                var status = child.Tick();
                switch (status)
                {
                    case BTState.Success:
                        return BTState.Success;
                    case BTState.Running:
                        return BTState.Running;
                }

                _childIndex++;
            }

            return BTState.Failure;
        }
    }
}
