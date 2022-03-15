using System.Threading.Tasks;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    interface IColorRepository : IBaseRepository<Color>

    {
        Task<Color> GetByColorNameAsync(string colorDevice);
    }
}