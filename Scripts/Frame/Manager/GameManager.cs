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
/// 管理游戏进程
/// </summary>
public class GameManager : UnitySingleton<GameManager>
{
    public bool init = false;
    private void Start()
    {
        StartCoroutine(InitManager());
    }
    /// <summary>
    /// 这里写入游戏的进入逻辑
    /// </summary>
    /// <returns></returns>
    IEnumerator InitManager()
    {
        //TODO:开始游戏逻辑：场景加载,UI加载,数据读取等等

        // ...

        //END
        yield return null;
        LogUtil.SampleLog($"{gameObject.name} Init Success!");
        init = true;
    }

    /// <summary>
    /// 游戏退出
    /// </summary>
    public void ExitGame()
    {
        // TODO:游戏退出逻辑（保存数据,断开网络连接..等等操作）

        // ...

        // 游戏退出
        Application.Quit();
    }
    private void OnDestroy()
    {
        LogUtil.Danger($"{gameObject.name} Destory !");
    }
}
