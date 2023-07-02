using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules
{
    public class LampModule : Module
    {
        [SerializeField] private float frequency = 1f;

        [Space]
        [SerializeField] private GameObject indicator;

        public override bool IsValidToClick => timer * 2f >= 1f / frequency;

        private float timer;


        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= 1f / frequency)
                timer -= 1f / frequency;
            indicator.SetActive(IsValidToClick);
        }
    }
}