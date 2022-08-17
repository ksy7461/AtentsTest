using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World"); // Hello World 출력
            Console.WriteLine("권세윤"); // 이름 출력
            string str = Console.ReadLine(); // 이름 입력
            Console.WriteLine(str);

            string str1 = "Hello";
            string str2 = "World";
            string str3 = $"Hello {str2}";
            Console.WriteLine(str3);
            Console.WriteLine(str1 + str2);

            //실습
            int level = 1;
            int hp = 10;
            float exp = 0.9f;
            string name = "너굴맨";
            string state = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.\n";
            Console.WriteLine(name + "의 레벨은 " + level + "이고 HP는 " + hp + "이고 exp는 " + exp + "다.");
            Console.WriteLine(state);

            Console.WriteLine($"이름 : {name}\n레벨 : {level}\nHP   : {hp}\nexp  : {exp}\n");

            Console.WriteLine("이름을 입력하세요 : ");
            name = Console.ReadLine();
            Console.WriteLine($"{name}의 레벨을 입력하세요 : ");
            string temp = Console.ReadLine();
            //level = int.Parse(temp); //.Parse string을 int로 바꿈 (숫자로 바꿀 수 있을 때만 가능) 간단하지만 위험
            int.TryParse(temp, out level); //string을 int로 바꿈(숫자로 바꾸지 못하면 0)
                                           //level =Convert.ToInt32(temp); //string을 int로 바꿈 (숫자로 바꿀 수 있을 때만 가능) 더 세세하게 변경가능

            exp = 0.95959595f;

            state = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp * 100:F3}%다.\n"; //exp*100을 소수점 3자리까지
            Console.WriteLine(state);

            //이름, 레벨, hp, 경험치를 각각 입력 받고 출력하는 코드 만들기
            Console.WriteLine("이름을 입력하세요 : ");
            name = Console.ReadLine();
            Console.WriteLine($"{name}의 레벨을 입력하세요 : ");
            temp = Console.ReadLine();
            int.TryParse(temp, out level);
            Console.WriteLine($"{name}의 hp을 입력하세요 : ");
            temp = Console.ReadLine();
            int.TryParse(temp, out hp);
            Console.WriteLine($"{name}의 경험치을 입력하세요 : ");
            temp = Console.ReadLine();
            float.TryParse(temp, out exp);

            state = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp * 100:F3}%다.\n"; //exp*100을 소수점 3자리까지
            Console.WriteLine(state);

            Console.ReadKey();                // 키 입력 대기
        }
    }
}
