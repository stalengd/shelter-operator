using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
    public class SectorModule : Module
    {
        [SerializeField] private float speed = 10f;
        [SerializeField, Range(0f, 1f)] private float minFill = 0.2f;
        [SerializeField, Range(0f, 1f)] private float maxFill = 0.5f;

        [Space]
        [SerializeField] private Transform rotor; 
        [SerializeField] private Transform sectorTransform; 
        [SerializeField] private Image sectorImage;

        public override bool IsValidToClick
        {
            get
            {
                var cursor = rotor.eulerAngles.z;
                var rotMax = sectorTransform.eulerAngles.z;

                var delta = Mathf.DeltaAngle(rotMax, cursor);

                if (cursor > 180f && rotMax < 180f)
                    rotMax += 360f;

                var r = cursor <= rotMax && Mathf.Abs(delta) < sectorImage.fillAmount * 360f;
                return r;
            }
        }


        private void Start()
        {
            Refresh();
        }

        private void Update()
        {
            rotor.Rotate(0f, 0f, speed * Time.deltaTime);
        }

        private void Refresh()
        {
            sectorTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360));
            sectorImage.fillAmount = Random.Range(minFill, maxFill);
        }


        public override void OnClick()
        {
            base.OnClick();

            Refresh();
        }
    }
}