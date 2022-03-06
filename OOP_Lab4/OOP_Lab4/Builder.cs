using System;
using System.Collections.Generic;

namespace OOP_Lab4
{
    abstract class Builder  // абстрактный класс строителя
    {
        public Discipline Discipline { get; private set; }              // в этот обьект будем создавать дисциплину с помощью конкретных билдеров по шагам:
        // эти методы будет переопределять в каждом конкретном билдере
        public void CreateDiscipline() => Discipline = new Discipline();// 0. создать пустой объект
        public abstract void BuildLector();                             // 1. создать лектора
        public abstract void BuildDiscipline();                         // 2. создать всю дисциплину
    }


    class Director      // класс менеджера, который делегирует билдеру создание дисциплины
    {
        // в этот список запишем пару дисциплин и выведем их в MessageBox
        public static List<Discipline> listOfDisciplinesBuilder = new List<Discipline>();

        // метод директора, который приказывает билдеру пошагово создать дисциплины и вернуть ее (рабовладения пиздец)
        public Discipline ConstuctAll(Builder builder)
        {
            builder.CreateDiscipline();
            builder.BuildLector();
            builder.BuildDiscipline();
            return builder.Discipline;
        }

        // это якобы мейн (аки с метанита), но этот статик метод буду вызывать каждый раз при нажатии соответствующей кнопки
        public static void BuilderMain()
        {
            Director director = new Director();                 // экземпляр директора

            Builder builder = new ReactBuilder();               // работяга типа РеактБилдер
            Discipline react = director.ConstuctAll(builder);   // создаем реакт с помощью работяги
            listOfDisciplinesBuilder.Add(react);                // добавляем в список который потом выведем на экран

            builder = new CSharpBuilder();                      // работяга теперь типа ШарпыБилдер
            Discipline oop = director.ConstuctAll(builder);     // новая дисциплина ООП с помощью работяги типа шарпыБилдер
            listOfDisciplinesBuilder.Add(oop);                  // опять в списочек (это якобы рандом)
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

}
