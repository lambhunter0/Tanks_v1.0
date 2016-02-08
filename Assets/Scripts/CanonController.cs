using UnityEngine;
using System.Collections;

public class CanonController : MonoBehaviour {

    public Transform canonHolder;
    public Canon defaultCanon;
    Canon equippedCanon;

    void Start() {
        if (defaultCanon != null)
        {
            EquipCanon(defaultCanon);
        }
    }

    public void EquipCanon(Canon defaultCanon) {
        if (equippedCanon != null)
        {
            Destroy(equippedCanon.gameObject);
        }
        equippedCanon = Instantiate (defaultCanon, canonHolder.position, canonHolder.rotation) as Canon;
        equippedCanon.transform.parent = canonHolder;
    }

    public void Shoot()
    {
        if (equippedCanon != null)
        {
            equippedCanon.Shoot();
        }
    }

}
