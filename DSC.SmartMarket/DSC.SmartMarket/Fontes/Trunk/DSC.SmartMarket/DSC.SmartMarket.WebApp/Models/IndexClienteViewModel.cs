﻿using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSC.SmartMarket.WebApp.Models
{
    public class IndexClienteViewModel
    {
        public TipoOperacao Operacao
        { get; set; }

        public IList<Cliente> ListaCliente
        { get; set; }

        public int Pagina
        { get; set; }

        public int TamanhoPagina
        { get; set; }

        public int TotalPagina
        { get; set; }

        public Cliente ClienteAlterar
        { get; set; }

        public bool IsValid
        { get; set; }

        public enum TipoOperacao
        {
            Incluir,
            Alterar,
            Remover,
            Listar
            
        }
    }
}