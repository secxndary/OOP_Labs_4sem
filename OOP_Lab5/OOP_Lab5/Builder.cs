using System;
using System.Collections.Generic;

namespace OOP_Lab4
{
    // абстрактный класс билдера
    abstract class Builder
    {
        public Discipline Discipline { get; private set; }               // в этот обьект будем создавать дисциплину с помощью конкретных билдеров по шагам:
        // эти методы будеv переопределять в каждом конкретном билдере
        public void CreateDiscipline() => Discipline = new Discipline(); // 0. создать пустой объект
        public abstract void BuildLector();                              // 1. создать лектора
        public abstract void BuildDiscipline();                          // 2. создать всю дисциплину
    }


    // класс менеджера, который делегирует билдеру создание дисциплины
    class Director
    {
        // в этот список запишем пару дисциплин и выведем их в MessageBox
        public static List<Discipline> listOfDisciplinesBuilder = new List<Discipline>();

        // метод директора, который приказывает билдеру пошагово создать дисциплину и вернуть ее (рабовладения пиздец)
        public Discipline ConstuctAll(Builder builder)
        {
            builder.CreateDiscipline();
            builder.BuildLector();
            builder.BuildDiscipline();
            return builder.Discipline;
        }


        // что-то вроде мейна, здесь каждый раз при нажатии буттона будет добавляться в список одна рандомная дисциплина
        public static void BuilderMain()
        {
            Director director = new Director();         // экземпляр директора

            Random random = new Random();               // рандом число от 1 до 4
            int value = random.Next(1, 5);

            switch (value)
            {
                case 1:
                    Builder builderReact = new ReactBuilder();               // работяга типа РеактБилдер
                    Discipline react = director.ConstuctAll(builderReact);   // создаем реакт с помощью работяги
                    listOfDisciplinesBuilder.Add(react);                     // добавляем в список который потом выведем на экран
                    break;
                case 2:
                    Builder builderCharp = new CSharpBuilder();              // работяга теперь типа ШарпыБилдер
                    Discipline oop = director.ConstuctAll(builderCharp);     // новая дисциплина ООП с помощью работяги типа шарпыБилдер
                    listOfDisciplinesBuilder.Add(oop);                       // опять в списочек
                    break;
                case 3:
                    Builder builderNN = new NoNameBuilder();                 // создать дисциплину без лектора   
                    Discipline noName = director.ConstuctAll(builderNN);
                    listOfDisciplinesBuilder.Add(noName);
                    break;
                case 4:
                    Builder builderMP = new MPBuilder();                     // создать матпрогу  
                    Discipline MathProg = director.ConstuctAll(builderMP);
                    listOfDisciplinesBuilder.Add(MathProg);
                    break;
            }
        }
    }




    class ReactBuilder : Builder    // первый конкретный билдер: создать дисциплину по реакту
    {
        public override void BuildLector()  // переопределяем: лектор веба - жилячка
        {
            Discipline.lector = new Lector("Информатики и Веб-дизайна", "Н.А.Жиляк", "312-1");
        }

        public override void BuildDiscipline()  // переопределяем всю инфу о дисциплине реакт
        {
            Discipline.Name = "React JS";
            Discipline.Semester = "2-ой семестр";
            Discipline.Course = new List<string> { "2-ой курс" };
            Discipline.Speciality = new List<string> { "ПОИТ", "ДЭВИ" };
            Discipline.NumberOfLections = 12;
            Discipline.NumberOfLabs = 32;
            Discipline.Control = "зачёт";
            Discipline.Type = "ДИСЦИПЛИНА ПО REACT\n";
        }
    }


    class CSharpBuilder : Builder    // второй конкретный билдер: создать дисциплину по шарпам
    {
        public override void BuildLector()  // те же самые переопределения
        {
            Discipline.lector = new Lector("Информационных систем и технологий", "Н.В.Пацей", "200-3а");
        }

        public override void BuildDiscipline()  // основная идея билдеров - это создание по частям
        {
            Discipline.Name = "ООТПиСП";
            Discipline.Semester = "1-ый семестр";
            Discipline.Course = new List<string> { "2-ой курс" };
            Discipline.Speciality = new List<string> { "ПОИТ", "ДЭВИ", "ИСИТ" };
            Discipline.NumberOfLections = 24;
            Discipline.NumberOfLabs = 36;
            Discipline.Control = "экзамен";
            Discipline.Type = "ДИСЦИПЛИНА ПО ООП\n";
        }
    }


    class NoNameBuilder : Builder    // третий конкретный билдер: создать дисциплину БЕЗ ЛЕКТОРА
    {
        public override void BuildLector()  // я могу переопределить шаги типа "создать лектора" и "создать дисциплину" и, например, вообще опустить создание лектора и создать пустой объект
        {
            Discipline.lector = new Lector();
        }

        public override void BuildDiscipline()
        {
            Discipline.Name = "No Name";
            Discipline.Semester = "1-ый семестр";
            Discipline.Course = new List<string> { "2-ой курс" };
            Discipline.Speciality = new List<string> { "ПОИТ" };
            Discipline.NumberOfLections = 0;
            Discipline.NumberOfLabs = 0;
            Discipline.Control = "зачёт";
            Discipline.Type = "ДИСЦИПЛИНА БЕЗ ЛЕКТОРА\n";
        }
    }


    class MPBuilder : Builder    // матпрога
    {
        public override void BuildLector()
        {
            Discipline.lector = new Lector("Высшей математики", "О.Б.Плющ", "100-3a");
        }

        public override void BuildDiscipline()
        {
            Discipline.Name = "Математическое программирование";
            Discipline.Semester = "2-ой семестр";
            Discipline.Course = new List<string> { "2-ой курс" };
            Discipline.Speciality = new List<string> { "ПОИТ", "ДЭВИ" };
            Discipline.NumberOfLections = 24;
            Discipline.NumberOfLabs = 16;
            Discipline.Control = "экзамен";
            Discipline.Type = "ДИСЦИПЛИНА ПО МАТПРОГЕ\n";
        }
    }
}
