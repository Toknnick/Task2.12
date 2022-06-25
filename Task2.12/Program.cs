using System;

namespace Task2._12
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstSpell = 0;
            int secondSpell = 0;
            int thirdSpell = 0;
            int armorSpell = 0;
            int manaSpell = 0;
            int spellCounter = 0;
            int countForSecondSpell = 1;
            int countForThirdSpell = 2;
            int spellNumber = 0;
            int heroHeal = 650;
            int maxHeroHeal = 650;
            int mana = 1000;
            int minDamageFirstSpell = 100;
            int maxDamageFirstSpell = 150;
            int priceFirstSpell = 200;
            int minHealByHealingSpell = 110;
            int maxHealByHealingSpell = 200;
            int priceManaHealingsSpell = 30;
            int minDamageBySecondSpell = 200;
            int maxDamageBySecondSpell = 250;
            int priceManaBySecondSpell = 250;
            int minDamageByThirdSpell = 250;
            int maxDamageByThirdSpell = 300;
            int priceManaByThirdSpell = 270;
            int maxHPByArmorSpell = 150;
            int priceManaByArmorSpell = 120;
            int minManaByManaSpell = 500;
            int maxManaByManaSpell = 750;
            int minDamageByBoss = 100;
            int maxDamageByBoss = 150;
            int damageByBoss;
            int bossHeal = 1000;
            bool isSomeLive = true;
            bool isUsedFirstSpell = false;
            Random random = new Random();
            firstSpell = random.Next(minDamageFirstSpell, maxDamageFirstSpell);
            int percentDamageByFirstSpell = (int)Math.Round((double)(firstSpell * maxDamageFirstSpell / 100));
            Console.WriteLine($"1.Локтарг - шар тьмы : урон {minDamageFirstSpell} - {maxDamageFirstSpell} единиц хп. Затраты маны {priceFirstSpell} единиц." +
                $"\n2.Темное пламя : урон {minDamageBySecondSpell} - {maxDamageBySecondSpell} единиц хп. Затраты маны {priceManaBySecondSpell} единиц. (доступно после использования одного заклинания).  " +
                $"\n3.Темный приговор : урон {minDamageByThirdSpell} - {maxDamageByThirdSpell} единиц хп. Затраты маны {priceManaByThirdSpell} единиц. (доступно после использования двух заклинаний). " +
                $"\n4.Щит тьмы : доп {maxHPByArmorSpell} единиц хп. Затраты маны {priceManaByArmorSpell} единиц. После использования Локтарга увеличивает доп хп на {percentDamageByFirstSpell} %" +
                $"\n5.Ритуал теней : восполняет от {minManaByManaSpell} до {maxManaByManaSpell} единиц маны.");

            while (isSomeLive)
            {
                Console.WriteLine($"Твои жизни: {heroHeal} и мана {mana} \nЖизни босса: {bossHeal}");

                if (heroHeal <= 0)
                {
                    isSomeLive = false;
                    Console.WriteLine("Смерть пришла за тобой");
                }

                if (bossHeal <= 0)
                {
                    isSomeLive = false;
                    Console.WriteLine("Смерть сегодня обошла тебя стороной");
                }

                Console.WriteLine("Выберите вариант");
                spellNumber = int.Parse(Console.ReadLine());

                switch (spellNumber)
                {
                    case 1:

                        if (mana >= priceFirstSpell)
                        {
                            isUsedFirstSpell = true;
                            spellCounter++;
                            bossHeal -= firstSpell;
                            mana -= priceFirstSpell;
                        }
                        else
                        {
                            Console.WriteLine("Нужно больше маны");
                        }
                        break;
                    case 2:

                        if (spellCounter >= countForSecondSpell)
                        {

                            if (mana >= priceManaBySecondSpell)
                            {
                                secondSpell = random.Next(minDamageBySecondSpell, maxDamageBySecondSpell);
                                bossHeal -= secondSpell;
                                mana -= priceManaBySecondSpell;
                            }
                            else
                            {
                                Console.WriteLine("Нужно больше маны");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Я же сказал, ЗАКРЫТО!");
                        }
                        break;
                    case 3:

                        if (spellCounter >= countForThirdSpell)
                        {

                            if (mana >= priceManaByThirdSpell)
                            {
                                thirdSpell = random.Next(minDamageByThirdSpell, maxDamageByThirdSpell);
                                bossHeal -= thirdSpell;
                                mana -= priceManaByThirdSpell;
                            }
                            else
                            {
                                Console.WriteLine("Нужно больше маны");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Я же сказал, ЗАКРЫТО!");
                        }
                        break;
                    case 4:

                        if (mana >= priceManaByArmorSpell)
                        {
                            spellCounter++;
                            armorSpell = random.Next(maxHPByArmorSpell, maxHPByArmorSpell);

                            if(isUsedFirstSpell == true)
                            {
                                armorSpell += percentDamageByFirstSpell;
                                heroHeal += armorSpell;
                                mana -= priceManaByArmorSpell;
                                isUsedFirstSpell = false;
                            }
                            else
                            {
                                heroHeal += armorSpell;
                                mana -= priceManaByArmorSpell;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Нужно больше маны");
                        }
                        break;
                    case 5:
                        manaSpell = random.Next(minManaByManaSpell, maxManaByManaSpell);
                        mana += manaSpell;
                        break;
                    default:
                        Console.WriteLine("Я же сказал, ЗАКРЫТО!");
                        break;
                }
                damageByBoss = random.Next(minDamageByBoss, maxDamageByBoss);
                heroHeal -= damageByBoss;
            }
        }
    }
}

