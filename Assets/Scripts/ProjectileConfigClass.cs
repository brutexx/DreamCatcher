[System.Serializable]
public class ProjectileConfig
{
    public float projectileSpeed = 20f;
    public float projectileDamage = 5f;
    public bool fireEffect = false;
    public bool iceEffect = false;
    public bool heals = false;
    public bool shields = false;
    public float healAmount = 5f;
    public float shieldAmount = 5f;
    public bool lightEffect = false;
    public float slow = 0.2f;
    public float iceDuration = 3f;
    public float fireDamage = 0.2f;
    public float fireDuration = 3f;
    public int firstProperty = 0;
    public float delay = 0.5f;
    public bool aoe = false;
    public bool self = false;

    // Construtor para criar uma c�pia de uma configura��o existente
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
        this.aoe = config.aoe;
        this.self = config.self;
        this.healAmount = config.healAmount;
        this.shields = config.shields;
        this.shieldAmount = config.shieldAmount;
    }

    // Construtor vazio para criar uma configura��o do zero
    public ProjectileConfig() { }
}