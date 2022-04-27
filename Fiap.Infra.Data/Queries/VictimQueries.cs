using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Queries
{
    public static class VictimQueries
    {
        public const string InsertVictim = @"   
            INSERT INTO
              tbl_vitima (tx_etnia, nr_faixa_idade, tx_sexo)
            VALUES
              (:Ethnicity, :Age, :Gender)
        ";

        public const string UpdateVictim = @"
            UPDATE
              tbl_vitima
            SET
              tx_etnia = :Ethnicity,
              nr_faixa_idade = :Age,
              tx_sexo = :Gender
            WHERE
              id_vitima = :Id
        ";

        public const string DeleteVictim = @"
            DELETE FROM
              tbl_vitima
            WHERE
              id_vitima = :Id
        ";

        public const string GetVictimById = @"
            SELECT
              id_vitima Id,
              tx_etnia Ethnicity,
              nr_faixa_idade Age,
              tx_sexo Gender
            FROM
              tbl_vitima
            WHERE
              id_vitima = :Id
        ";

        public const string GetAllVictims = @"
            SELECT
              id_vitima Id,
              tx_etnia Ethnicity,
              nr_faixa_idade Age,
              tx_sexo Gender
            FROM
              tbl_vitima           
        ";

    }
}
