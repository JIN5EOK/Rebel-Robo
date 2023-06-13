using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
// By Jinseok Bae
/// <summary>
/// 오브젝트 파괴시 어드레서블 릴리즈 실행
/// </summary>
public class AddressableAutoRelease : MonoBehaviour
{
    private void OnDestroy()
    {
        Addressables.ReleaseInstance(this.gameObject);
    }
}
