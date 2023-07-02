using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules
{
    public abstract class Module : MonoBehaviour
    {
        [SerializeField] private Room bindedRoom;
        [SerializeField] private SuccessIndicator successIndicator;

        public abstract bool IsValidToClick { get; }
        public virtual bool PenaltyForFail => true;

        public virtual void OnClick()
        {
            var success = IsValidToClick;

            if (success)
            {
                successIndicator.Success();
                if (bindedRoom != null) 
                {
                    if (bindedRoom.Fulfill())
                        GameManager.AddHpBySuccess();
                }
            }
            else if (PenaltyForFail)
            {
                successIndicator.Fail();
                GameManager.ReduceHpByFail();
            }
        }
    }
}