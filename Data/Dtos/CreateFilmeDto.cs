﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateFilmeDto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ter no minimo 70 e maximo 600 minutos")]
    public int Duracao { get; set; }

}
