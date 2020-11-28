using System.Collections;
using NUnit.Framework;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Module.Update.Runtime;
using UGF.Update.Runtime;
using UnityEngine;
using UnityEngine.TestTools;

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

        [UnityTest]
        public IEnumerator InitializeAndUninitializeWithUpdate()
        {
            IApplication application = CreateApplication();

            application.Initialize();

            var module = application.GetModule<IActionModule>();

            Assert.NotNull(module);

            yield return null;
            yield return null;

            Debug.Log(application.GetModule<IUpdateModule>().Provider.UpdateLoop.GetPlayerLoop().Print());

            application.Uninitialize();

            Debug.Log(application.GetModule<IUpdateModule>().Provider.UpdateLoop.GetPlayerLoop().Print());
        }

        [UnityTest]
        public IEnumerator Update()
        {
            IApplication application = CreateApplication();

            application.Initialize();

            var module = application.GetModule<IActionModule>();
            var target1 = new TestActionTarget();
            var target2 = new TestActionCommandTarget();

            module.Context.Add(target1);
            module.Context.Add(target2);

            Assert.AreEqual(0, target1.Counter, "target1");
            Assert.AreEqual(0, target2.Counter, "target2");

            yield return null;

            Assert.AreEqual(1, target1.Counter, "target1");
            Assert.AreEqual(0, target2.Counter, "target2");

            yield return null;

            Assert.AreEqual(2, target1.Counter, "target1");
            Assert.AreEqual(0, target2.Counter, "target2");

            module.Provider.Add(new TestActionCommand(1));

            yield return null;

            Assert.AreEqual(3, target1.Counter, "target1");
            Assert.AreEqual(1, target2.Counter, "target2");

            module.Provider.Add(new TestActionCommand(10));

            yield return null;

            Assert.AreEqual(4, target1.Counter, "target1");
            Assert.AreEqual(11, target2.Counter, "target2");

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
