using System;

namespace Daspro_Kelas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Adventure Game");
            Console.WriteLine("What is your name?");
            Novice newPlayer = new Novice();
            newPlayer.Name = Console.ReadLine();
            Console.WriteLine($"Hi {newPlayer.Name}, ready for new adventure?[y/n]");
            string bReady = Console.ReadLine();

            if (bReady == "y") {
                Console.WriteLine($"{newPlayer.Name} is entering the world");

                Enemy firstEnemy = new Enemy("Butterfly");
                Console.WriteLine($"{newPlayer.Name} is encountering {firstEnemy.Name}");
                Console.WriteLine($"{firstEnemy.Name} is attacking you...");
                Console.WriteLine("Choose your action : ");
                Console.WriteLine("1. Single Attack");
                Console.WriteLine("2. Swing Attack");
                Console.WriteLine("3. Defend");
                Console.WriteLine("4. Run Away");

                while (!newPlayer.IsDead && !firstEnemy.IsDead) {
                    string playerAction = Console.ReadLine();

                    switch (playerAction) {
                        case "1":
                            Console.WriteLine($"{newPlayer.Name} id doing Single Attack");
                            firstEnemy.GetHit(newPlayer.AttackPower);
                            newPlayer.Exp += 0.3f;
                            firstEnemy.Attack();
                            newPlayer.GetHit(firstEnemy.AttackPower);
                            Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstEnemy.Health}");
                            break;
                        case "2":
                            newPlayer.Swing();
                            newPlayer.Exp += 0.9f;
                            firstEnemy.GetHit(newPlayer.AttackPower);
                            Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstEnemy.Health}");
                            break;
                        case "3":
                            newPlayer.Rest();
                            Console.WriteLine("Energy is being restored...");
                            firstEnemy.Attack();
                            newPlayer.GetHit(firstEnemy.AttackPower);
                            break;
                        case "4":
                            Console.WriteLine(newPlayer.Name + "attemp to run away...");
                            break;
                    }
                }

                Console.WriteLine(newPlayer.Name + " get " + newPlayer.Exp + " experiences");
            } else {
                Console.WriteLine("Goodbye...");
                Console.Read();
            }
        }
    }

    class Novice
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Energy { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead { get; set; }
        public float Exp { get; set; }

        Random rnd = new Random();

        public Novice()
        {
            Health = 100;
            Energy = 0;
            AttackPower = 1;
            IsDead = false;
            Exp = 0f;
            Name = "Newbie";
        }

        public void Swing()
        {
            if (Energy > 0) {
                Console.WriteLine("SWING ATTACK!!!");
                AttackPower += rnd.Next(3, 11);
                Energy--;
            } else {
                Console.WriteLine("You're run out of energy");
            }
        }

        public void GetHit(int hitValue)
        {
            Console.WriteLine(Name + " get hit by " + hitValue);
            Health -= hitValue;

            if (Health <= 0) {
                Health = 0;
                Die();
            }
        }

        public void Rest()
        {
            Energy++;
            AttackPower = 1;
        }

        private void Die()
        {
            Console.WriteLine(Name + " is dead, Game Over");
            IsDead = true;
        }
    }

    class Enemy
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead { get; set; }
        Random rnd = new Random();

        public Enemy(string name)
        {
            Health = 25;
            Name = name;
        }

        public void Attack()
        {
            AttackPower += rnd.Next(1, 6);
        }

        public void GetHit(int hitValue)
        {
            Console.WriteLine(Name + " get hit by " + hitValue);
            Health -= hitValue;

            if (Health <= 0) {
                Health = 0;
                Die();
            }
        }

        private void Die()
        {
            Console.WriteLine(Name + "is dead");
            IsDead = true;
        } 

    }
}
