using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
    public class SearchModule : Module
    {
        [SerializeField] private Image targetImage;
        [SerializeField] private Image[] otherImages;

        [Space]
        [SerializeField] private Sprite[] sprites;

        public override bool IsValidToClick => currentChoice == rightChoice;

        private int rightChoice;
        private int currentChoice = -1;


        private void Start()
        {
            Refresh();
        }


        public void OnClick(int choice)
        {
            currentChoice = choice;

            OnClick();
        }

        public override void OnClick()
        {
            base.OnClick();

            Refresh();
        }


        private void Refresh()
        {
            rightChoice = Random.Range(0, otherImages.Length);
            currentChoice = -1;

            var targetSprite = sprites.Random();
            targetImage.sprite = targetSprite;
            otherImages[rightChoice].sprite = targetSprite;

            var otherSprites = sprites
                .Except(Enumerable.Repeat(targetSprite, 1))
                .Shuffle()
                .ToList();

            for (int i = 0; i < otherImages.Length; i++)
            {
                if (i == rightChoice) continue;

                otherImages[i].sprite = otherSprites[i];
            }
        }
    }
}