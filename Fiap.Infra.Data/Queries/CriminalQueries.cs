using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Queries
{
    public static class CriminalQueries
    {
        public const string Insert = @"   
            INSERT INTO
              tbl_criminoso (tx_etnia, nr_faixa_idade, tx_sexo)
            VALUES
              (:Ethnicity, :Age, :Gender)
        ";

        public const string Update = @"
            UPDATE
              tbl_criminoso
            SET
              tx_etnia = :Ethnicity,
              nr_faixa_idade = :Age,
              tx_sexo = :Gender
            WHERE
              id_criminoso = :Id
        ";

        public const string Delete = @"
            DELETE FROM
              tbl_criminoso
            WHERE
              id_criminoso = :Id
        ";

        public const string GetById = @"
            SELECT
              id_criminoso Id,
              tx_etnia Ethnicity,
              nr_faixa_idade Age,
              tx_sexo Gender
            FROM
              tbl_criminoso
            WHERE
              id_criminoso = :Id
        ";

        public const string GetAll = @"
            SELECT
              id_criminoso Id,
              tx_etnia Ethnicity,
              nr_faixa_idade Age,
              tx_sexo Gender
            FROM
              tbl_criminoso           
        ";
    }
}
