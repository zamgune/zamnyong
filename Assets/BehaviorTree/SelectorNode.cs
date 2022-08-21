using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class SelectorNode : BaseNode
    {
        public override BTState Action()
        {
            BaseNode child;
            for ( ; _childIndex < _children.Count; ++_childIndex)
            {
                child = _children[_childIndex];
                switch (child.Action())
                {
                    case BTState.Failure:
                        continue;
                    case BTState.Success:
                        return BTState.Success;
                    case BTState.Running:
                        return BTState.Running;
                }
            }

            return BTState.Failure;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}