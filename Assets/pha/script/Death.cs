using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ability 스크립트 제거
        Ability ability = GetComponent<Ability>();
        if (ability != null)
            Destroy(ability);

        // UnitInit 스크립트 제거
        UnitInit unitInit = GetComponent<UnitInit>();
        if (unitInit != null)
            Destroy(unitInit);

        // UnitMove 스크립트 제거
        UnitMove unitMove = GetComponent<UnitMove>();
        if (unitMove != null)
            Destroy(unitMove);

        Unit_short_atk unit_short_atk = GetComponent<Unit_short_atk>();
        if (unit_short_atk != null)
            Destroy(unit_short_atk);

        Unit_long_atk unit_long_atk = GetComponent<Unit_long_atk>();
        if (unit_long_atk != null)
            Destroy(unit_long_atk);

        Ability_enemy ability_enemy = GetComponent<Ability_enemy>();
        if (ability_enemy != null)
            Destroy(ability_enemy);

        EnemyInit enemyInit = GetComponent<EnemyInit>();
        if (enemyInit != null)
            Destroy(enemyInit);

        EnemyMove enemyMove = GetComponent<EnemyMove>();
        if (enemyMove != null)
            Destroy(enemyMove);

        Enemy_short_atk enemy_short_atk = GetComponent<Enemy_short_atk>();
        if (enemy_short_atk != null)
            Destroy(enemy_short_atk);

        Enemy_long_atk enemy_long_atk = GetComponent<Enemy_long_atk>();
        if (enemy_long_atk != null)
            Destroy(enemy_long_atk);

        animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
