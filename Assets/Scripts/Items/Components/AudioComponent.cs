using UnityEngine;

namespace DragDropGame.Items.Components
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip _pickUpSound;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayPickupSound()
        {
            _audioSource.PlayOneShot(_pickUpSound);
        }
    }
}