using Core.Models;
using Core.Requests.CustomerModels;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;

public interface ICustomerService
{
    Task<CustomerDTO> Add(CreateCustomerModel model);
    Task<List<CustomerDTO>> GetFiltered(FilterCustomersModel filter);
    Task<CustomerDTO> GetById(int id);
    Task<List<CustomerDTO>> GetAll();
    Task<CustomerDTO> Update(UpdateCustomerModel model);
    Task<bool> Delete(int id);
}