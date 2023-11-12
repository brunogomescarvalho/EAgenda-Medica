﻿using Taikandi;

namespace EAgendaMedica.Dominio.Compartilhado
{
    public abstract class Atividade
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }

        public Atividade()
        {
            Id = SequentialGuid.NewGuid();
        }

    }
}



