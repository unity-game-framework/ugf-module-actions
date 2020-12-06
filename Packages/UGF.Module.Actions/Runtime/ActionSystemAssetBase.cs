using UGF.Actions.Runtime;
using UGF.Builder.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionSystemAssetBase : DescribedWithDescriptionBuilderAsset<IActionSystemDescribed, IActionSystemDescription>, IActionSystemBuilder
    {
        T IBuilder<IActionSystem>.Build<T>()
        {
            return (T)OnBuild();
        }

        IActionSystem IBuilder<IActionSystem>.Build()
        {
            return OnBuild();
        }
    }
}
