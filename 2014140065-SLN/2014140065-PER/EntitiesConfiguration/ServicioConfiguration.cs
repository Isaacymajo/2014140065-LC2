﻿using _2014140065_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.EntititesConfiguration
{
    public class ServicioConfiguration : EntityTypeConfiguration<Servicio>
    {
        public ServicioConfiguration()
        {
            //Table configurations
            ToTable("Servicios");
            HasKey(c => c.ServicioId);
            Property(c => c.NombreServicio).IsRequired().HasMaxLength(50);

            //Relationships configurations
            Map<Encomienda>(m => m.Requires("Discriminator").HasValue("Encomienda"));
            Map<Transporte>(m => m.Requires("Discriminator").HasValue("Transporte"));

            HasRequired(c => c.Venta)
                .WithMany(c => c.Servicio)
                .HasForeignKey(c => c.VentaId);

        }
    }
}
