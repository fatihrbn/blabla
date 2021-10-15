using System;
using System.Collections.Generic;

namespace Adventure_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            MulaiMain();
        }
        static bool MulaiMain()
        {
            List<string> enemyName = new List<string> {
                "Butterfly",
                "Dragonfly",
                "Worker Bee",
                "Queen Bee[BOSS]",
            };
            Console.WriteLine("Welcome to My Adventure Game");
            Console.WriteLine("What is your name?");
            Knight newPlayer = new Knight();
            newPlayer.Name = Console.ReadLine();

            for (int i = 0; i < 3; i++) {
                Console.WriteLine($"{newPlayer.Name} is entering the world");
                Enemy firstEnemy = new Enemy(enemyName[i]);
                Console.WriteLine($"{newPlayer.Name} is encountering {firstEnemy.Name}");
                Console.WriteLine($"{firstEnemy.Name} is attacking you...");
                Console.WriteLine("Choose your action : ");
                Console.WriteLine("1. Single Attack");
                Console.WriteLine("2. Skill");
                Console.WriteLine("3. Defend");
                Console.WriteLine("4. Run Away");
                Console.WriteLine($"Your Energy : {newPlayer.Energy}");

                while (!newPlayer.IsDead && !firstEnemy.IsDead) {
                    string playerAction = Console.ReadLine();

                    switch (playerAction) {
                        case "1":
                            newPlayer.singleAttack();
                            Console.WriteLine($"{newPlayer.Name} is doing Single Attack");
                            firstEnemy.GetHit(newPlayer.AttackPower);
                            newPlayer.Exp += 0.3f;

                            if (firstEnemy.Stun > 0) {
                                firstEnemy.Stun--;
                                Console.WriteLine($"{firstEnemy.Name} can't attack for total: {firstEnemy.Stun} turn");
                            } else {
                                firstEnemy.Attack(1 + i, 6 + i);
                                newPlayer.GetHit(firstEnemy.AttackPower);
                            }
                            Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstEnemy.Health}");
                            Console.WriteLine($"Your Energy : {newPlayer.Energy}");
                            break;
                        case "2":
                            if (newPlayer.Energy > 0) {
                                newPlayer.Skill();
                                firstEnemy.Stun += 2;
                                newPlayer.Exp += 0.9f;
                                Console.WriteLine($"{firstEnemy.Name} can't attack for total: {firstEnemy.Stun} turn");
                            } else {
                                newPlayer.Skill();
                                Console.WriteLine($"{newPlayer.Name} is doing Single Attack");
                                firstEnemy.GetHit(newPlayer.AttackPower);
                                newPlayer.Exp += 0.3f;
                                
                                if (firstEnemy.Stun > 0) {
                                    firstEnemy.Stun--;
                                    Console.WriteLine($"{firstEnemy.Name} can't attack for total: {firstEnemy.Stun} turn");
                                } else {
                                    firstEnemy.Attack(1 + i, 6 + i);
                                    newPlayer.GetHit(firstEnemy.AttackPower);
                                }
                            }
                            Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstEnemy.Health}");
                            Console.WriteLine($"Your Energy : {newPlayer.Energy}");
                            break;
                        case "3":
                            newPlayer.Rest();
                            Console.WriteLine("Energy is being restored...");
                            if (firstEnemy.Stun > 0) {
                                firstEnemy.Stun--;
                                Console.WriteLine($"{firstEnemy.Name} can't attack for total: {firstEnemy.Stun} turn");
                            } else {
                                firstEnemy.Attack(1 + i, 6 + i);
                                newPlayer.GetHit(firstEnemy.AttackPower);
                            }
                            Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstEnemy.Health}");
                            Console.WriteLine($"Your Energy : {newPlayer.Energy}");
                            break;
                        case "4":
                            Console.WriteLine(newPlayer.Name + " attemp to run away...");
                            break;
                    }
                }
                Console.WriteLine(newPlayer.Name + " get " + newPlayer.Exp + " experiences");

                if (newPlayer.IsDead == true) {
                    return false;
                }
            }
            Console.WriteLine($"{newPlayer.Name} is entering the world");
            Boss firstBoss = new Boss(enemyName[3]);
            Console.WriteLine($"{newPlayer.Name} is encountering {firstBoss.Name}");
            Console.WriteLine($"{firstBoss.Name} is attacking you...");
            Console.WriteLine("Choose your action : ");
            Console.WriteLine("1. Single Attack");
            Console.WriteLine("2. Skill");
            Console.WriteLine("3. Defend");
            Console.WriteLine("4. Run Away");
            Console.WriteLine($"Your Energy : {newPlayer.Energy}");

            while (!newPlayer.IsDead && !firstBoss.IsDead) {
                string playerAction = Console.ReadLine();

                switch (playerAction) {
                    case "1":
                        Console.WriteLine($"{newPlayer.Name} is doing Single Attack");
                        newPlayer.singleAttack();
                        firstBoss.GetHit(newPlayer.AttackPower);
                        newPlayer.Exp += 0.3f;
                        if (firstBoss.Stun > 0) {
                            firstBoss.Stun--;
                            Console.WriteLine($"{firstBoss.Name} can't attack for total: {firstBoss.Stun} turn");
                        } else {
                            firstBoss.Attack(5, 16, newPlayer.Health);
                            newPlayer.GetHit(firstBoss.AttackPower);
                        }
                        Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstBoss.Health}");
                        Console.WriteLine($"Your Energy : {newPlayer.Energy}");
                        break;
                    case "2":
                        if (newPlayer.Energy > 0) {
                            firstBoss.Stun += 2;
                            newPlayer.Skill();
                            newPlayer.Exp += 0.9f;
                            Console.WriteLine($"{firstBoss.Name} can't attack for total: {firstBoss.Stun} turn");
                        } else {
                            newPlayer.Skill();
                            Console.WriteLine($"{newPlayer.Name} is doing Single Attack");
                            firstBoss.GetHit(newPlayer.AttackPower);
                            newPlayer.Exp += 0.3f;
                            
                            if (firstBoss.Stun > 0) {
                                firstBoss.Stun--;
                                Console.WriteLine($"{firstBoss.Name} can't attack for total: {firstBoss.Stun} turn");
                            } else {
                                firstBoss.Attack(5, 16, newPlayer.Health);
                                newPlayer.GetHit(firstBoss.AttackPower);
                            }
                        }
                        Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstBoss.Health}");
                        Console.WriteLine($"Your Energy : {newPlayer.Energy}");
                        break;
                    case "3":
                        newPlayer.Rest();
                        Console.WriteLine("Energy is being restored...");
                        if (firstBoss.Stun > 0) {
                            firstBoss.Stun--;
                            Console.WriteLine($"{firstBoss.Name} can't attack for total: {firstBoss.Stun} turn");
                        } else {
                            firstBoss.Attack(5, 16, newPlayer.Health);
                            newPlayer.GetHit(firstBoss.AttackPower);
                        }
                        Console.WriteLine($"Player Health : {newPlayer.Health} | Enemy Health : {firstBoss.Health}");
                        Console.WriteLine($"Your Energy : {newPlayer.Energy}");
                        break;
                    case "4":
                        Console.WriteLine(newPlayer.Name + " attemp to run away...");
                        break;
                }
            }
            Console.WriteLine(newPlayer.Name + " get " + newPlayer.Exp + " experiences");

            if (newPlayer.IsDead == true) {
                return false;
            }
            return false;
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

        public void singleAttack()
        {
            AttackPower = 1;
        }

        public void Swing()
        {
            if (Energy > 0) {
                Console.WriteLine("SWING ATTACK!!!");
                AttackPower = rnd.Next(3, 11);
                Energy--;
            } else {
                Console.WriteLine("You're run out of energy");
                AttackPower = 1;
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

    class Knight:Novice
    {
        public void Skill()
        {
            if (Energy > 0) {
                Console.WriteLine(Name + " use Bash Skill!!");
                Console.WriteLine("Stun Enemy can't attack for 2 turn");
                Energy--;
            } else {
                Console.WriteLine("You're run out of energy");
            }
           
        }
    }

    class Enemy
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead { get; set; }
        public int Stun { get; set; }

        Random rnd = new Random();

        public Enemy(string name)
        {
            Health = 25;
            Name = name;
            Stun = 0;
        }

        public void Attack(int min, int max)
        {
            AttackPower = rnd.Next(min, max);
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

    class Boss
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead { get; set; }
        public int Stun { get; set; }

        Random rnd = new Random();

        public Boss(string name)
        {
            Health = 1000;
            Name = name;
            Stun = 0;
        }

        public void Attack(int min, int max, int playerHealth)
        {
            int chances = rnd.Next(1, 11);

            if (chances == 1) {
                Skill(playerHealth);
            } else {
                AttackPower = rnd.Next(min, max);
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

        private void Die()
        {
            Console.WriteLine(Name + "is dead");
            IsDead = true;
        } 

        public void Skill(int playerHealth)
        {
            int chances = rnd.Next(1, 11);

            if (chances == 1) {
                AttackPower = playerHealth;
            } else {
                AttackPower = playerHealth / 3;
            }
            Console.WriteLine("Boss casting special skill!");
        }
    }
}
