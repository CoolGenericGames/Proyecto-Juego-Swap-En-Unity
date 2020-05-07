using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceObjects : ObjectsRepository
{
    #region Variables
    public int BulletQuantity;
    public int BulletEnemyQuantity;
    public int SpecialBulletEnemyQuantity;
    public int TriangleEnemyQuantity;
    public int SquareEnemyQuantity;
    public int CircleEnemyQuantity;
    #endregion

    #region GameObjects
    public GameObject Bullet;
    public GameObject BulletEnemy;
    public GameObject SpecialBulletEnemy;
    public GameObject TriangleEnemy;
    public GameObject SquareEnemy;
    public GameObject CircleEnemy;
    #endregion

    #region métodos de Unity
    // Start is called before the first frame update
    void Start()
    {
        CreateInstance(Bullet.GetComponent<DirectoryKey>().TheKey, Bullet, BulletQuantity);
        CreateInstance(BulletEnemy.GetComponent<DirectoryKey>().TheKey, BulletEnemy, BulletEnemyQuantity);
        CreateInstance(SpecialBulletEnemy.GetComponent<DirectoryKey>().TheKey, SpecialBulletEnemy, SpecialBulletEnemyQuantity);
        CreateInstance(TriangleEnemy.GetComponent<DirectoryKey>().TheKey, TriangleEnemy, TriangleEnemyQuantity);
        CreateInstance(SquareEnemy.GetComponent<DirectoryKey>().TheKey, SquareEnemy, SquareEnemyQuantity);
        CreateInstance(CircleEnemy.GetComponent<DirectoryKey>().TheKey, CircleEnemy, CircleEnemyQuantity);
    }
    #endregion
}
