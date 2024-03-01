using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerControll _playerPrefab;
    [SerializeField] private Transform _playerSpawnPosition;

    public override void InstallBindings()
    {
        var player = Container.InstantiatePrefabForComponent<PlayerControll>(_playerPrefab);

        Container
            .Bind<PlayerControll>()
            .FromInstance(player)
            .AsSingle();
    }
}
