using FPS.Player;
using TMPro;
using UnityEngine;

namespace FPS.UI
{
    public class PlayerAmmoDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerAction playerAction;
        [SerializeField] private TMP_Text totalAmmoText;
        [SerializeField] private TMP_Text magazineText;

        private void Update()
        {
            totalAmmoText.text = string.Format("Total Ammo: {0}", playerAction.CurrentAmmoCount);
            magazineText.text = string.Format("{0} / {1}", playerAction.BulletsInMagazine, playerAction.MagazineSize);
        }
    }
}