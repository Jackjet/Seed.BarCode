
namespace Seed.BarCodeCore.Interface
{
    public interface ICode
    {
        string Id { get; set; }
        string ProductName { get; set; }
        string Batch { get; set; }
        string BigCode { get; set; }
        string SmlCode { get; set; }
    }
}
