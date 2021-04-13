using AutoMapper;
using Common.DTOs.QuestionTranslationDTO;
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
    public class QuestionTranslationConfiguration : Profile, IEntityTypeConfiguration<QuestionTranslation>
    {
        public QuestionTranslationConfiguration()
        {
            CreateMap<QuestionTranslation, QuestionTranslationReadDto>();
        }

        public void Configure(EntityTypeBuilder<QuestionTranslation> builder)
        {
            builder.ToTable("tbl_question_translations");
            builder.Property(q => q.QuestionId).HasColumnName("question_id").IsRequired();
            builder.Property(q => q.LanguageId).HasColumnName("language_id").IsRequired();
            builder.Property(q => q.Text).HasColumnName("text").HasColumnType("text").IsRequired();

            builder.HasKey(q => new { q.QuestionId, q.LanguageId });
            builder.HasOne(q => q.Question).WithMany().HasForeignKey(f => f.QuestionId).IsRequired();
            builder.HasOne(q => q.Language).WithMany().HasForeignKey(f => f.LanguageId).IsRequired();

            builder.HasData(
               new QuestionTranslation { QuestionId = 1, LanguageId = 1, Text = "Teamleden geven hun fouten toe." },
               new QuestionTranslation { QuestionId = 2, LanguageId = 1, Text = "Teamleden zijn gepassioneerd en open in het bespreken van hun uitdagingen." },
               new QuestionTranslation { QuestionId = 3, LanguageId = 1, Text = "Teamleden zijn snel in het benoemen van de bijdragen en de successen van de anderen." },
               new QuestionTranslation { QuestionId = 4, LanguageId = 1, Text = "Team vergaderingen zijn boeiend en inspirerend." },
               new QuestionTranslation { QuestionId = 5, LanguageId = 1, Text = "Tijdens team vergaderingen worden de belangrijkste en moeilijkste onderwerpen aangekaart." },
               new QuestionTranslation { QuestionId = 6, LanguageId = 1, Text = "Teamleden geven hun eigen zwakheden aan elkaar toe." },
               new QuestionTranslation { QuestionId = 7, LanguageId = 1, Text = "Teamleden durven hun mening zeggen, ook als het mogelijks tot onenigheid leidt." },
               new QuestionTranslation { QuestionId = 8, LanguageId = 1, Text = "Teamleden durven elkaar aanspreken op elkaars mindere prestaties." },
               new QuestionTranslation { QuestionId = 9, LanguageId = 1, Text = "Het team heeft een reputatie van hoge prestaties." },
               new QuestionTranslation { QuestionId = 10, LanguageId = 1, Text = "Teamleden vragen elkaar makkelijk om hulp." },
               new QuestionTranslation { QuestionId = 11, LanguageId = 1, Text = "Teamleden verlaten de team vergaderingen met de overtuiging dat iedereen volledig achter de genomen beslissingen staat." },
               new QuestionTranslation { QuestionId = 12, LanguageId = 1, Text = "Tijdens discussies vragen teamleden door over hoe ze tot hun mening en besluiten komen." },
               new QuestionTranslation { QuestionId = 13, LanguageId = 1, Text = "Teamleden vragen snel en makkelijk naar input over hun verantwoordelijkheidsdomein." },
               new QuestionTranslation { QuestionId = 14, LanguageId = 1, Text = "Als het team zijn collectieve resultaten niet haalt gaat elk teamlid spontaan zijn verantwoordelijkheid opnemen om het algemene teamresultaat te verbeteren." },
               new QuestionTranslation { QuestionId = 15, LanguageId = 1, Text = "Teamleden doen gemakkelijk toegevingen in hun eigen verantwoordelijkheidsgebied ten gunste van de goede werking van het team." },
               new QuestionTranslation { QuestionId = 16, LanguageId = 1, Text = "Teamleden zijn snel met het elkaar confronteren van problemen in mekaars verantwoordelijkheidsdomeinen." },
               new QuestionTranslation { QuestionId = 17, LanguageId = 1, Text = "Teamleden (h)erkennen en maken gebruik van elkaars competenties en ervaring." },
               new QuestionTranslation { QuestionId = 18, LanguageId = 1, Text = "Teamleden vragen actief naar elkaars meningen tijdens vergaderingen." },
               new QuestionTranslation { QuestionId = 19, LanguageId = 1, Text = "Teamleden eindigen discussies en vergaderingen altijd met duidelijke, eenduidige en specifieke besluiten en actiepunten." },
               new QuestionTranslation { QuestionId = 20, LanguageId = 1, Text = "Teamleden bevragen elkaar rond hun huidige manieren van werken en gebruikte methoden(‘best practices’)." },
               new QuestionTranslation { QuestionId = 21, LanguageId = 1, Text = "Het team zorgt ervoor dat de minder presterende teamleden extra druk en een verhoogde verwachting tot presteren voelen." },
               new QuestionTranslation { QuestionId = 22, LanguageId = 1, Text = "Teamleden gaan zich spontaan verontschuldigen naar elkaar toe." },
               new QuestionTranslation { QuestionId = 23, LanguageId = 1, Text = "Teamleden communiceren makkelijk onpopulaire meningen in de groep." },
               new QuestionTranslation { QuestionId = 24, LanguageId = 1, Text = "In het team is het duidelijk welke de prioriteiten zijn en welke richting men uit wil." },
               new QuestionTranslation { QuestionId = 25, LanguageId = 1, Text = "Teamleden gaan eerder op zoek naar waardering en erkenning voor de teamprestaties dan voor hun persoonlijke prestaties." },
               new QuestionTranslation { QuestionId = 26, LanguageId = 1, Text = "Alle leden van het team hebben dezelfde hoge kwaliteitsnormen over hun werk." },
               new QuestionTranslation { QuestionId = 27, LanguageId = 1, Text = "Als er zich een conflict voordoet gaat het team dat eerst oplossen alvorens een ander onderwerp aan te pakken." },
               new QuestionTranslation { QuestionId = 28, LanguageId = 1, Text = "Het team heeft gezamenlijke doelstellingen en heeft de neus in dezelfde richting." },
               new QuestionTranslation { QuestionId = 29, LanguageId = 1, Text = "Het team bereikt consistent zijn doelstellingen." },
               new QuestionTranslation { QuestionId = 30, LanguageId = 1, Text = "Het team neemt makkelijk beslissingen, zelfs als niet alle informatie voor handen is." },
               new QuestionTranslation { QuestionId = 31, LanguageId = 1, Text = "Teamleden waarderen collectief succes hoger dan individuele prestaties." },
               new QuestionTranslation { QuestionId = 32, LanguageId = 1, Text = "Teamleden zijn onbevooroordeeld en oprecht met elkaar." },
               new QuestionTranslation { QuestionId = 33, LanguageId = 1, Text = "Teamleden kunnen makkelijk en spontaan privé zaken met elkaar bespreken." },
               new QuestionTranslation { QuestionId = 34, LanguageId = 1, Text = "Het team houdt zich aan genomen beslissingen." },
               new QuestionTranslation { QuestionId = 35, LanguageId = 1, Text = "Teamleden houden steeds aan hun beloften en afspraken naar elkaar." },
               new QuestionTranslation { QuestionId = 36, LanguageId = 1, Text = "Teamleden geven elkaar eerlijke, constructieve en niet manipulerende feedback aan elkaar." },
               new QuestionTranslation { QuestionId = 37, LanguageId = 1, Text = "Teamleden hechten weinig belang aan titels, status en aanzien." },
               new QuestionTranslation { QuestionId = 38, LanguageId = 1, Text = "Teamleden steunen groepsbeslissingen, zelfs als dat indruist tegen hun eigen persoonlijke mening." }
               );
        }
    }
}
