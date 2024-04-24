using Core.Entities;
using Core.Models;
using Core.Requests.TransactionHistoryModels;
using Mapster;

namespace Infrastructure.Mappings;

public class TransactionHistoryMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        ////Del Creation object hacia la entidad
        ////config.NewConfig<FilterTransactionHistoryModel, Account>()
            

        ////Entidad hacia el DTO
        //config.NewConfig<Account, TransactionHistoryDTO>()
        //    .Map(dest => dest.Account, src => src.Transfers.Adapt<AccountDTO>())
        //    .Map(dest => dest.Transfer, src => src.Transfers)
        //    .Map(dest => dest.Payment, src => src.PaymentServices)
        //    .Map(dest => dest.Deposit, src => src.Deposits)
        //    .Map(dest => dest.Extraction, src => src.Extractions);

        //config.NewConfig<Transfer, TransactionHistoryDTO>()
        //    //.Map(dest => dest.Account, src => src.a)
        //    .Map(dest => dest.Transfer, src => src.TransferredDateTime);
        ////.Map(dest => dest.Payment, src => src.PaymentServices)
        ////.Map(dest => dest.Deposit, src => src.Deposits)
        ////.Map(dest => dest.Extraction, src => src.Extractions);

        //config.NewConfig<PaymentService, TransactionHistoryDTO>()
        //    //.Map(dest => dest.Account, src => src.a)
        //    .Map(dest => dest.Payment, src => src.PaymentServiceDateTime);

        //config.NewConfig<Deposit, TransactionHistoryDTO>()
        //    //.Map(dest => dest.Account, src => src.a)
        //    .Map(dest => dest.Deposit, src => src.DepositDateTime);

        //config.NewConfig<Extraction, TransactionHistoryDTO>()
        //    //.Map(dest => dest.Account, src => src.a)
        //    .Map(dest => dest.Extraction, src => src.ExtractionDateTime);

        config.NewConfig<Account, TransactionHistoryDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TransactionType, _ => "Account")
            .Map(dest => dest.Amount, src => src.Balance)
            .Map(dest => dest.TransactionDateTime, _ => DateTime.Now) // Puedes ajustar esto según tus necesidades
            .Map(dest => dest.AccountNumber, src => src.Number);
        //.Map(dest => dest.BankName, src => src.CurrentAccount != null ? src.CurrentAccount.Bank.Name : null)
        //.Inherits<CommonMappings>(); // Si hay mapeos comunes

        config.NewConfig<Transfer, TransactionHistoryDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TransactionType, _ => "Transfer")
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransactionDateTime, src => src.TransferredDateTime)
            .Map(dest => dest.AccountNumber, src => src.OriginAccount.Number)
            .Map(dest => dest.BankName, src => src.Bank.Name)
            .Map(dest => dest.Description, src => src.Concept);
        //.Inherits<CommonMappings>(); // Si hay mapeos comunes

        config.NewConfig<PaymentService, TransactionHistoryDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TransactionType, _ => "Payment Service")
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransactionDateTime, src => src.PaymentServiceDateTime)
            .Map(dest => dest.AccountNumber, src => src.Account.Number)
            .Map(dest => dest.Description, src => src.Concept);
        //.Inherits<CommonMappings>(); // Si hay mapeos comunes

        config.NewConfig<Deposit, TransactionHistoryDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TransactionType, _ => "Deposit")
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransactionDateTime, src => src.DepositDateTime)
            .Map(dest => dest.AccountNumber, src => src.Account.Number)
            .Map(dest => dest.BankName, src => src.Bank.Name);
        //.Inherits<CommonMappings>(); // Si hay mapeos comunes

        config.NewConfig<Extraction, TransactionHistoryDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.TransactionType, _ => "Extraction")
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.TransactionDateTime, src => src.ExtractionDateTime)
            .Map(dest => dest.AccountNumber, src => src.Account.Number)
            .Map(dest => dest.BankName, src => src.Bank.Name);
            //.Inherits<CommonMappings>(); // Si hay mapeos comunes



    }
}
