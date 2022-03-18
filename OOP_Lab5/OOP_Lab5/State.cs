using System;
using System.Collections.Generic;

namespace OOP_Lab4
{
    public class State
    {
        public static void StateMain()
        {
            // получаем список дисциплин из AF
            List<DisciplineClient> disciplineFromAF = AbstractFactory.listAF;
            var sizeOfList = disciplineFromAF.Count;

            // и берем оттуда одну рандомную
            Random random1 = new Random();
            int value = random1.Next(0, sizeOfList);


            // случайно решаем будем ее усложнять или упрощать
            Random random2 = new Random();
            int stateCount = random2.Next(0, 2);

            switch (stateCount)
            {
                case 0: disciplineFromAF[value].Simplify(); break;
                case 1: disciplineFromAF[value].Complicate(); break;
            }
        }
    }


    // интерфейс операций: усложнение или упрощение, параметр - сама дисциплина
    public interface IState
    {
        void Simplify(DisciplineClient disc);
        void Complicate(DisciplineClient disc);
    }


    // дефолтное состояние: создаем новый объект интерфейса State;
    // если упростим\усложним, меняем StateName и добавляем\отнимаем лабы
    class DefaultState : IState
    {
        public void Complicate(DisciplineClient disc)
        {
            disc.State = new ComplicatedState();
            disc.discipline.StateName = "Усложнение обычной дисциплины";
            disc.discipline.NumberOfLabs *= 2;
            disc.discipline.NumberOfLections *= 2;
        }

        public void Simplify(DisciplineClient disc)
        {
            disc.State = new SimpleState();
            disc.discipline.StateName = "Упрощение обычной дисциплины";
            disc.discipline.NumberOfLabs /= 2;
            disc.discipline.NumberOfLections /= 2;
        }
    }


    // усложеннное состояние: тут можем только упростить, тогда получим уникальный текст в StateName
    class ComplicatedState : IState
    {
        public void Complicate(DisciplineClient disc) { }

        public void Simplify(DisciplineClient disc)
        {
            disc.State = new DefaultState();
            disc.discipline.StateName = "Обычная дисциплина; упрощение сложной дисциплины";
            disc.discipline.NumberOfLabs /= 2;
            disc.discipline.NumberOfLections /= 2;
        }
    }


    // то же самое только с простой дисциплиной
    class SimpleState : IState
    {
        public void Complicate(DisciplineClient disc)
        {
            disc.State = new DefaultState();
            disc.discipline.StateName = "Обычная дисциплина; усложнение простой дисциплины";
            disc.discipline.NumberOfLabs *= 2;
            disc.discipline.NumberOfLections *= 2;
        }

        public void Simplify(DisciplineClient disc) { }
    }
}
