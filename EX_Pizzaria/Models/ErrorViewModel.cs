using System;

namespace EX_Pizzaria.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel() { }
        public ErrorViewModel(string erro)
        {
            this.Erro = erro;
        }

        public string Erro { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
