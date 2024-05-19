using UnityEngine;
using Steamworks;

public class SteamController : MonoBehaviour
{
    // Singleton para a classe SteamController
    public static SteamController Instance { get; private set; }

    // M�todo Awake � chamado quando o script � inicializado
    private void Awake()
    {
        // Se a inst�ncia for nula, esta inst�ncia se torna a inst�ncia Singleton
        if (Instance == null)
            Instance = this;
        // Se j� existir uma inst�ncia, destru�mos este objeto
        else
            Destroy(gameObject);
    }

    // M�todo para obter o ID do usu�rio Steam
    public string GetSteamID()
    {
        // Retorna o ID do usu�rio Steam como uma string
        return SteamUser.GetSteamID().ToString();
    }

    // M�todo para obter o nome do usu�rio Steam
    public string GetSteamName()
    {
        // Retorna o nome do usu�rio Steam
        return SteamFriends.GetPersonaName();
    }

    // M�todo para obter o idioma do jogo Steam
    public string GetSteamLanguage()
    {
        // Retorna o idioma atual do jogo
        return SteamApps.GetCurrentGameLanguage();
    }

    // M�todo para obter o caminho de instala��o do jogo Steam
    public string GetSteamInstallPath()
    {
        // Obt�m o caminho de instala��o do jogo e retorna
        SteamApps.GetAppInstallDir(SteamUtils.GetAppID(), out string steamInstallPath, 256);
        return steamInstallPath;
    }

    // M�todo para obter o c�digo do idioma do jogo Steam
    public string GetSteamLanguageCode()
    {
        // Retorna o c�digo do idioma atual do jogo
        // Voc� precisar� usar um m�todo diferente da API Steamworks para obter essa informa��o
        return SteamApps.GetCurrentGameLanguage();
    }
}
