using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class SequenceNode : BaseNode
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
                        return BTState.Failure;
                    case BTState.Success:
                        continue;
                    case BTState.Running:
                        return BTState.Running;
                }
            }

            return BTState.Success;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}