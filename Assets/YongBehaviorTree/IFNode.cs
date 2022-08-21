using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace YongBehaviorTree
{
    public class IFNode : AbstractNode
    {
        private Func<bool> _func;

        public IFNode(Func<bool> func)
        {
            _func = func;
        }

        public override BTState Tick()
        {
            return _func.Invoke() ? BTState.Success : BTState.Failure;
        }
    }
}