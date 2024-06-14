using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerStat _playerStat;

    // PlayerAnimationEventHandler

    private void Start()
    {
        _playerStat = PlayerStat.Instance;
    }

    public void OnFinishedAttackEventTrigger()
    {
        RaycastHit hit;
        if (
            Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hit,
                _playerStat.AttackDistance
            )
        )
        {
            // Kiểm tra nếu đối tượng bị trúng không phải là player
            if (hit.transform.gameObject != gameObject)
            {
                // Ray đã trúng một đối tượng khác player
                if (hit.transform.gameObject.TryGetComponent<EnemyStat>(out EnemyStat enemyStat))
                {
                    enemyStat.LoseHeath((int)_playerStat.Attack);
                    Debug.Log(hit.transform.gameObject);
                }

                // Thực hiện các hành động tiếp theo, ví dụ như tấn công đối tượng
            }
            else
            {
                // Ray đã trúng player, bỏ qua và tiếp tục ray
                if (
                    Physics.Raycast(
                        hit.point + Camera.main.transform.forward,
                        Camera.main.transform.forward,
                        out hit,
                        _playerStat.AttackDistance - hit.distance
                    )
                )
                {
                    if (
                        hit.transform.gameObject.TryGetComponent<EnemyStat>(out EnemyStat enemyStat)
                    )
                    {
                        enemyStat.LoseHeath((int)_playerStat.Attack);
                    }
                }
            }
        }
    }
}
