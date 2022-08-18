using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumResult = Sum(10, 20);  // break point (단축기 F9)
            Console.WriteLine(sumResult);

            Print();

            string name = "너굴맨";
            int level = 2;
            int hp = 10;
            int maxHp = 20;
            float exp = 0.1f;
            float maxExp = 1.0f;

            PrintCharacter(name,level,hp,maxHp,exp,maxExp);

            Console.ReadKey();                // 키 입력 대기

            //Main함수 끝
        }

        private static void PrintCharacter(string name,int level, int hp, int maxHp, float exp, float maxExp)
        {
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"level : {level}");
            Console.WriteLine($"hp : {hp}");
            Console.WriteLine($"maxHp : {maxHp}");
            Console.WriteLine($"exp : {exp}");
            Console.WriteLine($"maxExp : {maxExp}");
        }

        // 함수의 구성요소 : 이름 ,리턴타입, 파라메터(매개변수),함수바디
        // 함수 이름 리턴타입 파라메터를 합쳐서 함수 프로토타입 함수의 주민등록번호
        static int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }

        static void Print()
        {
            Console.WriteLine("Print");
        }

        void Test()
        {
            //Console.WriteLine("Hello World"); // Hello World 출력
            //Console.WriteLine("권세윤"); // 이름 출력
            //string str = Console.ReadLine(); // 이름 입력
            //Console.WriteLine(str);

            string str1 = "Hello";
            string str2 = "World";
            string str3 = $"Hello {str2}";
            Console.WriteLine(str3);
            Console.WriteLine(str1 + str2);

            //실습
            int level = 3;
            int hp = 2;
            float exp = 0.5f;
            string name = "너굴맨";
            string temp;
            string state;
            //state = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp}다.\n";
            //Console.WriteLine(name + "의 레벨은 " + level + "이고 HP는 " + hp + "이고 exp는 " + exp + "다.");
            //Console.WriteLine(state);

            //Console.WriteLine($"이름 : {name}\n레벨 : {level}\nHP   : {hp}\nexp  : {exp}\n");

            //Console.WriteLine("이름을 입력하세요 : ");
            //name = Console.ReadLine();
            //Console.WriteLine($"{name}의 레벨을 입력하세요 : ");
            //temp = Console.ReadLine();
            ////level = int.Parse(temp); //.Parse string을 int로 바꿈 (숫자로 바꿀 수 있을 때만 가능) 간단하지만 위험
            //int.TryParse(temp, out level); //string을 int로 바꿈(숫자로 바꾸지 못하면 0)
            //                               //level =Convert.ToInt32(temp); //string을 int로 바꿈 (숫자로 바꿀 수 있을 때만 가능) 더 세세하게 변경가능

            //exp = 0.95959595f;

            //state = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp * 100:F3}%다.\n"; //exp*100을 소수점 3자리까지
            //Console.WriteLine(state);

            //이름, 레벨, hp, 경험치를 각각 입력 받고 출력하는 코드 만들기
            //Console.WriteLine("이름을 입력하세요 : ");
            //name = Console.ReadLine();
            //Console.WriteLine($"{name}의 레벨을 입력하세요 : ");
            //temp = Console.ReadLine();
            //int.TryParse(temp, out level);
            //Console.WriteLine($"{name}의 hp을 입력하세요 : ");
            //temp = Console.ReadLine();
            //int.TryParse(temp, out hp);
            //Console.WriteLine($"{name}의 경험치을 입력하세요 : ");
            //temp = Console.ReadLine();
            //float.TryParse(temp, out exp);

            //state = $"{name}의 레벨은 {level}이고 HP는 {hp}이고 exp는 {exp * 100:F3}%다.\n";
            //Console.WriteLine(state);

            //-------------------------------------------------------------------------------------------------- 변수 끝

            // 제어문(Control state) - 조건문(if, switch) , 반복문
            // 조건문
            hp = 9;
            if (hp < 3)
            {
                Console.WriteLine("HP가 부족합니다.");
            }
            else if (hp < 10)
            {
                Console.WriteLine("HP가 적당합니다.");
            }
            else
            {
                Console.WriteLine("HP가 충분합니다.");
            }

            switch (hp)
            {
                case 0:
                    Console.WriteLine("HP가 0입니다");
                    break;
                case 5:
                    Console.WriteLine("HP가 5입니다.");
                    break;
                default:
                    Console.WriteLine("HP가 0과 5가 아닙니다.");
                    break;
            }

            // 실습 :exp의 값과 추가로 입력받은 경험치의 합이 1이상이면 "레벨업"이라고 출력하고 1미만이면 합계를 출력하는 코드

            //Console.WriteLine("경험치를 추가합니다.");
            //Console.Write("추가할 경험치 : ");
            //temp = Console.ReadLine();


            //float tempExp;
            //float.TryParse(temp, out tempExp);
            //if( (exp + tempExp) >= 1.0f)
            //{
            //    Console.WriteLine("레벨업!");
            //}
            //else
            //{
            //    Console.WriteLine($"현재 경헙치 : {exp + tempExp}");
            //}

            // 반복문 

            level = 1;
            while (level < 3)
            {
                Console.WriteLine($"현재 레벨 : {level}");
                level++;
            }

            hp = 10;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"현재 HP : {hp}");
                hp += 10;
            }
            Console.WriteLine($"최종 HP : {hp}");

            level = 1;
            do
            {
                Console.WriteLine($"현재 레벨 : {level}");

                if (level == 2)
                {
                    break;
                }

                level++;
            } while (level < 10);
            Console.WriteLine($"최종 Level : {level}");

            // 실습 : exp가 1을 넘어 레벨업을 할 때까지 계속 추가 경험치를 입력하도록 하는 코드
            exp = 0.0f;
            float tempFloat;

            while (1.0f > exp)
            {
                Console.WriteLine($"현재 경험치 : {exp}");
                Console.Write("추가할 경험치 : ");
                temp = Console.ReadLine();
                float.TryParse(temp, out tempFloat);

                exp += tempFloat;
            }
            Console.WriteLine("레벨업!");
        }
    }
}
