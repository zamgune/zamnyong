using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// true : Running, false : Success
    /// </summary>
    public class WaitIfNode : BaseNode
    {
        private Func<bool> _delIf;

        public WaitIfNode(Func<bool> del)
        {
            _delIf = del;
        }

        public override BTState Action()
        {
            if (_delIf != null && _delIf.Invoke())
                return BTState.Running;
            else
                return BTState.Success;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}
