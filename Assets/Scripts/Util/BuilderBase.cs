using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Written By Jinseok Bae
/// <summary>
/// 클래스 빌더 패턴 추상 베이스 코드
/// </summary>

public abstract class BuilderBase<T> where T : class
{
    public abstract T Build();
}
