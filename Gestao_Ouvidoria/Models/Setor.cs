using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Gestao_Ouvidoria.Models
{
    public enum Setor
    {

        Biblioteca,
        [Display(Name = "Centro de Atendimento")]
        Centro_de_Atendimento,
        Financeiro,
        Secretaria,
        [Display(Name = "Coordenação")]
        Coordenacao,
        Almoxarifado
    }
}