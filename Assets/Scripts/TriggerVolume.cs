using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    public enum Type
    {
        Death,
        Win,
        Weapon
    }
    public interface GameRule
    {
        void OnTriggerEnter2D(TriggerVolume triggerVolume, Type type, Collider2D collision);
    }

    static public GameRule gameRule;

    public Type type;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameRule != null)
            gameRule.OnTriggerEnter2D(this, type, collision);
    }
}
