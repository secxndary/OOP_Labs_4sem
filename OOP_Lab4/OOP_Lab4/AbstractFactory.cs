using System.Collections.Generic;

namespace OOP_Lab4
{
    public static class AbstractFactory
    {
        public static List<DisciplineClient> listAF = new List<DisciplineClient>();

        public static void AFMain()
        {
            listAF.Clear();

            DisciplineClient web = new DisciplineClient(new WebFactory());
            web.CreateLectorClient();
            web.CreateDisciplineClient();

            DisciplineClient oop = new DisciplineClient(new OOPFactory());
            oop.CreateLectorClient();
            oop.CreateDisciplineClient();

            listAF.Add(oop);
            listAF.Add(web);
        }
    }

    //абстрактный класс - лектор
    public abstract class LectorAF
    {
        public string Department { get; set; }      // кафедра
        public string Name { get; set; }            // фио
        public string Auditorium { get; set; }      // аудитория

        public abstract void CreateLector();
    }

    // абстрактный класс – дисциплина
    public abstract class DisciplineAF
    {
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


        public override string ToString()   /// вывод инфы об объекте
        {
            string course = "";
            string speciality = "";
            foreach (string c in Course)
                course += c + "; ";
            foreach (string s in Speciality)
                speciality += s + "; ";

            string res = $"{Type}Название: {Name}\nКурс: {course}\nСеместр: {Semester}\n" +
                $"Специальность: {speciality}\nЧасов лекций: {NumberOfLections}\n" +
                $"Часов лабораторных: {NumberOfLabs}\nТип контроля: {Control}\n" +
                $"ФИО лектора: {lector.Name}\nКафедра: {lector.Department}\n" +
                $"Аудитория: {lector.Auditorium}\n\n==============================================\n\n";
            return res;
        }

    }

    // класс лектор по вебу
    public class WebLector : LectorAF
    {
        public override void CreateLector()
        {
            Department = "Информатики и Веб-дизайна";
            Name = "Н.А.Жиляк";
            Auditorium = "312-1";
        }
    }

    // класс лектор по ооп
    public class OOPLector : LectorAF
    {
        public override void CreateLector()
        {
            Department = "Информационных систем и технологий";
            Name = "Н.В.Пацей";
            Auditorium = "200-3а";
        }
    }

    // создать дисциплину веб
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

    // класс абстрактной фабрики
    public abstract class DisciplineFactory
    {
        public abstract DisciplineAF CreateDiscipline();
        public abstract LectorAF CreateLector();
    }

    // фабрика создания веба
    public class WebFactory : DisciplineFactory
    {
        public override DisciplineAF CreateDiscipline()
        {
            return new WebDisciplineAF();
        }

        public override LectorAF CreateLector()
        {
            return new WebLector();
        }
    }

    // Фабрика создания ооп
    public class OOPFactory : DisciplineFactory
    {
        public override DisciplineAF CreateDiscipline()
        {
            return new OOPDisciplineAF();
        }

        public override LectorAF CreateLector()
        {
            return new OOPLector();
        }
    }

    // клиент - сама дисицплина
    public class DisciplineClient
    {
        private LectorAF lector;
        private DisciplineAF discipline;

        public DisciplineClient(DisciplineFactory factory)
        {
            lector = factory.CreateLector();
            discipline = factory.CreateDiscipline();
        }

        public void CreateDisciplineClient()
        {
            discipline.CreateDiscipline();
        }

        public void CreateLectorClient()
        {
            lector.CreateLector();
        }


        public override string ToString()
        {
            string course = "";
            string speciality = "";
            foreach (string c in discipline.Course)
                course += c + "; ";
            foreach (string s in discipline.Speciality)
                speciality += s + "; ";
            string res = $"{discipline.Type}Название: {discipline.Name}\nКурс: {course}\nСеместр: {discipline.Semester}\n" +
                $"Специальность: {speciality}\nЧасов лекций: {discipline.NumberOfLections}\n" +
                $"Часов лабораторных: {discipline.NumberOfLabs}\nТип контроля: {discipline.Control}\n" +
                $"ФИО лектора: {lector.Name}\nКафедра: {lector.Department}\n" +
                $"Аудитория: {lector.Auditorium}\n\n==============================================\n\n";
            return res;
        }
    }
}
