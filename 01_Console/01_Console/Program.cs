using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //플레이어 만들기
            Human human = new Human("사람"); //휴먼객체 생성
            Orc orc = new Orc("오크"); //오크 객체 생성

            human.TestPrintStatus(); //휴먼 상태 출력
            orc.TestPrintStatus(); //오크 상태 출력


            Console.WriteLine("\n\n---------------------------전투시작-------------------------\n\n");


            while (true) // 무한 루프
            {
                int selection; 
                do
                {
                    Console.Write("행동을 선택하세요 1)공격 2)스킬 3)방어 : ");
                    string temp = Console.ReadLine();
                    int.TryParse(temp, out selection);

                } while (selection != 1 && selection !=2 && selection !=3); //while (selection <1 || selection >3);

                switch (selection){
                    case 1:
                        human.Attack(orc);
                        break;
                    case 2:
                        human.Skill(orc);
                        break;
                    case 3:
                        human.Defense();
                        break;
                    default:
                        break;
                }

                orc.TestPrintStatus();
                if (orc.IsDead) //오크가 죽으면
                {
                    Console.WriteLine($"{human.Name} 승리");
                    break; //무한루프종료
                }
                //오크 공격 시작
                orc.Attack(human); //오크 공격
                human.TestPrintStatus();
                if (human.IsDead) //휴먼이 죽으면
                {
                    Console.WriteLine($"{orc.Name} 승리");
                    break; //무한루프종료
                }
            }
            Console.ReadKey();                // 키 입력 대기

            //Main함수 끝
        }


    }
}
