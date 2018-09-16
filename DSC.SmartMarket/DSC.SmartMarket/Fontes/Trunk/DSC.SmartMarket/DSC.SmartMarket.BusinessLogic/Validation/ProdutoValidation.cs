using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSC.SmartMarket.BusinessLogic.Validation
{
    class ProdutoValidation : ValidationBase<Produto, ProdutoOperation>, IProdutoValidation
    {
        private IProdutoRepository ProdutoRepository
        {
            get
            {
                var resultado = Resolve<IProdutoRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        protected override Resultado ValidateFieldsRules()
        {
            var resultado = new Resultado(true);
            try
            {
                resultado += ValidarNomeUnico();
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        private Resultado ValidarNomeUnico()
        {
            var resultado = new Resultado(true);
            try
            {
                var filtro = new Produto() { Nome = Target.Nome };
                var resultadoSelecionar = ProdutoRepository.SelecionarPorNome(filtro);
                resultado += resultadoSelecionar;
                if (resultado)
                {
                    if (resultadoSelecionar.Retorno != null)
                    {
                        resultado.Sucesso = false;
                        resultado.Mensagens.Add(new Mensagem("Nome", "Por favor preencha o campo Nome com um valor único."));
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }
    }
}