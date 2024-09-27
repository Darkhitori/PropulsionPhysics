using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polycrime;
using System.Linq;


namespace Darkhitori.PlaymakerActions._PropulsionPhysics
{
    using HutongGames.PlayMaker;

    [ActionCategory("PropulsionPhysics")]
    [Tooltip("The Transform object that the propulsion script will propel the object to.")]
    public class Target : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(PropulsionPad))]
        public FsmOwnerDefault gameObject;
        
        [Tooltip("")]
        public FsmGameObject target;

        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;

        PropulsionPad proComp;
        
        public override void Reset()
        {
            gameObject = null;
            target =  null;
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
            
            proComp.target = target.Value.transform;
            
        }


    }

}
