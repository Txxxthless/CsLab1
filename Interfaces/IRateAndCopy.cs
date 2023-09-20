
namespace cslab1.Interfaces
{
    public interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
