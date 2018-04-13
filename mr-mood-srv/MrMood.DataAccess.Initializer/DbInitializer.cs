using Microsoft.EntityFrameworkCore.Storage;
using MrMood.DataAccess.Context;
using MrMood.Domain;
using System;

namespace MrMood.DataAccess.Initializer
{
    public class DbInitializer
    {
        public static void Initialize(MoodContext context)
        {
            if (!context.Database.EnsureCreated())
            {
                return;
            }

            var smooth = new Tag() { Title = "smooth" };
            var funny = new Tag() { Title = "funny" };
            var lucky = new Tag() { Title = "lucky" };
            var motion = new Tag() { Title = "motion" };
            var effective = new Tag() { Title = "effective" };
            var work = new Tag() { Title = "work" };
            context.Tags.AddRange(smooth, funny, motion, lucky, effective);
            context.SaveChanges();

            var nizza = new Artist() { Title = "5nizza", Description = "Ukrainian reggi and folk band" };
            var boombox = new Artist() { Title = "Boombox", Description = "Ukrainian rock and hip-hop band" };
            var brutto = new Artist() { Title = "Brutto", Description = "Belarussian band that records tracks on Russian, Ukrainian and Belarussian languages" };
            var mgzavrebi = new Artist() { Title = "Mgzavrebi", Description = "Georgian band. Solist is an actor" };
            var hrystyna = new Artist() { Title = "Христина Соловiй", Description = "Ukranian singer" };
            context.Artists.AddRange(nizza, boombox, brutto, hrystyna, mgzavrebi);
            context.SaveChanges();

            var iasamani = new Song() { Artist = mgzavrebi, FileName = "01.Iasamani", Title = "Iasamani", MeanEnergy = 35, MeanTempo = 20 };
            var fanduri = new Song() { Artist = mgzavrebi, FileName = "02. Fanduri", Title = "Fanduri", MeanEnergy = -63, MeanTempo = 87 };
            var zurchanta = new Song() { Artist = mgzavrebi, FileName = "03. Zurgchanta", Title = "Zurgchanta", MeanEnergy = 13, MeanTempo = 82 };
            var gzaze = new Song() { Artist = mgzavrebi, FileName = "04. Gzaze", Title = "Gzaze", MeanEnergy = -71, MeanTempo = 48 };
            var domino = new Song() { Artist = mgzavrebi, FileName = "05. Domino", Title = "Domino", MeanEnergy = -21, MeanTempo = 91 };
            var relado = new Song() { Artist = mgzavrebi, FileName = "06. Relado", Title = "Relado", MeanEnergy = 49, MeanTempo = -96 };
            var piramidebi = new Song() { Artist = mgzavrebi, FileName = "08. Piramidebi", Title = "Piramidebi", MeanEnergy = 74, MeanTempo = -95 };
            var iavnana = new Song() { Artist = mgzavrebi, FileName = "09. Iavnana", Title = "Iavnana", MeanEnergy = 42, MeanTempo = -80 };
            var vazi = new Song() { Artist = mgzavrebi, FileName = "10. Vazi", Title = "Vazi", MeanEnergy = -42, MeanTempo = 12 };
            var onlyYou = new Song() { Artist = mgzavrebi, FileName = "07. Только ты", Title = "Только ты", MeanEnergy = -53, MeanTempo = -31 };
            var gala = new Song() { Artist = mgzavrebi, FileName = "11. Gala", Title = "Gala", MeanEnergy = -45, MeanTempo = 50 };
            var gamodi = new Song() { Artist = mgzavrebi, FileName = "12. Gamodi", Title = "Gamodi", MeanEnergy = 4, MeanTempo = 2 };
            var samnamgulebs = new Song() { Artist = mgzavrebi, FileName = "13. Sanamgulebs", Title = "Sanamgulebs", MeanEnergy = 18, MeanTempo = 19 };
            var bet = new Song() { Artist = mgzavrebi, FileName = "14. Пообещай", Title = "Пообещай", MeanEnergy = 76, MeanTempo = 76 };
            var budSmelim = new Song() { Artist = brutto, FileName = "01_brutto_budz_smelim_myzuka", Title = "Будзь смелым", MeanEnergy = 12, MeanTempo = -48 };
            var chaika = new Song() { Artist = brutto, FileName = "01_brutto_chaika_myzuka", Title = "Чайка", MeanEnergy = 56, MeanTempo = -20 };
            var human = new Song() { Artist = brutto, FileName = "01_brutto_chelovek_myzuka", Title = "Человек", MeanEnergy = -73, MeanTempo = -23 };
            var seredniViky = new Song() { Artist = brutto, FileName = "01_brutto_seredni_viki_myzuka", Title = "Середнi вiки", MeanEnergy = 23, MeanTempo = -21 };
            var nudeKing = new Song() { Artist = boombox, FileName = "01_bumboks_golii_korol_myzuka", Title = "Голий король", MeanEnergy = 40, MeanTempo = 60 };
            var bolelshik = new Song() { Artist = boombox, FileName = "03_bumboks_bolelshik_myzuka", Title = "Болельщик", MeanEnergy = -35, MeanTempo = -20 };
            var neKino = new Song() { Artist = nizza, FileName = "5'nizza – Не кино", Title = "Не Кино", MeanEnergy = 30, MeanTempo = -50 };
            var blueSea = new Song() { Artist = hrystyna, FileName = "04_hristina_solovii_sinya_pisnya_myzuka", Title = "Синя пiсня", MeanEnergy = -40, MeanTempo = 15 };
            var goreDolom = new Song() { Artist = hrystyna, FileName = "05_hristina_solovii_gore_dolom_myzuka", Title = "Горе долом", MeanEnergy = -20, MeanTempo = 10 };
            var take = new Song() { Artist = hrystyna, FileName = "03_hristina_solovii_trimai_myzuka", Title = "Тримай", MeanEnergy = -30, MeanTempo = 20 };
            var people = new Song() { Artist = boombox, FileName = "06_bumboks_ludi_akustika_myzuka", Title = "Люди", MeanEnergy = 80, MeanTempo = 50 };
            context.Songs.AddRange(
                people, take, goreDolom, blueSea, neKino,
                bolelshik, nudeKing, seredniViky, human, chaika,
                budSmelim, bet, samnamgulebs, gamodi, gala,
                onlyYou, vazi, iavnana, piramidebi, relado,
                domino, gzaze, zurchanta, fanduri, iasamani);
            context.SaveChanges();

            context.SongMarks.Add(new SongMark() { Song = people, Energy = Convert.ToInt32(people.MeanEnergy), Tempo = Convert.ToInt32(people.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = take, Energy = Convert.ToInt32(take.MeanEnergy), Tempo = Convert.ToInt32(take.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = goreDolom, Energy = Convert.ToInt32(goreDolom.MeanEnergy), Tempo = Convert.ToInt32(goreDolom.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = blueSea, Energy = Convert.ToInt32(blueSea.MeanEnergy), Tempo = Convert.ToInt32(blueSea.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = neKino, Energy = Convert.ToInt32(neKino.MeanEnergy), Tempo = Convert.ToInt32(neKino.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = bolelshik, Energy = Convert.ToInt32(bolelshik.MeanEnergy), Tempo = Convert.ToInt32(bolelshik.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = nudeKing, Energy = Convert.ToInt32(nudeKing.MeanEnergy), Tempo = Convert.ToInt32(nudeKing.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = seredniViky, Energy = Convert.ToInt32(seredniViky.MeanEnergy), Tempo = Convert.ToInt32(seredniViky.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = human, Energy = Convert.ToInt32(human.MeanEnergy), Tempo = Convert.ToInt32(human.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = chaika, Energy = Convert.ToInt32(chaika.MeanEnergy), Tempo = Convert.ToInt32(chaika.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = budSmelim, Energy = Convert.ToInt32(budSmelim.MeanEnergy), Tempo = Convert.ToInt32(budSmelim.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = bet, Energy = Convert.ToInt32(bet.MeanEnergy), Tempo = Convert.ToInt32(bet.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = samnamgulebs, Energy = Convert.ToInt32(samnamgulebs.MeanEnergy), Tempo = Convert.ToInt32(samnamgulebs.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = gamodi, Energy = Convert.ToInt32(gamodi.MeanEnergy), Tempo = Convert.ToInt32(gamodi.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = gala, Energy = Convert.ToInt32(gala.MeanEnergy), Tempo = Convert.ToInt32(gala.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = onlyYou, Energy = Convert.ToInt32(onlyYou.MeanEnergy), Tempo = Convert.ToInt32(onlyYou.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = vazi, Energy = Convert.ToInt32(vazi.MeanEnergy), Tempo = Convert.ToInt32(vazi.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = iavnana, Energy = Convert.ToInt32(iavnana.MeanEnergy), Tempo = Convert.ToInt32(iavnana.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = piramidebi, Energy = Convert.ToInt32(piramidebi.MeanEnergy), Tempo = Convert.ToInt32(piramidebi.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = relado, Energy = Convert.ToInt32(relado.MeanEnergy), Tempo = Convert.ToInt32(relado.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = domino, Energy = Convert.ToInt32(domino.MeanEnergy), Tempo = Convert.ToInt32(domino.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = gzaze, Energy = Convert.ToInt32(gzaze.MeanEnergy), Tempo = Convert.ToInt32(gzaze.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = zurchanta, Energy = Convert.ToInt32(zurchanta.MeanEnergy), Tempo = Convert.ToInt32(zurchanta.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = fanduri, Energy = Convert.ToInt32(fanduri.MeanEnergy), Tempo = Convert.ToInt32(fanduri.MeanTempo) });
            context.SongMarks.Add(new SongMark() { Song = iasamani, Energy = Convert.ToInt32(iasamani.MeanEnergy), Tempo = Convert.ToInt32(iasamani.MeanTempo) });
            context.SaveChanges();

            context.SongTags.Add(new SongTag() { Song = iasamani, Tag = work });
            context.SongTags.Add(new SongTag() { Song = zurchanta, Tag = work });
            context.SongTags.Add(new SongTag() { Song = neKino, Tag = work });
            context.SongTags.Add(new SongTag() { Song = iavnana, Tag = work });
            context.SongTags.Add(new SongTag() { Song = chaika, Tag = work });
            context.SongTags.Add(new SongTag() { Song = human, Tag = work });
            context.SongTags.Add(new SongTag() { Song = bolelshik, Tag = work });
            context.SongTags.Add(new SongTag() { Song = seredniViky, Tag = work });
            context.SongTags.Add(new SongTag() { Song = samnamgulebs, Tag = smooth });
            context.SongTags.Add(new SongTag() { Song = gala, Tag = smooth });
            context.SongTags.Add(new SongTag() { Song = vazi, Tag = smooth });
            context.SongTags.Add(new SongTag() { Song = onlyYou, Tag = smooth });
            context.SongTags.Add(new SongTag() { Song = budSmelim, Tag = smooth });
            context.SongTags.Add(new SongTag() { Song = bet, Tag = smooth });
            context.SongTags.Add(new SongTag() { Song = bet, Tag = funny });
            context.SongTags.Add(new SongTag() { Song = goreDolom, Tag = funny });
            context.SongTags.Add(new SongTag() { Song = take, Tag = funny });
            context.SongTags.Add(new SongTag() { Song = take, Tag = effective });
            context.SongTags.Add(new SongTag() { Song = blueSea, Tag = effective });
            context.SongTags.Add(new SongTag() { Song = relado, Tag = effective });
            context.SaveChanges();
        }
    }
}

