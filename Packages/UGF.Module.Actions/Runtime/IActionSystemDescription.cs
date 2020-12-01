using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionSystemDescription : IDescription
    {
        string GroupId { get; }
    }
}
