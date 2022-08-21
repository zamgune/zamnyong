using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class BehaviorTreeBuilder
    {
        private BaseNode _root;
        private BaseNode _parent;

        public BehaviorTreeBuilder()
        {
            _root = new RootNode();
            _parent = _root;
        }

        public BehaviorTreeBuilder AddComposite(BaseNode node)
        {
            _parent.Add(node);
            _parent = node;
            return this;
        }

        public BehaviorTreeBuilder AddDecorator(BaseNode node)
        {
            _parent.Add(node);
            return this;
        }

        public BehaviorTreeBuilder End()
        {
            _parent = _parent.Parent;
            return this;
        }

        public BaseNode Build()
        {
            return _root;
        }
    }
}