using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun gun;
    public Transform gunTransform;
    public Transform player;
    public float orbitSpeed = 20f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 gunDirection = (mousePosition - gunTransform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        gunTransform.eulerAngles = new Vector3(0, 0, angle);

    }

    public void Shoot()
    {
        
        // cria uma bala na posição da arma e força no sentido que ela esta apontada
        GameObject bullet = Instantiate(gun.Prefab, gunTransform.position, gunTransform.rotation);

        bullet.GetComponent<Rigidbody2D>().AddForce(gunTransform.right * gun.bullet.Speed, ForceMode2D.Impulse);

        // Destroi a bala após 2 segundos
        Destroy(bullet, 2f);
    }
}
