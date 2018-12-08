namespace CSFramework
{
    public class LemonScript : CustomSlot

    {
        public  void LemonHit (HitInfo info)
        {
            base.ProcessHit(info);
            for (int m = 0; m < reels.Length - 2; m++)
                {
                    for (int w = 0; w <reels[m].GetComponent<Reel>().symbolHolders.Count; w++)
                    {
                //        if (reels[m].symbolHolders[w].GetComponent<Image>().sprite.name == "S4" && reels[m + 1].symbolHolders[w].GetComponent<Image>().sprite.name == reels[m].symbolHolders[w].GetComponent<Image>().sprite.name
                  // && reels[m + 2].symbolHolders[w].GetComponent<Image>().sprite.name == reels[m].symbolHolders[w].GetComponent<Image>().sprite.name)
                        {
                            reels[m].symbolHolders[w].animator.SetTrigger("SunriseTrigger");
                            reels[m + 1].symbolHolders[w].animator.SetTrigger("SunriseTrigger");
                            reels[m + 2].symbolHolders[w].animator.SetTrigger("SunriseTrigger");
                            print("blaLemonScript");
                        }


                    }

             
            }


        //    if (info.hitSymbol.payType == Symbol.PayType.Normal) RefreshMoney();
         //   RefreshRoundInfo();
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}
    }
}
