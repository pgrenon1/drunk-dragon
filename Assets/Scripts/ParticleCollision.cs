using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ParticleCollision : MonoBehaviour {

    public AudioSource BuildingAudio;

    private void OnParticleCollision(GameObject other)
    {
        Building b = other.GetComponent<Building>();
        if (b != null)
        {
            b.Health--;
            if (b.Health <= 0)
            {
                GameManager.Instance.Score += 1000;
                GameManager.Instance.ScoreText.transform.DOShakeScale(0.5f);
                BuildingAudio.Play();
                GameManager.Instance.ShakeCamera();
                if (GameManager.Instance.IsDrunk)
                {
                    GameManager.Instance.Drunkness += 1;
                }
                Destroy(b.gameObject);
            }
        }
    }


}
