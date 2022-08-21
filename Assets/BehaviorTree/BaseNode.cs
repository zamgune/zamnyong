using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public enum BTState
    {
        Success,
        Failure,
        Running,
    }

    public abstract class BaseNode
    {
        protected BTState _state;
        protected BaseNode _parent;
        protected List<BaseNode> _children = new List<BaseNode>();
        protected int _childIndex;

        public BaseNode Parent => _parent;

        public void Add(BaseNode node)
        {
            node.SetParent(this);
            _children.Add(node);
        }

        public void SetParent(BaseNode node)
        {
            _parent = node;
        }

        public virtual BTState Action()
        {
            return BTState.Failure;
        }

        public virtual void Reset()
        {
            _childIndex = 0;
            foreach (var node in _children)
            {
                node.Reset();
            }
        }
    }
}