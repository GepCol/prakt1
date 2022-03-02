using System;
using System.Drawing;

namespace Pract_02_03 {
    class Program {
        static String prefix;
        static Random r = new Random();
        static void Main(string[] args) {
            //Сойдёт за задание с циклом?
            Console.WriteLine("По скольку раз вам повторять, чтобы поняли?");
            Console.Write("-> ");
            int rep = int.Parse(Console.ReadLine());
            int i;
            for (i = 0; i < rep; i++) task1();
            i = rep;
            while (i-->0) task2();
            i = rep;
            do task3(); while (0<--i);
            TIR();
            bool ЕщёГорит = true;
            for (; ; ) {
                Console.Write("Конееееец!!! ");
                ЕщёГорит = r.NextDouble() > 0.1;
                if (ЕщёГорит) continue;
                Console.WriteLine("Ладно, всё, я успокоился.");
                break;
            }
        }

        static void task1() {
            prefix = "task1";
            Console.Write("X=");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y=");
            double y = double.Parse(Console.ReadLine());
            if (x * x + y * y < 9 && y > 0) {
                writeln("Внутри.");
            }else if (x * x + y * y > 9 || y < 0) {
                writeln("Снаружи.");
            } else {
                writeln("Посередине.");
            }
        }

        static void task2() {
            prefix = "task2";
            double a, b;
            char c;
            Console.Write("A = ");
            a = double.Parse(Console.ReadLine());
            Console.Write("B = ");
            b = double.Parse(Console.ReadLine());
            Console.Write("OP = ");
            c = char.Parse(Console.ReadLine());
            double ret = 0;
            bool ok = true;
            switch (c) {
                case '+':ret = a + b;break;
                case '-': ret = a + b; break;
                case '*': ret = a * b; break;
                case '/':
                case ':': ret = a / b; break;
                default: ok = false;break;
            }
            writeln(ok?$"{a} {c} {b} = {ret}":"Шо?");
        }

        static void task3() {
            prefix = "task3";
            writeln($"Введите год. Любой. Хоть {r.Next(9999,999999)}-й.");
            int y = int.Parse(Console.ReadLine());
            writeln(y % 4 == 0 && y % 100 != 0 || y % 400 == 0 ? "Поздравляем! Год високосный." : "Поздравляем с обычным годом.");
        }



        static void writeln(String st) {
            Console.WriteLine("["+prefix+"] "+st);
        }

        static void TIR() {
            prefix = "ТИР!";
            writeln("Добро пожаловать в тир \"Пристрели бога\". Вы будете стрелять по воздуху, а я говорить, попали вы или нет.");
            writeln("Вы поставили дом и первенца на кон, так что можете выбрать любое число попыток. Тогда вы точно выйграете плюшевую шишку!");
            int att = int.Parse(Console.ReadLine());
            Point center = new Point(r.Next(0, 100), r.Next(0, 100));
            int p = 0;
            while (att-->0) {
                writeln("Стреляй! Ну или... Швыряй! [в одной строке x и y введите. Размер поля = [1-100]x[1-100]]");
                string[] sts = Console.ReadLine().Split();
                int x = int.Parse(sts[0]), y = int.Parse(sts[1]);
                double d = dist(center, x, y);
                if (d <= 5) {
                    writeln("ИДЕАЛЬНОЕ ПОПАДАНИЕ! +10 баллов.");
                    p += 10;
                }else if (d<=10) {
                    writeln("Почти в центр! +5 баллов.");
                    p += 5;
                } else if (d <= 15) {
                    writeln("Ну, попадение было... +1 балл.");
                    p += 1;
                } else {
                    writeln("Давай по-новой, Миша...");
                }
            }
            writeln($"Так-с, ну, попыток больше нет... У вас {p} баллов... Плюшевая шишка? Вы о чём? Я вас не знаю. Спасибо за квартиру, пока!!...");
        }
        static double dist(Point p, int x, int y) {
            return Math.Sqrt((p.Y - y) * (p.Y - y) + (p.X - x) * (p.X - x));
        }
    }
}
