using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IFunctions //Интерфейс, описывающий функцию
    {
        int Number { get; } //Номер функции в меню
        string Name { get; } //Название функции
        GlobalCommand Command(); //Функция
    }
}
