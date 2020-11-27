using NUnit.Framework;
using UGF.Application.Runtime;
using UGF.Module.Update.Runtime;
using UGF.Update.Runtime;
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
            Debug.Log(application.GetModule<IUpdateModule>().Provider.UpdateLoop.GetPlayerLoop().Print());

            application.Uninitialize();

            Debug.Log(application.GetModule<IUpdateModule>().Provider.UpdateLoop.GetPlayerLoop().Print());
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
