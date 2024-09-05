[System.Serializable]
public class ProjectileConfig
{
    public float projectileSpeed = 20f;
    public float projectileDamage = 5f;
    public bool fireEffect = false;
    public bool iceEffect = false;
    public bool heals = false;
    public bool lightEffect = false;
    public float slow = 0.2f;
    public float iceDuration = 3f;
    public float fireDamage = 0.2f;
    public float fireDuration = 3f;
    public int firstProperty = 0;
    public float delay = 0.5f;

    // Construtor para criar uma cópia de uma configuração existente
    public ProjectileConfig(ProjectileConfig config)
    {
        this.projectileSpeed = config.projectileSpeed;
        this.projectileDamage = config.projectileDamage;
        this.fireEffect = config.fireEffect;
        this.iceEffect = config.iceEffect;
        this.slow = config.slow;
        this.iceDuration = config.iceDuration;
        this.fireDamage = config.fireDamage;
        this.fireDuration = config.fireDuration;
    }

    // Construtor vazio para criar uma configuração do zero
    public ProjectileConfig() { }
}