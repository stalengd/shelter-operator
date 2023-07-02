using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
    public class SwitchesModule : Module
    {
        [SerializeField] private Switch[] switches;
        [SerializeField] private RectTransform arrow;

        public override bool IsValidToClick => switches.All(s => s.IsOn == currentDirection);
        public override bool PenaltyForFail => false;

        private bool currentDirection;


        private void Start()
        {
            foreach (var s in switches)
            {
                s.Toggle.onValueChanged.AddListener(v => OnClick());
            }

            Refresh();
        }


        public override void OnClick()
        {
            base.OnClick();

            if (IsValidToClick)
                Refresh();
        }


        private void Refresh()
        {
            currentDirection = RandomBool();
            arrow.localRotation = Quaternion.Euler(0f, 0f, currentDirection ? 0f : 180f);

            foreach (var s in switches)
            {
                s.IsOn = RandomBool();
            }
        }

        private bool RandomBool()
            => Random.Range(0, 2) == 0 ? false : true;
    }
}