using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polycrime;
using HutongGames.PlayMaker;

public class PlaymakerEventPropulsionPad : PropulsionPad
{
    [UnityEngine.Tooltip("Name of the Playmaker Fsm to use")]
    public string fsmName;
        
    [UnityEngine.Tooltip("Name of the Playmaker Event to call from above FSM")]
    public string fsmEvent;
        
    PlayMakerFSM theFsm;
    
    protected override bool PropelObject(GameObject propelObject,Vector3 velocity)
    {
        if(base.PropelObject(propelObject, velocity))
        {
            PlayMakerFSM[] temp = GetComponentsInChildren<PlayMakerFSM>();
            foreach (PlayMakerFSM fsm in temp)
            {

                if (fsm.FsmName == fsmName)
                {
                    theFsm = fsm;
                    break;
                }
            }
            
            theFsm.SendEvent(fsmEvent);
        }
        
        return true;
    }

}
