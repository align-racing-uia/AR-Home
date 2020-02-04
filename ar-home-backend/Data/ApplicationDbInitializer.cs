using System;
using System.Collections.Generic;
using System.Linq;
using web_api.Models.Home;
using web_api.Models.Info;
using web_api.Models.Project;

namespace web_api.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context, bool development)
        {
            if (!development) return;
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
                
            context.Shortcuts.AddRange(new List<Shortcut>
            {
                new Shortcut(){ Name="APPLY", Text="Skjema for kjøregodtgjørelse.", Url="https://km.alignracing.no/" },
                new Shortcut(){ Name="DEL", Text="Deleskjema for bestilling av deler.", Url="https://deler.alignracing.no/" },
                new Shortcut(){ Name="ERFARING", Text="Suggestions for improving routines, how to increase efficiency.", Url="https://erfaring.alignracing.no/" },
                new Shortcut(){ Name="HR", Text="Rapportering til HR. Lav terskel! Anonym rapportering.", Url="https://hr.alignracing.no/" },
                new Shortcut(){ Name="KM", Text="Skjema for kjøregodtgjørelse", Url="https://km.alignracing.no/" },
                new Shortcut(){ Name="QUIZ", Text="Påmelding til et av quiz lagene.", Url="https://quiz.alignracing.no/" },
                new Shortcut(){ Name="REFUSJON", Text="Skjema for refusjon av utlegg.", Url="https://refusjon.alignracing.no/" },
                new Shortcut(){ Name="RUH", Text="Skjema for rapport av uænskede hendelser. Ovbligatorisk 2/mnd", Url="https://ruh.alignracing.no/" },
                new Shortcut(){ Name="SJA", Text="Skjema for sikker jobbanalyse.", Url="https://sja.alignracing.no/" },
                new Shortcut(){ Name="SPONS", Text="Informasjonslenke for sponsorer.", Url="https://spons.alignracing.no/" },
                new Shortcut(){ Name="TIPS", Text="Tips til markedsføring.", Url="https://tips.alignracing.no/" },
                new Shortcut(){ Name="AVDUK", Text="Skjema for de som skal ha spesiell invitasjon til avdukning", Url="https://avduk.alignracing.no/" },
                new Shortcut(){ Name="APL", Text="Registrering av arbeid på skole labben.", Url="https://apl.alignracing.no/" },
                new Shortcut(){ Name="INFO", Text="Infoskjermen fra kontoret med kommende events", Url="http://alignracing.no/info/arInfo/index.php" },
            });
            
            context.Deadlines.AddRange(new List<Deadline>
            {
                new Deadline(){Title = "Concept-lock", Time = new DateTime(2019,09,15, 23, 59, 59)},
                new Deadline(){Title = "Design-lock", Time = new DateTime(2019,10,24, 23, 59, 59)},
                
            });
            context.Events.AddRange(new List<Event>
            {
                new Event(){Title = "Fellesmøte", Location = "Align HQ", Time = new DateTime(2019,10,14, 16,15,00)},
                new Event(){Title = "Fellesmøte", Location = "Align HQ", Time = new DateTime(2019,10,21, 16, 15, 00)},
                new Event(){Title = "Designpresentasjon", Location = "C2 042", Time = new DateTime(2019,10,24, 16, 15, 00)},
                
            });
            
            context.ProjectTasks.AddRange(new List<ProjectTask>
            {
                new ProjectTask(){
                    Title = "Align Racing 19/20 - Fall", 
                    Start = new DateTime(2019,08,20, 16,00,00), 
                    Finish = new DateTime(2019,12,20, 16,30,00),
                    Complele = 8
                },
                new ProjectTask(){
                    Title = "Concept phase", 
                    Start = new DateTime(2019,08,20, 16,00,00), 
                    Finish = new DateTime(2019,09,22, 16,30,00),
                    Complele = 100
                },
                new ProjectTask(){
                    Title = "Design phase", 
                    Start = new DateTime(2019,09,23, 16,00,00), 
                    Finish = new DateTime(2020,01,12, 16,30,00),
                    Complele = 8
                }

            });

            context.SaveChanges();
            
            var cat = new Category() {Name = "IT"};
            context.Categorys.Add(cat);
            var shocat = new ShortcutCategory() {Category = cat, Shortcut = context.Shortcuts.ToList()[0]};
            context.ShortcutCategorys.Add(shocat);

            context.SaveChanges();


        }
    }
}