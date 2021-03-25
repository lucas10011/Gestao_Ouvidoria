﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gestao_Ouvidoria.Models
{
    [Table("Manifestacoes")]
    public class Manifestacao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o Campus.")]
        public string Campus { get; set; }

        [Required(ErrorMessage = "Preencha o Curso.")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Preencha o tipo de solicitação.")]
        [Display(Name = "Tipo de Solicitação")]
        public TipoSolicitacao TipoSolicitacao { get; set; }

        [Required(ErrorMessage = "Preencha o Setor.")]
        public Setor Setor { get; set; }

        [Required(ErrorMessage = "Preencha o Assunto.")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "Preencha a Manifestação.")]
        [Display(Name = "Manifestacao")]
        public string ManifestacaoConteudo { get; set; }

        [Required]
        [ForeignKey("Perfil")]
        public int IdPerfil { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}