using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._12
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstSpell;
            int healingSpell;
            int secondSpell;
            int thirdSpell;
            int armorSpell;
            int manaSpell;
            int spellCounter = 0;
            int countForSecondSpell = 1;
            int countForThirdSpell = 2;
            int spellNumber = 0;
            int myHeal = 650;
            int maxMyHeal = 650;
            int mana = 1000;
            int minDamageFirstSpell = 100;
            int maxDamageFirstSpell = 150;
            int minusManaFirstSpell = 200;
            int minHealByHealingSpell = 110;
            int maxHealByHealingSpell = 200;
            int minusManaHealingsSpell = 30;
            int minDamageBySecondSpell = 200;
            int maxDamageBySecondSpell = 250;
            int minusManaBySecondSpell = 250;
            int minDamageByThirdSpell = 250;
            int maxDamageByThirdSpell = 300;
            int minusManaByThirdSpell = 270;
            int maxHPByArmorSpell = 150;
            int minusManaByArmorSpell = 120;
            int minManaByManaSpell = 500;
            int maxManaByManaSpell = 750;
            int minDamageByBoss = 100;
            int maxDamageByBoss = 150;
            int damageByBoss;
            int bossHeal = 1000;
            bool isSomeLive = true;
            int HPForDeath = 0;
            Random random = new Random();
            Console.WriteLine("1.Локтарг - шар тьмы : урон 100 - 150 единиц хп. Затраты маны 200 единиц." +
                "\n2.Исцеляющая тьма : исцелениe мага 110-200 eдиниц хп. Затраты маны 30 единиц. " +
                "\n3.Темное пламя : урон 200 - 250 единиц хп. Затраты маны 250 единиц. (доступно после использования одного заклинания).  " +
                "\n4.Темный приговор : урон 250 - 300 единиц хп. Затраты маны 270 единиц. (доступно после использования двух заклинаний). " +
                "\n5.Щит тьмы : доп 150 единиц хп. Затраты маны 120 единиц." +
                "\n6.Ритуал теней : восполняет от 500 до 750 единиц маны.");

            while (isSomeLive)
            {
                Console.WriteLine($"Твои жизни: {myHeal} и мана {mana} \nЖизни босса: {bossHeal}");

                if (myHeal <= HPForDeath)
                {
                    isSomeLive = false;
                    Console.WriteLine("Смерть пришла за тобой");
                }

                if (bossHeal <= HPForDeath)
                {
                    isSomeLive = false;
                    Console.WriteLine("Смерть сегодня обошла тебя стороной");
                }

                    Console.WriteLine("Выберите вариант");
                    spellNumber = int.Parse(Console.ReadLine());

                switch (spellNumber) 
                {
                    case 1:

                        if (mana >= minusManaFirstSpell)
                        {
                            spellCounter++;
                            firstSpell = random.Next(minDamageFirstSpell, maxDamageFirstSpell);
                            bossHeal -= firstSpell;
                            mana -= minusManaFirstSpell;
                        }
                        else
                        {
                            Console.WriteLine("Нужно больше маны");
                        }
                        break;
                    case 2:

                        if (myHeal != maxMyHeal)
                        {

                            if (mana >= minusManaHealingsSpell)
                            {
                                spellCounter++; 
                                healingSpell = random.Next(minHealByHealingSpell, maxHealByHealingSpell);
                                myHeal += healingSpell;
                                mana -= minusManaHealingsSpell;
                            }
                            else
                            {
                                Console.WriteLine("Нужно больше маны");
                            }
                        }
                        else
                        {
                            Console.WriteLine("У тебя уже макс единиц хп");
                            Console.WriteLine("Выберите вариант");
                            spellNumber = int.Parse(Console.ReadLine());
                        }
                        break;
                    case 3:

                        if(spellCounter >= countForSecondSpell)
                        {

                            if (mana >= minusManaBySecondSpell)
                            {
                                secondSpell = random.Next(minDamageBySecondSpell, maxDamageBySecondSpell);
                                bossHeal -= secondSpell;
                                mana -= minusManaBySecondSpell;
                            }
                            else
                            {
                                Console.WriteLine("Нужно больше маны");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Я же сказал, ЗАКРЫТО!"); 
                            Console.WriteLine("Выберите вариант");
                            spellNumber = int.Parse(Console.ReadLine());
                        }
                        break;
                    case 4:

                        if (spellCounter >= countForThirdSpell)
                        {

                            if (mana >= minusManaByThirdSpell)
                            {
                                thirdSpell = random.Next(minDamageByThirdSpell, maxDamageByThirdSpell);
                                bossHeal -= thirdSpell;
                                mana -= minusManaByThirdSpell;
                            }
                            else
                            {
                                Console.WriteLine("Нужно больше маны");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Я же сказал, ЗАКРЫТО!");
                            Console.WriteLine("Выберите вариант");
                            spellNumber = int.Parse(Console.ReadLine());
                        }
                        break;
                    case 5:

                        if(mana >= minusManaByArmorSpell)
                        {
                            spellCounter++;
                            armorSpell = random.Next(maxHPByArmorSpell,maxHPByArmorSpell);
                            myHeal += armorSpell;
                            mana -= minusManaByArmorSpell;
                        }
                        else
                        {
                            Console.WriteLine("Нужно больше маны");
                        }
                        break;
                    case 6:
                        manaSpell = random.Next(minManaByManaSpell, maxManaByManaSpell);
                        mana += manaSpell;
                        break;
                    default:
                        Console.WriteLine("Я же сказал, ЗАКРЫТО!");
                        Console.WriteLine("Выберите вариант");
                        spellNumber = int.Parse(Console.ReadLine());
                        break;
                }
                damageByBoss = random.Next(minDamageByBoss, maxDamageByBoss);
                myHeal -= damageByBoss;
            }
        }
    }
}
