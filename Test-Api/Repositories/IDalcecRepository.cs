using System.Threading.Tasks;
using Test_Api.Models.Dalcec;
using Test_Api.Models.ResponseModels;

namespace Test_Api.Repositories
{
				public interface IDalcecRepository
				{
								Task<GenericResponse<List<Factura>>> GetFacturasByFacData();
				}
}
