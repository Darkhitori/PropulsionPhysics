using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polycrime;
using System.Linq;


namespace Darkhitori.PlaymakerActions._PropulsionPhysics
{
    using HutongGames.PlayMaker;

    [ActionCategory("PropulsionPhysics")]
    [Tooltip("Lets you set how long the propelled object should take to reach the target based on the editor’s gravity.")]
    public class ReachTime : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(PropulsionPad))]
        public FsmOwnerDefault gameObject;
        
        [Tooltip("")]
        public FsmFloat reachTime;

        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        PropulsionPad proComp;
        
        public override void Reset()
        {
            gameObject = null;
            reachTime =  1.5f;
            everyFrame = false;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
        {
            DoMethod();
            if (!everyFrame)
            {
                Finish();
            }
        }
        
        public override void OnUpdate()
        {
            DoMethod();
        }

        void DoMethod()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(go == null)
            {
                return;
            }
            
            proComp = go.GetComponent<PropulsionPad>();
            
            proComp.reachTime = reachTime.Value;
            
        }


    }

}
