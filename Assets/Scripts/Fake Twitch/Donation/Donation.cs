using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Donation : MonoBehaviour
{
    [SerializeField] TMP_Text donorName;
    [SerializeField] TMP_Text donorDescription;
    [SerializeField] Animator animator;
    [SerializeField] private float donationInterval;
    [SerializeField][Range(0, 1)] private float donationChance;
    [SerializeField] private float donationDuration;
    [SerializeField] List<MessageSO> messageSOs = new List<MessageSO>();
    [SerializeField] FMODUnity.EventReference donationsfx;
    public bool hasDono;
    public bool donoActive {get { return !animator.GetCurrentAnimatorStateInfo(0).IsName("DonationInactive"); }}
    float donationCooldown;

    private void Start()
    {
        donationCooldown = donationInterval;
        hasDono = false;
    }

    private void Update()
    {
        if (donoActive)
        {
            hasDono = false;
            return;
        }

        donationCooldown -= Time.deltaTime;
        if (donationCooldown < 0)
        {
            float randompercent = Random.Range(0, 1);
            if (randompercent <= donationChance)
            {
                MessageSO randomMessage = messageSOs[Random.Range(0, messageSOs.Count)];
                ActivateDono(randomMessage);
                if (!hasDono)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(donationsfx);
                    hasDono = true;
                }    
            }
        }
    }

    public void ActivateDono(MessageSO mso)
    {
        donorName.text = mso.name;
        donorDescription.text = mso.content;
        animator.SetBool("DisplayDono", true);
        StartCoroutine(DeactivateDono());

    }

    private IEnumerator DeactivateDono()
    {
        yield return new WaitForSeconds(donationDuration);
        animator.SetBool("DisplayDono", false);
        donationCooldown = donationInterval;
    }
}
