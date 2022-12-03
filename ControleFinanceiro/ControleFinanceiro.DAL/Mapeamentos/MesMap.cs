using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(m => m.Mesid);
            builder.Property(m => m.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(m => m.Nome).IsUnique();

            builder.HasMany(m => m.Despesas).WithOne(m => m.Mes);
            builder.HasMany(m => m.Ganhos).WithOne(m => m.Mes);

            builder.HasData(
                new Mes
                {
                    Mesid = 1,
                    Nome = "Janeiro"
                },
                 new Mes
                 {
                     Mesid = 2,
                     Nome = "Fevereiro"
                 },
                  new Mes
                  {
                      Mesid = 3,
                      Nome = "Março"
                  },
                   new Mes
                   {
                       Mesid = 4,
                       Nome = "Abril"
                   },
                    new Mes
                    {
                        Mesid = 5,
                        Nome = "Maio"
                    },
                     new Mes
                     {
                         Mesid = 6,
                         Nome = "Junho"
                     },
                      new Mes
                      {
                          Mesid = 7,
                          Nome = "Julho"
                      },
                       new Mes
                       {
                           Mesid = 8,
                           Nome = "Agosto"
                       },
                        new Mes
                        {
                            Mesid = 9,
                            Nome = "Setembro"
                        },
                         new Mes
                         {
                             Mesid = 10,
                             Nome = "Outubro"
                         },
                          new Mes
                          {
                              Mesid = 11,
                              Nome = "Novembro"
                          },
                           new Mes
                           {
                               Mesid = 12,
                               Nome = "Dezembro"
                           });

            builder.ToTable("Meses");
        }
    }
}
