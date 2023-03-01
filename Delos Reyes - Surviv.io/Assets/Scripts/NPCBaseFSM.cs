using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject[] opponents;
    public float speed = 2.0f,
                rotSpeed = 1.0f,
                accuracy = 3.0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      NPC = animator.gameObject;
      opponents = NPC.GetComponent<EnemyAI>().GetOpponents(); //will rasie an error bc no tankai class yet
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
