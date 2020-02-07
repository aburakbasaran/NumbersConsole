using System;

namespace ConsoleApp
{
    class Program
    {
        public static int x = 0;
        public static int y = 0;
        static void Main(string[] args)
        {
            string val;
            Console.Write("Enter  2 Integer: ");
            val = Console.ReadLine();
            string[] numbers = val.Split(' ');
            x = Convert.ToInt32(numbers[0]);
            y = Convert.ToInt32(numbers[1]);
            Console.Write("Enter Starting Point:");
            string startingPoint = Console.ReadLine();
            Console.Write("Enter movements:");
            string movements = Console.ReadLine();
            char[] charArr = movements.ToCharArray();
            try
            {
                foreach (char ch in charArr)
                {
                    startingPoint = GetLastPoint(x, y, startingPoint, ch);
                }
                Console.Write(startingPoint);
            }
           catch(Exception e)
            {
                Console.Write(e.Message);
            }
        }


        public static string GetLastPoint(int x, int y, string lastPoint, char lastAction)
        {
            string[] numbers = lastPoint.Split(' ');
            if(numbers.Length!=3)
            {
                throw new Exception("Hatalı Format!!");
            }
            int selectedX = Convert.ToInt32(numbers[0]);
            int selectedY = Convert.ToInt32(numbers[1]);
            string selectedWay = numbers[2];

            switch (lastAction)
            {
                case 'M':
                    lastPoint = GetNewCoordinate(selectedX, selectedY, selectedWay);
                    break;
                default:
                    selectedWay = GetLastFace(selectedWay, lastAction);
                    lastPoint = selectedX + " " + selectedY + " " + selectedWay;
                    break;
            }
            return lastPoint;
        }

        public static string GetLastFace(string position, char movement)
        {
            switch (position)
            {
                case "N":
                    if (movement == 'L')
                    {
                        position = "W";
                    }
                    else
                    {
                        position = "E";
                    }
                    break;
                case "S":
                    if (movement == 'L')
                    {
                        position = "E";
                    }
                    else
                    {
                        position = "W";
                    }
                    break;
                case "E":
                    if (movement == 'L')
                    {
                        position = "N";
                    }
                    else
                    {
                        position = "S";
                    }
                    break;
                case "W":
                    if (movement == 'L')
                    {
                        position = "S";
                    }
                    else
                    {
                        position = "N";
                    }
                    break;
                default:
                    throw new Exception("Tanımsız Karaketer Hatalı Giriş!!!");
                    break;
            }

            return position;
        }

        public static string GetNewCoordinate(int selectedX, int selectedY, string selectedWay)
        {
            switch (selectedWay)
            {
                case "N":
                    selectedY = selectedY + 1;
                    if (selectedY > y)
                        throw new Exception("Coordinant Dışı Hareket!!");
                    break;
                case "S":
                    selectedY = selectedY - 1;
                    if (selectedY < 0)
                        throw new Exception("Coordinant Dışı Hareket!!");
                    break;
                case "E":
                    selectedX = selectedX + 1;
                    if (selectedX > x)
                        throw new Exception("Coordinant Dışı Hareket!!");
                    break;
                case "W":
                    selectedX = selectedX - 1;
                    if (selectedX < 0)
                        throw new Exception("Coordinant Dışı Hareket!!");
                    break;
            }

            return selectedX + " " + selectedY + " " + selectedWay;
        }
    }
}
