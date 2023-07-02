using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Modules
{
    public class DigitModule : Module
    {
        [SerializeField] private TMP_Text digitText;

        public override bool IsValidToClick => NumberContainsDigit(GameTime.TimeFromStart.Seconds) || NumberContainsDigit(GameTime.TimeFromStart.Minutes);

        private char currentDigit;


        private void Start()
        {
            Refresh();
        }


        public override void OnClick()
        {
            base.OnClick();

            Refresh();
        }


        private void Refresh()
        {
            currentDigit = (char)('0' + Random.Range(0, 10));
            digitText.text = currentDigit.ToString();
        }

        private bool NumberContainsDigit(int number, int maxLen = 2)
            => number.ToString().PadLeft(maxLen, '0').Contains(currentDigit);
    }
}