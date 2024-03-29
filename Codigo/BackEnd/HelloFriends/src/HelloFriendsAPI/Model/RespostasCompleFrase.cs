﻿using System;

namespace HelloFriendsAPI.Model
{
    public class RespostasCompleFrase
    {
        public long Id { get; set; }
        public double Resultado { get; set; }
        public long AlunoId { get; set; }
        public Guid CompletaFraseID { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual CompletaFrase CompletaFrase { get; set; }
        public long MId { get; set; }

    }
}
