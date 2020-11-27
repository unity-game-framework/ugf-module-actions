using NUnit.Framework;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Tests
{
    public class TestActionModule
    {
        [Test]
        public void InitializeAndUninitialize()
        {
            IApplication application = CreateApplication();

            application.Initialize();

            var module = application.GetModule<IActionModule>();

            Assert.NotNull(module);

            application.Uninitialize();
        }

        private IApplication CreateApplication()
        {
            return new ApplicationConfigured(new ApplicationResources
            {
                new ApplicationConfig
                {
                    Modules =
                    {
                        (IApplicationModuleAsset)Resources.Load("UpdateModule", typeof(IApplicationModuleAsset)),
                        (IApplicationModuleAsset)Resources.Load("ActionModule", typeof(IApplicationModuleAsset))
                    }
                }
            });
        }
    }
}
