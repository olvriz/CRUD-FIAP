using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Queries
{
    public static class UserQueries
    {
        public const string GetUserByEmail = @"
            SELECT
              us.id_user AS [UserId],
              us.tx_name AS [Name],
              us.dt_registration AS [RegistrationDate],
              us.tx_hash_password AS [PasswordHash],
              us.tx_email AS [Email]
            FROM
              tb_user us
            WHERE
              us.tx_email = @email
        ";

        public const string UserExistsByEmail = @"
            SELECT
              TOP 1 1
            FROM
              tb_user
            WHERE
              tx_email = @email
        ";

        public const string RegistryUser = @"
            INSERT INTO
              tb_user (tx_name, tx_hash_password, tx_email)
            VALUES
              (@name, @passwordHash, @email)
        ";

        public const string GetUserId = @"
            SELECT
              id_user
            FROM
              tb_user
            WHERE
              tx_email = @email
        ";
    }
}
