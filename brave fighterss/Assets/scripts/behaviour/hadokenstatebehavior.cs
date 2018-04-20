using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hadokenstatebehavior : fighterstatebehaviour

{
    override public  void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
      float fighterx = fighters.transform.position.x;


        GameObject instance = Object.Instantiate(
            Resources.Load("sfx/hadooken"),
            new Vector3(fighterx, 1, 0),
            Quaternion.Euler(0, 0, 0)
            ) as GameObject;

        hadoken hadoken = instance.GetComponent<hadoken>();
        hadoken.caster = fighters;
    }
}
