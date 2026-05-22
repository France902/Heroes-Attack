using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Singleton per l'accesso globale
    public static ParticleManager Instance { get; private set; }

    [System.Serializable]
    public class ParticleItem
    {
        public ParticleType type;
        public GameObject prefab;
    }

    [SerializeField] private List<ParticleItem> particleList;

    private void Awake()
    {
        // Configurazione del Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            
        }

        SpawnParticle(ParticleType.Explosion, transform.position);
    }

    
    public void SpawnParticle(ParticleType type, Vector2 position)
    {
        GameObject prefabToSpawn = GetPrefabByType(type);

        if (prefabToSpawn != null)
        {
            // Istanzia le particelle nella posizione corretta
            GameObject newParticle = Instantiate(prefabToSpawn, position, Quaternion.identity);

            // Recupera il componente ParticleSystem
            ParticleSystem ps = newParticle.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                // Calcola la durata totale dell'effetto e distrugge il GameObject quando ha finito
                float totalDuration = ps.main.duration + ps.main.startLifetime.constantMax;
                Destroy(newParticle, totalDuration);
            }
            else
            {
                // Se per errore non è un particle system, lo distrugge dopo un tempo standard
                Destroy(newParticle, 2f);
            }
        }
        else
        {
            Debug.LogWarning($"Prefab per il tipo di particella {type} non trovato nel ParticleManager!");
        }
    }

    // Cerca nella lista l'elemento corrispondente all'enum richiesto
    private GameObject GetPrefabByType(ParticleType type)
    {
        foreach (var item in particleList)
        {
            if (item.type == type)
            {
                return item.prefab;
            }
        }
        return null;
    }
}