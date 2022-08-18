using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// namespcae : 이름이 겹치는 것을 방지하기 위해 구분지어 놓는 용도
namespace _01_Console
{

    // 접근제한자(Access Modifier)
    // public : 누구든지 접근가능
    // private : 자기 자신만 접근가능
    // protected : 자기 자신과 상속받은 자식들만 접근가능
    // internal : 같은 어셈블리안에서는 public 다른 어셈블리면 private

    // 클레스 : 특정한 오브젝트를 표현하기 위해 그 오브젝트가 가져야 할 데이터와 기능을 모아 놓은 것
    public class Character
    {
        // 맴버 변수 -> 데이터



        private string name;
        private int hp=100;
        private int maxHp = 100;
        private int strenth = 10;
        private int dexterity = 5;
        private int intellegence = 7;

        // 배열
        //int[] intArray;
        //intArray = new int[5]; //5개 가질수있도록 할당

        string[] nameArray = { "너굴맨", "개굴맨", "ㅁㅁㅁ", "ㄷㄷㄷ", "ㅋㅋㅋ" }; //nameArray에 기본값 설정 (선언과 동시에 할당)
        public Character()
        {
            // 실습
            // 1. 이름이 nameArray에 들어있는 것 중 하나로 랜덤하게 선택된다.
            // 2. maxHp는 100~200로 랜덤하게 선택
            // 3. hp는 maxhp와 같다.
            // 4. str,dex,int는 1~20 사이로 랜덤하게 정해진다.
            // 5. TestPrintStatus 함수를 이욯해서 최종 상태를 출력한다.
            Random random = new Random();
            name = nameArray[random.Next() % 5];
            GenerateStatus();
        }
        public Character(string name)
        {
            this.name = name;

            GenerateStatus();

        }

        public int HP //프로퍼티 = 속성
        {
            get { return hp; }
            set 
            { 
                hp = value;
                if( hp > maxHp)
                {
                    hp = maxHp;
                }
                if(hp <= 0)
                {

                }
            }
        }

        private void GenerateStatus()
        {
            Random random = new Random();
            maxHp = random.Next() % 101 + 100; // maxHp = rand.Next(100, 201); 100~200 사이
            hp = maxHp;
            strenth = random.Next() % 20 + 1; //strenth = rand.Next(20)+1; 0~19 사이 + 1
            dexterity = random.Next() % 20 + 1;
            intellegence = random.Next() % 20 + 1;
        }

        // 맴버 함수 -> 기능
        public void Attack(Character target)
        {
            int damage = strenth;
            Console.WriteLine($"{name}이 {target.name}에게 공격을 합니다.(공격력 : {damage})");
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");
        }

        public void TestPrintStatus()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"  이름\t: {name}");
            Console.WriteLine($"  HP\t: {hp} / {maxHp}");
            Console.WriteLine($"  STR\t: {strenth}");
            Console.WriteLine($"  DEX\t: {dexterity}");
            Console.WriteLine($"  INT\t: {intellegence}");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━┛");
        }
    }
}
