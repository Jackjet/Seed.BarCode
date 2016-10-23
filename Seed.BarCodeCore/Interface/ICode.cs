
namespace Seed.BarCodeCore.Interface
{
    public interface ICode:IId
    {
        string ProductName { get; set; }
        string Batch { get; set; }
        string BigCode { get; set; }
        string SmlCode { get; set; }
    }
}
