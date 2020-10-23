using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Business.Notifications
{
    public class Notificacao
    {
        public string Mensagem { get; set; }

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
