using System;
using System.Collections.Generic;


namespace OOP_Lab4
{
    public class MainDecorator
    {
        public static void DecoratorMain()
        {
            // рандом для получения случайного элемента из списка дисциплин билдера
            var sizeOfList = Director.listOfDisciplinesBuilder.Count;
            Random random = new Random(); 
            int value = random.Next(0, sizeOfList);


            // рандом для выбора случайной декорации
            Random random1 = new Random();
            int randDecor = random1.Next(0, 3);


            // собсна сам рандомный выбор усиления
            switch (randDecor)
            {
                case 0:
                    Discipline disciplineHours = Director.listOfDisciplinesBuilder[value];
                    disciplineHours = new ExamsDecorate(disciplineHours).disciplineDecorate;
                    Director.listOfDisciplinesBuilder[value] = disciplineHours;
                    break;
                case 1:
                    Discipline disciplineExams = Director.listOfDisciplinesBuilder[value];
                    disciplineExams = new HoursDecorate(disciplineExams).disciplineDecorate;
                    Director.listOfDisciplinesBuilder[value] = disciplineExams;
                    break;
                case 2:
                    Discipline disciplineGeneral = Director.listOfDisciplinesBuilder[value];
                    disciplineGeneral = new GeneralDecorate(disciplineGeneral).disciplineDecorate;
                    Director.listOfDisciplinesBuilder[value] = disciplineGeneral;
                    break;
            }
        }
    }



    // абстрактный класс декоратора. сюда передаем готовую дисциплину как поле класса
    abstract class DisciplineDecorator : Discipline
    {
        public Discipline disciplineDecorate;
        public DisciplineDecorator(Discipline discipline) => disciplineDecorate = discipline;
    }


    // усиление: добавляем часы лаб и лекций
    class HoursDecorate : DisciplineDecorator
    {
        public HoursDecorate(Discipline discipline) : base(discipline)
        {
            disciplineDecorate.Type = "УСИЛЕННАЯ " + disciplineDecorate.Type;
            disciplineDecorate.NumberOfLabs += 12;
            disciplineDecorate.NumberOfLections += 24;
        }
    }


    // усиление: меняем контроль на экзамен
    class ExamsDecorate : DisciplineDecorator
    {
        public ExamsDecorate(Discipline discipline) : base(discipline)
        {
            disciplineDecorate.Type = "ЭКЗАМЕНАЦИОННАЯ " + disciplineDecorate.Type;
            disciplineDecorate.Control = "экзамен";
        }
    }


    // усиление: дисциплину теперь проходят все спецухи
    class GeneralDecorate : DisciplineDecorator
    {
        public GeneralDecorate(Discipline discipline) : base(discipline)
        {
            disciplineDecorate.Type = "ОБЩАЯ " + disciplineDecorate.Type;
            disciplineDecorate.Speciality = new List<string> { "ПОИТ", "ИСИТ", "ДЭВИ", "ПОИБМС" };
        }
    }

}
