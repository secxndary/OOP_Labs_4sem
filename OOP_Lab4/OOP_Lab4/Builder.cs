using System;
using System.Collections.Generic;

namespace OOP_Lab4
{
    abstract class Builder  // абстрактный класс строителя
    {
        public Discipline Discipline { get; private set; }

        public void CreateDiscipline() => Discipline = new Discipline();
        public abstract void BuildLector();
        public abstract void BuildDiscipline();
    }


    class Director      // класс менеджера, который делегирует билдеру создание дисциплины
    {
        public static List<Discipline> listOfDisciplinesBuilder = new List<Discipline>();

        public Discipline ConstuctAll(Builder builder)
        {
            builder.CreateDiscipline();
            builder.BuildLector();
            builder.BuildDiscipline();
            return builder.Discipline;
        }

        public static void BuilderMain()
        {
            Director director = new Director();
            Builder builder = new ReactBuilder();
            Discipline react = director.ConstuctAll(builder);
            listOfDisciplinesBuilder.Add(react);
        }
    }


    class ReactBuilder : Builder    // создать дисциплину по реакту
    {
        public override void BuildLector()
        {
            Discipline.lector = new Lector("Информатики и Веб-дизайна", "Н.А.Жиляк", "312-1");
        }

        public override void BuildDiscipline()
        {
            Discipline.Name = "React JS";
            Discipline.Semester = "1-ый семестр";
            Discipline.Course = new List<string> { "2-ой курс" };
            Discipline.Speciality = new List<string> { "ПОИТ", "ДЭВИ" };
            Discipline.NumberOfLections = 12;
            Discipline.NumberOfLabs = 32;
            Discipline.Control = "зачёт";
            Discipline.Type = "ДИСЦИПЛИНА ПО REACT\n";
        }
    }


}
