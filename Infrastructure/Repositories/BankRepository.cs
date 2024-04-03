using Core.Interfaces;
using Core.Models;
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class BankRepository : IBankRepository
{
    private readonly BootcampContext _context;

    public BankRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task Add(CreateBankModel model)
    {
        var bankToCreate = new Banco
        {
            Nombre = model.Name,
            Direccion = model.Address,
            Mail = model.Mail,
            Telefono = model.Phone
        };

        _context.Bancos.Add(bankToCreate);

        await _context.SaveChangesAsync();
    }

    public async Task<BankDTO> GetById(int id)
    {
        var bank = await _context.Bancos.FindAsync(id);

        if(bank is null) throw new Exception("Bank not found");

        var bankDTO = new BankDTO
        {
            Id = bank.Id,
            Name = bank.Nombre,
            Address = bank.Direccion,
            Mail = bank.Mail,
            Phone = bank.Telefono
        };

        return bankDTO;
    }
}
