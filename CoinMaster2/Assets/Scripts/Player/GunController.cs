using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gun;

    // Update is called once per frame
    void Update()
    {
        // Converte a posição do mouse na tela para uma posição no mundo do jogo.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Faz a arma olhar para a posição do mouse.
        gun.LookAt(mousePosition);

        // Ajusta a rotação da arma para que ela gire em torno do jogador.
        gun.rotation = Quaternion.Euler(0, 0, gun.rotation.eulerAngles.z);
    }
}
