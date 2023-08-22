using Industry;
using UnityEngine;
using Zenject;

namespace Project.Installer
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private MovementSettings _movementsettings;
        [SerializeField] private GameObject Factory—himney;
        public override void InstallBindings()
        {
            Container.Bind<MovementSettings>().FromInstance(_movementsettings).AsSingle();
            Container.Bind<GameObject>().FromInstance(Factory—himney).AsSingle();
        }
    }
}
