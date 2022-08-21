using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public enum BTState
    {
        Success,
        Failure,
        Running,
    }

    public abstract class AbstractNode
    {
        protected BTState _state;
        protected AbstractNode _parent;
        protected List<AbstractNode> _children = new();
        protected int _childIndex;

        public AbstractNode Parent => _parent;

        public virtual BTState Tick()
        {
            return BTState.Failure;
        }

        public void AddNode(AbstractNode node)
        {
            node.SetParent(this);
            _children.Add(node);
        }

        public void SetParent(AbstractNode node)
        {
            _parent = node;
        }

        public virtual void Reset()
        {
            _childIndex = 0;
            foreach (var child in _children)
            {
                child.Reset();
            }
        }
    }
}
