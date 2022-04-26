using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Queries
{
    public static class AccountQueries
    {
        public const string GetAccountExtract = @"
            SELECT
              bl.vl_balance AS [Value],
              bl.cd_type_balance AS [Type],
              bl.dt_balance AS [TransactionDate],
              bl.tx_balance_resume AS [Resume]
            FROM
              tb_balance bl
            WHERE
              bl.vl_balance > 0
              AND bl.id_account = @accountId
              AND bl.dt_balance BETWEEN @initialDatetime AND @finishDatetime
            ORDER BY
              bl.id_balance DESC
        ";

        public const string GetAccountBalance = @"
            SELECT
              TOP 1 ba.vl_final_balance AS balance
            FROM
              tb_balance ba
            WHERE
              ba.id_account = @accountId
            ORDER BY
              ba.id_balance DESC
        ";

        public const string GetAccountFutureBalance = @"
            SELECT
              SUM(fb.vl_balance)
            FROM
              tb_future_balance fb
            WHERE
              fb.id_account = @accountId
              AND dt_future_balance <= @creditDatetime
        ";

        public const string GetUserAccountId = @"
            SELECT
              TOP 1 ac.id_account
            FROM
              tb_account ac
            WHERE
              ac.id_user = @userId
        ";

        public const string RegistryFutureCredit = @"
            INSERT INTO
              tb_future_balance (
                id_account,
                cd_type_balance,
                vl_balance,
                dt_registration,
                dt_future_balance,
                tx_balance_resume
              )
            VALUES
              (@accountId, 'C', @value, getdate(), @creditDatetime, @resume)
        ";

        public const string RegistryCredit = @"
            INSERT INTO
              tb_balance (
                id_account,
                cd_type_balance,
                vl_initial_balance,
                vl_balance,
                vl_final_balance,
                tx_balance_resume
              )
            SELECT TOP 1
              @accountId,
              'C',
              bl.vl_final_balance,
              @value,
              bl.vl_final_balance + @value,
              @resume
            FROM
              tb_balance bl
            WHERE
              bl.id_account = @accountId
            ORDER BY
              bl.id_balance DESC
        ";

        public const string RegistryDebit = @"
            INSERT INTO
              tb_balance (
                id_account,
                cd_type_balance,
                vl_initial_balance,
                vl_balance,
                vl_final_balance,
                tx_balance_resume
              )
            SELECT TOP 1
              @accountId,
              'D',
              bl.vl_final_balance,
              @value,
              bl.vl_final_balance - @value,
              @resume
            FROM
              tb_balance bl
            WHERE
              bl.id_account = @accountId
            ORDER BY
              bl.id_balance DESC
        ";

        public const string RegistryAccount = @"
            INSERT INTO
              tb_account (id_user)
            VALUES
              (@userId)
        ";

        public const string InsertInitialBalance = @"            
            INSERT INTO
              tb_balance(
                id_account,
                cd_type_balance,
                vl_initial_balance,
                vl_balance,
                vl_final_balance,
                tx_balance_resume
              )
            VALUES
              (@accountId, 'C', 0, 0, 0, 'Account opening')
        ";
    }
}
