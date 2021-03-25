using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gestao_Ouvidoria.Models
{
    public enum TipoStatus
    {
        [Display(Name = "Respondida(s)")]
        Respondida,
        [Display(Name = "Vencida(s)")]
        Vencida,
        [Display(Name = "Pendente(s)")]
        Pendente,
        [Display(Name = "Excluida(s)")]
        Excluida
    }
}