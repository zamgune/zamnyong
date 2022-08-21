using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YongBehaviorTree;

public class BehaviorTest : MonoBehaviour
{
    AbstractNode _root;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sequnce테스트");
        TestSequnce();
        Debug.Log("Selector테스트");
        TestSelector();
    }

    private void TestWhile()
    {
        BehaviorTreeBuilder behaviorTreeBuilder = new BehaviorTreeBuilder();
        behaviorTreeBuilder
            .Selector()
                .Sequence()
                    .Action(() =>
                    {
                        Debug.Log("시작");
                        return BTState.Failure;
                    })
                .End()
                .Sequence()
                    .ReturnFailure()
                        .WaitTime(3f)
                            .Action(() =>
                            {
                                Debug.Log("Action");
                                return BTState.Success;
                            })
                    .End()
                .End()
            .End();

        _root = behaviorTreeBuilder.Build();
    }

    private void TestIf()
    {
        bool test = false;

        BehaviorTreeBuilder behaviorTreeBuilder = new BehaviorTreeBuilder();
        behaviorTreeBuilder
            .Sequence()
                .IF(() => test)
                    .Action(() =>
                    {
                        Debug.Log("Action");
                        return BTState.Success;
                    })
                    .Action(() =>
                    {
                        Debug.Log("Action2");
                        return BTState.Failure;
                    })
            .End();

        AbstractNode root = behaviorTreeBuilder.Build();
        root.Tick();
    }

    private void TestSequnce()
    {
        BehaviorTreeBuilder behaviorTreeBuilder = new BehaviorTreeBuilder();
        behaviorTreeBuilder
            .Sequence()
                .Action(() =>
                {
                    Debug.Log("Action");
                    return BTState.Success;
                })
                .Action(() =>
                {
                    Debug.Log("Action2");
                    return BTState.Failure;
                })
            .End();

        AbstractNode root = behaviorTreeBuilder.Build();
        root.Tick();
    }

    private void TestSelector()
    {
        BehaviorTreeBuilder behaviorTreeBuilder = new BehaviorTreeBuilder();
        behaviorTreeBuilder
            .Selector()
                .Action(() =>
                {
                    Debug.Log("Action");
                    return BTState.Failure;
                })
                .Action(() =>
                {
                    Debug.Log("Action2");
                    return BTState.Success;
                })
            .End();

        AbstractNode root = behaviorTreeBuilder.Build();
        root.Tick();
    }
}
