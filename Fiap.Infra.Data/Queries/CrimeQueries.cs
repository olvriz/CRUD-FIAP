using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Queries
{
    public class CrimeQueries
    {
        public const string Insert = @"   
            INSERT INTO
              tbl_crime (
                dt_ocorrencia,
                tx_endereco,
                id_criminoso,
                id_tipo_crime,
                id_vitima
              )
            VALUES
              (:OcorrenceDate, :Address, :CriminalId, :CrimeType, :VictimId)
        ";

        public const string Update = @"
            UPDATE
              tbl_crime
            SET
              dt_ocorrencia = :OcorrenceDate,
              tx_endereco = :Address,
              id_criminoso = :CriminalId,
              id_tipo_crime = :CrimeType,
              id_vitima = :VictimId
            WHERE
              id_crime = :Id
        ";

        public const string Delete = @"
            DELETE FROM
              tbl_crime
            WHERE
              id_crime = :Id
        ";

        public const string GetById = @"
            SELECT
              id_crime Id,
              dt_ocorrencia OcorrenceDate,
              tx_endereco Address,
              id_criminoso CriminalId,
              id_tipo_crime CrimeType,
              id_vitima VictimId
            FROM
              tbl_crime
            WHERE
              id_crime = :Id
        ";

        public const string GetAll = @"
            SELECT
              id_crime Id,
              dt_ocorrencia OcorrenceDate,
              tx_endereco Address,
              id_criminoso CriminalId,
              id_tipo_crime CrimeType,
              id_vitima VictimId
            FROM
              tbl_crime          
        ";
    }
}
