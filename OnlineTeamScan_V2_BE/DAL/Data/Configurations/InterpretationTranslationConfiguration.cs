using AutoMapper;
using Common.DTOs.InterpretationTranslationDTO;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    public class InterpretationTranslationConfiguration : Profile, IEntityTypeConfiguration<InterpretationTranslation>
    {
        public InterpretationTranslationConfiguration()
        {
            CreateMap<InterpretationTranslation, InterpretationTranslationReadDto>();
        }

        public void Configure(EntityTypeBuilder<InterpretationTranslation> builder)
        {
            builder.ToTable("tbl_interpretation_translations");
            builder.Property(i => i.InterpretationId).HasColumnName("interpretation_id").IsRequired();
            builder.Property(i => i.LanguageId).HasColumnName("language_id").IsRequired();
            builder.Property(i => i.Text).HasColumnName("text").HasColumnType("text").IsRequired();

            builder.HasKey(i => new { i.InterpretationId, i.LanguageId });
            builder.HasOne(i => i.Interpretation).WithMany().HasForeignKey(f => f.InterpretationId).IsRequired();
            builder.HasOne(i => i.Language).WithMany().HasForeignKey(f => f.LanguageId).IsRequired();

            builder.HasData(
                new InterpretationTranslation { InterpretationId = 1, LanguageId = 1, Text = "Je team heeft een duidelijk gebrek aan de noodzakelijke openheid en kwetsbaarheid rond elkaars zwakheden, twijfels, fouten, uitdagingen en nood aan hulp die leden van elkaar verwachten om goed te kunnen samenwerken." },
                new InterpretationTranslation { InterpretationId = 2, LanguageId = 1, Text = "Je team zou moeten leren om zich kwetsbaarder en opener op te stellen naar elkaar toe i.v.m. elkaars zwakheden, twijfels, fouten, uitdagingen en nood aan hulp." },
                new InterpretationTranslation { InterpretationId = 3, LanguageId = 1, Text = "Je team heeft een omgeving gecreëerd waar kwetsbaarheid en openheid de norm zijn." },

                new InterpretationTranslation { InterpretationId = 4, LanguageId = 1, Text = "Je team voelt zich niet comfortabel om conflicten te bespreken en houdt meningsverschillen voor zichzelf of misbruikt ze tegen elkaar." },
                new InterpretationTranslation { InterpretationId = 5, LanguageId = 1, Text = "Je team zou moeten leren om conflicten sneller te bespreken en rond belangrijke meningsverschillen openlijk in discussie te gaan." },
                new InterpretationTranslation { InterpretationId = 6, LanguageId = 1, Text = "Je team durft makkelijk conflicten bespreken en verschillende meningen uiten." },

                new InterpretationTranslation { InterpretationId = 7, LanguageId = 1, Text = "Je team is niet in staat om zich volledig achter genomen beslissingen te scharen, waardoor dubbelzinnigheid en veronderstellingen eerder regel zijn dan uitzondering." },
                new InterpretationTranslation { InterpretationId = 8, LanguageId = 1, Text = "Je team heeft het soms moeilijk om zich volledig achter genomen beslissingen te scharen, waardoor dubbelzinnigheid en veronderstellingen mogelijks de kop op steken." },
                new InterpretationTranslation { InterpretationId = 9, LanguageId = 1, Text = "Je team is in staat om zich volledig achter genomen beslissingen te scharen, zodat dubbelzinnigheid en veronderstellingen geen kans krijgen." },

                new InterpretationTranslation { InterpretationId = 10, LanguageId = 1, Text = "Je team aarzelt of vermijdt om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                new InterpretationTranslation { InterpretationId = 11, LanguageId = 1, Text = "Je team aarzelt soms om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },
                new InterpretationTranslation { InterpretationId = 12, LanguageId = 1, Text = "Je team aarzelt niet om elkaar aan te spreken op gemaakte afspraken, gedrag en prestatie." },

                new InterpretationTranslation { InterpretationId = 13, LanguageId = 1, Text = "Je team hecht duidelijk te weinig waarde aan het collectieve resultaat en is vooral bezig met individueel gewin, erkenning en status." },
                new InterpretationTranslation { InterpretationId = 14, LanguageId = 1, Text = "Je team hecht mogelijks teveel waarde aan individueel/departementeel gewin, erkenning en status in het nadeel van het collectieve resultaat." },
                new InterpretationTranslation { InterpretationId = 15, LanguageId = 1, Text = "Je team schat het bereiken van het collectief resultaat hoger in dan het bereiken van individueel gewin, erkenning en status." }
                );
        }
    }
}
