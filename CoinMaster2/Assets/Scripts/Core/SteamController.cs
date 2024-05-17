using Steamworks;
using UnityEngine;

public class SteamController : MonoBehaviour
{
    public static SteamController instance;
    public SteamManager manager;
    protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;
    private void OnEnable()
    {
        if (SteamManager.Initialized)
        {
            m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
        }
    }
    private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
    {
        if (pCallback.m_bActive != 0)
        {
            Debug.Log("Steam Overlay has been activated");
        }
        else
        {
            Debug.Log("Steam Overlay has been closed");
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            Debug.Log(name);
        }
    }
    private void Update()
    {
        if (!SteamManager.Initialized)
        {
            return;
        }
        SteamAPI.RunCallbacks();
    }
    



}
