using Faculdade.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Faculdade.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Matriculas") { }

        public DbSet<Aluno> Alunos { get; set; }
    }
}