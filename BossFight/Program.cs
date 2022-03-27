class program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string Player = "Темный колдун";
        int playerHealth = 700;
        string sphereOfDarkness = "Сфера тьмы";
        int sphereOfDarknessDamage = 150;
        string darkDoppelganger = "Темный двойник";
        int darkDoppelgangerHealth = 0;
        int healthDividerDoppelganger = 2;
        int darkDoppelgangerDamage = 100;
        int darkDoppelgangerAdditionalDamage = 0;
        bool darkDopelgangerIsCalled = false;
        string prayerOfAbaddon = "Молитва Абаддон";
        int prayerOfAbaddonDamage = 190;
        bool isPrayerOfAbaddon = false;
        string crystalOfNothingness = "Кристалл небытия";
        int crystalOfNothingnessHealing = 220;
        int choiceCastSphereOfDarkness;
        int minimumNumberProbabilityCastSphereOfDarkness = 1;
        int maximumNumberProbabilityCastSphereOfDarkness = 11;
        string bossName = "Такхазис";
        int bossHealth = 1200;
        int rageTresholdBossHealth = 700;
        int minimumBossDamage = 70;
        int maximumBossDamage = 200;
        int bossDamage;
        int bossCriticalDamage;
        int criticalBossDamageMultiplier = 2;
        int criticalBossDamageChoice;
        int minimumNumberOfCriticalBossDamageProbability = 1;
        int maximumNumberOfCriticalBossDamageProbability = 11;
        int playerInput;

        Console.WriteLine($"Добро пожаловать на битву с боссом!\nВам предстоит сразиться против божества {bossName} в облике " +
            $"пятиглавого дракона!\nВыживет только один, ибо так предначертано...");
        Console.WriteLine($"{bossName} крайне сильный противник, когда здоровье её будет на исходе, она приходит в ярость и может с некоторой вероятностью" +
            $"нанести двукратный урон.");
        Console.WriteLine($"Прежде чем начинать бой, давайте ознакомимся с вашими способностями:\n" +
            $"вы - {Player}. \nДабы обрести великую силу, вы ступили на путь черного темного, поклоняясь и черпая силу у богов тьмы.\n" +
            $"Ваши умения:\n1.{sphereOfDarkness} - выпускает во врага сферу, нанося {sphereOfDarknessDamage} урона\n" +
            $"2.{prayerOfAbaddon} - Помолившись Абаддон, всадник апокалипсиса обрушит на врага свой гнев, нанося {prayerOfAbaddonDamage} урона, а также дает возможность\n" +
            $"использовать способность - {darkDoppelganger}\n" +
            $"3.{darkDoppelganger} - С помощью силы Абаддон призывает своего двойника из царства тьмы, который имее 50% здоровья от текущего здоровья призывающего и наносит {darkDoppelgangerDamage}" +
            $" урона противнику. Принимает на себя следующую атаку противника.\nЕсли двойник погибает от атаки, то наносит дополнительно 100% урона от потерянного здоровья врагу, если двойник выживает, то" +
            $" отнимает 100% от оставшегося здоровья у призывателя\n" +
            $"4.{crystalOfNothingness} - заключает себя в кристалл и восстанавливает {crystalOfNothingnessHealing} здоровья. Имеет шанс 1:10 немедленно применить {sphereOfDarkness}");
        Console.WriteLine($"{Player}: {playerHealth} здоровья.\n{bossName}: {bossHealth} здоровья.");
        Console.WriteLine("Битва начинается!");

        while (playerHealth > 0 && bossHealth > 0)
        {
            playerInput = Convert.ToInt32(Console.ReadLine());

            switch (playerInput)
            {
                case 1:
                    bossHealth -= sphereOfDarknessDamage;
                    Console.WriteLine($"{Player} использует заклинание {sphereOfDarkness} и наносит {sphereOfDarknessDamage} урона.\n" + $"{bossName}: {bossHealth} здоровья");
                    break;
                case 2:
                    bossHealth -= prayerOfAbaddonDamage;
                    isPrayerOfAbaddon = true;
                    Console.WriteLine($"{Player} использует заклинание {prayerOfAbaddon} и наносит {prayerOfAbaddonDamage} урона. Аббадон даровала силы\n" +
                        $", заклинание {darkDoppelganger} можно применять!\n" +
                        $"{bossName}: {bossHealth} здоровья");
                    break;
                case 3:

                    if (isPrayerOfAbaddon == true)
                    {
                        darkDoppelgangerHealth = playerHealth / healthDividerDoppelganger;
                        darkDoppelgangerAdditionalDamage = darkDoppelgangerHealth;
                        darkDopelgangerIsCalled = true;
                        isPrayerOfAbaddon = false;
                        bossHealth -= darkDoppelgangerDamage;
                        Console.WriteLine($"{Player} призывает {darkDoppelganger}, он имеет {darkDoppelgangerHealth} здоровья. Наносит противнику {darkDoppelgangerDamage}\n" +
                            $"{bossName}: {bossHealth} здоровья");
                    }
                    else
                    {
                        Console.WriteLine("У вас не хватило сил для призыва! Враг атакует!");
                    }

                    break;
                case 4:
                    playerHealth += crystalOfNothingnessHealing;
                    Console.WriteLine($"{Player} использует заклинание {crystalOfNothingness} и восстанавливает {crystalOfNothingnessHealing} здоровья.\n" +
                        $"{Player}: {playerHealth} здоровья.");
                    choiceCastSphereOfDarkness = random.Next(minimumNumberProbabilityCastSphereOfDarkness, maximumNumberProbabilityCastSphereOfDarkness);

                    if (choiceCastSphereOfDarkness == minimumNumberProbabilityCastSphereOfDarkness)
                    {
                        bossHealth -= sphereOfDarknessDamage;
                        Console.WriteLine($"применяет заклинание {sphereOfDarkness} и наносит {sphereOfDarknessDamage} урона врагу. {bossName}: {bossHealth} здоровья");
                    }

                    break;
                default:
                    Console.WriteLine("Такого заклинания нет, враг атакует!");
                    break;
            }

            if (darkDopelgangerIsCalled == false && bossHealth >= rageTresholdBossHealth)
            {
                bossDamage = random.Next(minimumBossDamage, maximumBossDamage);
                playerHealth -= bossDamage;
                Console.WriteLine($"{bossName} атакует и наносит {bossDamage} урона.\n{Player}: {playerHealth} здоровья.");
            }
            else if (darkDopelgangerIsCalled == false && bossHealth <= rageTresholdBossHealth)
            {
                bossDamage = random.Next(minimumBossDamage, maximumBossDamage);
                criticalBossDamageChoice = random.Next(minimumNumberOfCriticalBossDamageProbability, maximumNumberOfCriticalBossDamageProbability);
                bossCriticalDamage = bossDamage * criticalBossDamageMultiplier;

                if (criticalBossDamageChoice == minimumNumberOfCriticalBossDamageProbability)
                {
                    playerHealth -= bossCriticalDamage;
                    Console.WriteLine($"{bossName} атакует и наносит {bossCriticalDamage} критического урона.\n{Player}: {playerHealth} здоровья.");
                }
                else
                {
                    playerHealth -= bossDamage;
                    Console.WriteLine($"{bossName} атакует и наносит {bossDamage} урона.\n{Player}: {playerHealth} здоровья.");
                }
            }
            else if (darkDopelgangerIsCalled == true && bossHealth >= rageTresholdBossHealth)
            {
                bossDamage = random.Next(minimumBossDamage, maximumBossDamage);
                darkDoppelgangerHealth -= bossDamage;
                Console.WriteLine($"{bossName} атакует и наносит {bossDamage} урона теневому двойнику.");

                if (darkDoppelgangerHealth <= 0)
                {
                    bossHealth -= darkDoppelgangerAdditionalDamage;
                    darkDopelgangerIsCalled = false;
                    Console.WriteLine($"{darkDoppelganger} погибает и наносит {darkDoppelgangerAdditionalDamage} дополнительного урона врагу");
                }
                else
                {
                    playerHealth -= darkDoppelgangerHealth;
                    darkDopelgangerIsCalled = false;
                    Console.WriteLine($"{darkDoppelganger} исчезает нанося своему хозяину {darkDoppelgangerHealth} урона");
                }
            }
            else if (darkDopelgangerIsCalled == true && bossHealth <= rageTresholdBossHealth)
            {
                bossDamage = random.Next(minimumBossDamage, maximumBossDamage);
                criticalBossDamageChoice = random.Next(minimumNumberOfCriticalBossDamageProbability, maximumNumberOfCriticalBossDamageProbability);
                bossCriticalDamage = bossDamage * criticalBossDamageMultiplier;

                if (criticalBossDamageChoice == minimumNumberOfCriticalBossDamageProbability)
                {
                    darkDoppelgangerHealth -= bossCriticalDamage;
                    Console.WriteLine($"{bossName} атакует и наносит {bossCriticalDamage} критического урона теневому двойнику.");

                    if (darkDoppelgangerHealth <= 0)
                    {
                        bossHealth -= darkDoppelgangerAdditionalDamage;
                        darkDopelgangerIsCalled = false;
                        Console.WriteLine($"{darkDoppelganger} погибает и наносит {darkDoppelgangerAdditionalDamage} дополнительного урона врагу");
                    }
                    else
                    {
                        playerHealth -= darkDoppelgangerHealth;
                        darkDopelgangerIsCalled = false;
                        Console.WriteLine($"{darkDoppelganger} исчезает нанося своему хозяину {darkDoppelgangerHealth} урона");
                    }

                }
                else
                {
                    darkDoppelgangerHealth -= bossDamage;
                    Console.WriteLine($"{bossName} атакует и наносит {bossDamage} урона теневому двойнику.");

                    if (darkDoppelgangerHealth <= 0)
                    {
                        bossHealth -= darkDoppelgangerAdditionalDamage;
                        darkDopelgangerIsCalled = false;
                        Console.WriteLine($"{darkDoppelganger} погибает и наносит {darkDoppelgangerAdditionalDamage} дополнительного урона врагу");
                    }
                    else
                    {
                        playerHealth -= darkDoppelgangerHealth;
                        darkDopelgangerIsCalled = false;
                        Console.WriteLine($"{darkDoppelganger} исчезает нанося своему хозяину {darkDoppelgangerHealth} урона");
                    }
                }
            }

        }
        if(playerHealth <= 0)
        {
            Console.WriteLine($"Вы погибли, победила {bossName}!");
        }
        else if(bossHealth <= 0)
        {
            Console.WriteLine($"{bossName} пала, вы победили!");
        }
    }
}