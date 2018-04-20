using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighterstatebehaviour : StateMachineBehaviour {


    public AudioClip SoundEffect;
    public float horizontailForce;
	public float verticalForce;
    

	public fighterstate behavoiurState;
	protected  fighter fighters;
  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo , int layerIndex){
		if (fighters==null )
		{
			fighters = animator.gameObject.GetComponent<fighter>();
		}
		fighters.CurrentState = behavoiurState;
       if(SoundEffect != null)
        {
            fighters.PlaySounds(SoundEffect);
        }
		fighters.body.AddRelativeForce (new Vector3 (0, verticalForce,0));
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo , int layerIndex){

		fighters.body.AddRelativeForce (new Vector3(0, horizontailForce,0));
	}
}
