using UnityEngine;

public interface Damageable
{
    void TakeHit(float damage, RaycastHit hit);
}
