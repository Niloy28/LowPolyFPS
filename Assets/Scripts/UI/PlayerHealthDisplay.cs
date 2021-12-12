using FPS.Player;
using TMPro;
using UnityEngine;

namespace FPS.UI
{
    public class PlayerHealthDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private TMP_Text healthText;

        private void Update()
        {
            healthText.text = string.Format("{0} / {1}", playerHealth.CurrentHealth, playerHealth.MaxHealth);
        }
    }
}