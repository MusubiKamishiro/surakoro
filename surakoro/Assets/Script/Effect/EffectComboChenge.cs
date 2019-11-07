using Effekseer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectComboChenge : MonoBehaviour
{
    [SerializeField]
    List<EffekseerEffectAsset> effectAsset = new List<EffekseerEffectAsset>();

    PlayerCollider playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<PlayerCollider>();
    }

    public EffekseerEffectAsset EffectAsset
    {
        get { return effectAsset[playerCollider.GetCombo()]; }
        set { effectAsset[playerCollider.GetCombo()] = value; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
