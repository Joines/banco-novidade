
using System.Collections;
using System.Collections.Generic;

namespace ProcessaDepositos.Domain.Transacoes
{
    public class RelacaoDeposito
    {
        public ICollection<Deposito> Depositos { get; set; }
    }
}
