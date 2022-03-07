using System;
using System.Collections.Generic;

namespace OOP_Lab4
{
    // своеобразный мейн для передачи данных в форму
    public static class AbstractFactory
    {
        // в этом списке храним созданные дисциплины
        public static List<DisciplineClient> listAF = new List<DisciplineClient>();

        public static void AFMain()
        {
            Random random = new Random();       // рандом число от 1 до 3
            int value = random.Next(1, 4);

            switch (value)
            {
                case 1:
                    DisciplineClient web = new DisciplineClient(new WebFactory());
                    web.CreateLectorClient();
                    web.CreateDisciplineClient();
                    listAF.Add(web);
                    break;
                case 2:
                    DisciplineClient oop = new DisciplineClient(new OOPFactory());
                    oop.CreateLectorClient();
                    oop.CreateDisciplineClient();
                    listAF.Add(oop);
                    break;
                case 3:
                    DisciplineClient mp = new DisciplineClient(new MPFactory());
                    mp.CreateLectorClient();
                    mp.CreateDisciplineClient();
                    listAF.Add(mp);
                    break;
            }
        }
    }


    //абстрактный класс - лектор
    public abstract class LectorAF
    {
        // абстрактный метод создания лектора (входные данные будут зависеть от фабрики)
        public abstract void CreateLector();

        // старые добрые поля,которые будем заполнять в переопределнном методе
        // CreateLector() в наследованных от этого абстрактного класса классах
        public string Department { get; set; }   
        public string Name { get; set; }         
        public string Auditorium { get; set; }   
    }


    // абстрактный класс – дисциплина
    public abstract class DisciplineAF
    {
        // то же самое что и с лектором
        public abstract void CreateDiscipline();

        public string Name { get; set; }    
        public string Semester { get; set; }            
        public List<string> Course { get; set; }        
        public List<string> Speciality { get; set; }   
        public int NumberOfLections { get; set; }       
        public int NumberOfLabs { get; set; }           
        public string Control { get; set; }          
        public LectorAF lector { get; set; }           
        public string Type { get; set; }           
    }


    // класс конкретный лектор по вебу
    public class WebLector : LectorAF
    {
        public override void CreateLector()
        {
            Department = "Информатики и Веб-дизайна";
            Name = "Н.А.Жиляк";
            Auditorium = "312-1";
        }
    }


    // класс конкретный лектор по ооп
    public class OOPLector : LectorAF
    {
        public override void CreateLector()
        {
            Department = "Информационных систем и технологий";
            Name = "Н.В.Пацей";
            Auditorium = "200-3а";
        }
    }


    // класс конкретный лектор по матпроге
    public class MPLector : LectorAF
    {
        public override void CreateLector()
        {
            Department = "Высшей математики";
            Name = "О.Б.Плющ";
            Auditorium = "200-3а";
        }
    }


    // создать дисциплину веб (все эти классы наследуются от соответствующих абстрактных
    // классов и переопределяют методы для создания объектов)
    public class WebDisciplineAF : DisciplineAF
    {
        public override void CreateDiscipline()
        {
            Name = "React JS";
            Semester = "2-ой семестр";
            Course = new List<string> { "2-ой курс" };
            Speciality = new List<string> { "ПОИТ", "ДЭВИ" };
            NumberOfLections = 12;
            NumberOfLabs = 32;
            Control = "зачёт";
            Type = "ДИСЦИПЛИНА ПО REACT\n";
        }
    }


    // создать дисцпилину ооп
    public class OOPDisciplineAF : DisciplineAF
    { 
        public override void CreateDiscipline()
        {
            Name = "ООТПиСП";
            Semester = "1-ый семестр";
            Course = new List<string> { "2-ой курс" };
            Speciality = new List<string> { "ПОИТ", "ДЭВИ", "ИСИТ" };
            NumberOfLections = 24;
            NumberOfLabs = 36;
            Control = "экзамен";
            Type = "ДИСЦИПЛИНА ПО ООП\n";
        }
    }


    // создать дисцпилину матпрога
    public class MPDisciplineAF : DisciplineAF
    {
        public override void CreateDiscipline()
        {
            Name = "Математическое программирование";
            Semester = "2-ой семестр";
            Course = new List<string> { "2-ой курс" };
            Speciality = new List<string> { "ПОИТ", "ДЭВИ" };
            NumberOfLections = 24;
            NumberOfLabs = 16;
            Control = "экзамен";
            Type = "ДИСЦИПЛИНА ПО МАТПРОГЕ\n";
        }
    }


    // класс абстрактной фабрики
    public abstract class DisciplineFactory
    {
        public abstract DisciplineAF CreateDiscipline();
        public abstract LectorAF CreateLector();
    }


    // фабрика создания веба: переопределяем методы создания дисциплины и лектора
    // таким образом, чтобы в этих методах тупо вызывались методы создания из 
    // соответствующих переопределнных классов конкретных дисциплин
    public class WebFactory : DisciplineFactory
    {
        public override DisciplineAF CreateDiscipline() => new WebDisciplineAF();

        public override LectorAF CreateLector() => new WebLector();
    }


    // фабрика создания ооп
    public class OOPFactory : DisciplineFactory
    {
        public override DisciplineAF CreateDiscipline() => new OOPDisciplineAF();

        public override LectorAF CreateLector() => new OOPLector();
    }


    // фабрика создания матпроги
    public class MPFactory : DisciplineFactory
    {
        public override DisciplineAF CreateDiscipline() => new MPDisciplineAF();

        public override LectorAF CreateLector() => new MPLector();
    }


    // клиентский объект - реальная дисциплина, объекты которой будут передаваться в list
    // и выводиться на экран. здесь есть поля абстрактных лектора и дисциплины, которые мы
    // инициализируем с помощью методов CreateDisciplineClient() и CreateLectorClient().
    // то, какие именно объекты создадутся (дисциплина по вебу, по ооп, ...) будет
    // зависеть от того, какую фабрику мы передадим в параметры конструктора.
    public class DisciplineClient
    {
        public readonly LectorAF lector;
        public readonly DisciplineAF discipline;

        public DisciplineClient(DisciplineFactory factory)
        {
            lector = factory.CreateLector();
            discipline = factory.CreateDiscipline();
        }

        public void CreateDisciplineClient() => discipline.CreateDiscipline();

        public void CreateLectorClient() => lector.CreateLector();

        // в класса DisciplineClient есть как поля лектора, так и поля дисциплины, так что мы
        // можем обратиться ко всем этим полям внутри этого класса и переопределить ToString()
        public override string ToString()
        {
            string course = "";
            string speciality = "";
            foreach (string c in discipline.Course)
                course += c + "; ";
            foreach (string s in discipline.Speciality)
                speciality += s + "; ";
            string res = $"\t\t             ABSTRACT FACTORY\n{discipline.Type}Название: {discipline.Name}\nКурс: " +
                $"{course}\nСеместр: {discipline.Semester}\nСпециальность: {speciality}\n" +
                $"Часов лекций: {discipline.NumberOfLections}\nЧасов лабораторных: " +
                $"{discipline.NumberOfLabs}\nТип контроля: {discipline.Control}\n" +
                $"ФИО лектора: {lector.Name}\nКафедра: {lector.Department}\n" +
                $"Аудитория: {lector.Auditorium}\n\n==============================================\n\n";
            return res;
        }
    }
}
