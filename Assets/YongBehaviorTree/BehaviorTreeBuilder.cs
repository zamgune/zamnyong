using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YongBehaviorTree
{
    public class BehaviorTreeBuilder
    {
        private AbstractNode _root;
        private AbstractNode _parent;

        public BehaviorTreeBuilder()
        {
            _root = new RootNode();
            _parent = _root;
        }

        public BehaviorTreeBuilder Action(Func<BTState> action)
        {
            return AddDecorator(new ActionNode(action));
        }

        public BehaviorTreeBuilder Sequence()
        {
            return AddComposite(new SequenceNode());
        }

        public BehaviorTreeBuilder Selector()
        {
            return AddComposite(new SelectorNode());
        }

        public BehaviorTreeBuilder IF(Func<bool> func)
        {
            Debug.Assert(func != null);
            return AddDecorator(new IFNode(func));
        }

        public BehaviorTreeBuilder RepeatUntilFailure()
        {
            return AddComposite(new RepeatUntilFailureNode());
        }

        public BehaviorTreeBuilder WaitTime(float waitTime)
        {
            return AddDecorator(new WaitTimeNode(waitTime));
        }

        public BehaviorTreeBuilder ReturnFailure()
        {
            return AddComposite(new ReturnRunningToFailureNode());
        }

        public BehaviorTreeBuilder End()
        {
            _parent = _parent.Parent;
            return this;
        }

        public AbstractNode Build()
        {
            return _root;
        }

        private BehaviorTreeBuilder AddComposite(AbstractNode node)
        {
            _parent.AddNode(node);
            _parent = node;
            return this;
        }

        private BehaviorTreeBuilder AddDecorator(AbstractNode node)
        {
            _parent.AddNode(node);
            return this;
        }
    }
}