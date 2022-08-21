using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class LogNode : BaseNode
    {
        private string _message;

        public LogNode(string message)
        {
            _message = message;
        }

        public override BTState Action()
        {
            if (!string.IsNullOrEmpty(_message))
                Debug.Log(_message);
            return BTState.Success;
        }
    }
}