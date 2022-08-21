using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace YongBehaviorTree
{
    public class ActionNode : AbstractNode
    {
        private Func<BTState> _func;

        public ActionNode(Func<BTState> func)
        {
            _func = func;
        }

        public override BTState Tick()
        {
            return _func.Invoke();
        }
    }
}