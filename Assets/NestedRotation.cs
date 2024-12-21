using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NestedRotation : MonoBehaviour
{
    public List<Transform> nestedCubes = new();
    public List<Transform> outbounds = new();
    public List<Transform> customNestedCubes = new();
    public float speed = 10;

    private void OnValidate()
    {
        nestedCubes.Clear();
        outbounds.Clear();
        foreach (Transform item in transform)
        {
            if (item.name.Contains("Cube")) nestedCubes.Add(item);
        }

        foreach (Transform item in transform)
        {
            if (item.name.Contains("Out")) outbounds.Add(item);
        }
    }

    private void Start()
    {
        // use DOTween to linearly loop rotate each nestedCube around it's x axis and smaller index nestedCube rotate slower
        for (int i = 0; i < nestedCubes.Count; i++)
        {
            nestedCubes[i].DORotate(Vector3.right * 360f, (i + 1) * speed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }

        for (int i = 0; i < customNestedCubes.Count; i++)
        {
            if (i % 2 == 0)
                customNestedCubes[i].DORotate(Vector3.right * 360f, (i + 1) * speed, RotateMode.FastBeyond360)
                    .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
            else
                customNestedCubes[i].DORotate(-Vector3.right * 360f, (i + 1) * speed, RotateMode.FastBeyond360)
                    .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }

        // use DOTween to linearly loop rotate each outbounds around it's z axis
        foreach (Transform item in outbounds)
        {
            item.DORotate(-Vector3.right * 360f, speed * 2, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
    }
}