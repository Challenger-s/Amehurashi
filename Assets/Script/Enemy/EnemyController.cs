using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    enum State
    {
        Patrol, // 巡回
        chase   // 追跡
    }
    State state = State.Patrol;

    [SerializeField]
    GameObject target;

    [SerializeField]
    GameObject[] root;  // 巡回ルートの配列
    int rootNum = 0;    // 現在の目的地の配列番号

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Patrol:
                {
                    // 自分と目的地の距離を調べる
                    float distanceToRoot = Vector3.Distance(transform.position, this.root[this.rootNum].transform.position);

                    if (distanceToRoot < 1f)
                    {
                        this.rootNum++;
                        if (this.rootNum >= this.root.Length)
                        {
                            this.rootNum = 0;
                        }
                    }

                    // 経路が作れない状態じゃないなら
                    if (this.navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
                    {
                        // 目的地を設定
                        this.navMeshAgent.SetDestination(this.root[rootNum].transform.position);
                    }
                    // 自分と敵との距離を調べる
                    float distanceToPlayer = Vector3.Distance(transform.position, this.target.transform.position);
                    if (distanceToPlayer < 3f)   // 3mに近づいたら追跡モードへ
                    {
                        this.state = State.chase;
                    }
                }
                break;

            case State.chase:
                {
                    // 自分と敵との距離を調べる
                    float distanceToPlayer = Vector3.Distance(transform.position, this.target.transform.position);
                    if (distanceToPlayer > 4f)   // 4m以上離れたら追跡モードへ
                    {
                        this.state = State.Patrol;
                    }

                    // 経路が作れない状態じゃないなら
                    if (this.navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
                    {
                        // 目的地を設定
                        this.navMeshAgent.SetDestination(this.target.transform.position);
                    }
                }
                break;
        }

    }
}
