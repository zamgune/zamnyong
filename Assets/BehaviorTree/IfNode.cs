using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// true : Success, false : Failure
    /// </summary>
    public class IfNode : BaseNode
    {
        private Func<bool> _delIf;

        public IfNode(Func<bool> del)
        {
            _delIf = del;
        }

        public override BTState Action()
        {
            if (_delIf != null && _delIf.Invoke())
                return BTState.Success;
            else
                return BTState.Failure;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}