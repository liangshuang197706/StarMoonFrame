using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SMF;

/*************************************
 ** auth: Liangshuang
 ** date: Create Date
 ** Version: 0.0.1
 *************************************/

/// <summary>
/// ������Ϸ����
/// </summary>
public class GameManager : UnitySingleton<GameManager>
{
    public bool init = false;
    private void Start()
    {
        StartCoroutine(InitManager());
    }
    /// <summary>
    /// ����д����Ϸ�Ľ����߼�
    /// </summary>
    /// <returns></returns>
    IEnumerator InitManager()
    {
        //TODO:��ʼ��Ϸ�߼�����������,UI����,���ݶ�ȡ�ȵ�

        // ...

        //END
        yield return null;
        LogUtil.SampleLog($"{gameObject.name} Init Success!");
        init = true;
    }

    /// <summary>
    /// ��Ϸ�˳�
    /// </summary>
    public void ExitGame()
    {
        // TODO:��Ϸ�˳��߼�����������,�Ͽ���������..�ȵȲ�����

        // ...

        // ��Ϸ�˳�
        Application.Quit();
    }
    private void OnDestroy()
    {
        LogUtil.Danger($"{gameObject.name} Destory !");
    }
}
