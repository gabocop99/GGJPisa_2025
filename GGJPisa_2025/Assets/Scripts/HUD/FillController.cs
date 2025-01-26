using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class FillController : MonoBehaviour
    {
        public Image fillImage;
        private float fillAmount = 1;

        public void UpdateFill(float currentAmount, float maxAmount)
        {
            fillAmount = currentAmount / maxAmount;

            fillImage.fillAmount = fillAmount;
        }
    }
}