using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Labb2
{
    class Combat
    {
        public Combat(Player attacker, Enemy defender)
        {
            Console.WriteLine("\n========== COMBAT ==========");
            Console.WriteLine($"Player encounters {defender.Name}!");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey(true);

            while (attacker.Health > 0 && defender.Health > 0)
            {
                int attackerAttack = attacker.AttackDice.Throw();
                Console.WriteLine("\n--- Player attacks ---");
                Console.WriteLine($"Attack roll: {attacker.AttackDice} = {attackerAttack}");
                Console.ReadKey(true);

                int defenderDefence = defender.DefenceDice.Throw();
                Console.WriteLine($"{defender.Name} defence roll: {defender.DefenceDice} = {defenderDefence}");
                Console.ReadKey(true);

                defender.Health = defender.Health - Attack(attackerAttack, defenderDefence);
                Console.WriteLine($"Damage dealt: {Math.Max(0, attackerAttack - defenderDefence)}");
                Console.WriteLine($"{defender.Name} HP remaining: {defender.Health}");

                if (defender.Health <= 0)
                {
                    Console.WriteLine($"\n{defender.Name} has been defeated!");
                    break;
                }
                else
                {
                    Console.WriteLine("\nPress any key for the counterattack...");
                    Console.ReadKey(true);

                    int defenderAttack = defender.AttackDice.Throw();
                    Console.WriteLine($"\n--- {defender.Name} attacks ---");
                    Console.WriteLine($"Attack roll: {defender.AttackDice} = {defenderAttack}");
                    Console.ReadKey(true);

                    int attackerDefence = attacker.DefenceDice.Throw();
                    Console.WriteLine($"Player defence roll: {attacker.DefenceDice} = {attackerDefence}");
                    Console.ReadKey(true);

                    attacker.Health = attacker.Health - Attack(defenderAttack, attackerDefence);
                    Console.WriteLine($"Damage dealt: {Math.Max(0, defenderAttack - attackerDefence)}");
                    Console.WriteLine($"Player HP remaining: {attacker.Health}");
                }
            }

            Console.WriteLine("\n========== COMBAT ENDED ==========");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        public Combat(Enemy attacker, Player defender)
        {
            Console.WriteLine("\n========== COMBAT ==========");
            Console.WriteLine($"{attacker.Name} attacks the Player!");
            Console.WriteLine("Press any key to begin...");
            Console.ReadKey(true);

            while (attacker.Health > 0 && defender.Health > 0)
            {
                int attackerAttack = attacker.AttackDice.Throw();
                Console.WriteLine($"\n--- {attacker.Name} attacks ---");
                Console.WriteLine($"Attack roll: {attacker.AttackDice} = {attackerAttack}");
                Console.ReadKey(true);

                int defenderDefence = defender.DefenceDice.Throw();
                Console.WriteLine($"Player defence roll: {defender.DefenceDice} = {defenderDefence}");
                Console.ReadKey(true);

                defender.Health = defender.Health - Attack(attackerAttack, defenderDefence);
                Console.WriteLine($"Damage dealt: {Math.Max(0, attackerAttack - defenderDefence)}");
                Console.WriteLine($"Player HP remaining: {defender.Health}");

                if (defender.Health <= 0)
                {
                    Console.WriteLine("\nThe Player has been defeated!");
                    break;
                }
                else
                {
                    Console.WriteLine("\nPress any key for the counterattack...");
                    Console.ReadKey(true);

                    int defenderAttack = defender.AttackDice.Throw();
                    Console.WriteLine("\n--- Player attacks ---");
                    Console.WriteLine($"Attack roll: {defender.AttackDice} = {defenderAttack}");
                    Console.ReadKey(true);

                    int attackerDefence = attacker.DefenceDice.Throw();
                    Console.WriteLine($"{attacker.Name} defence roll: {attacker.DefenceDice} = {attackerDefence}");
                    Console.ReadKey(true);

                    attacker.Health = attacker.Health - Attack(defenderAttack, attackerDefence);
                    Console.WriteLine($"Damage dealt: {Math.Max(0, defenderAttack - attackerDefence)}");
                    Console.WriteLine($"{attacker.Name} HP remaining: {attacker.Health}");
                }
            }

            Console.WriteLine("\n========== COMBAT ENDED ==========");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        static int Attack(int attackDice, int defenceDice)
        {
            if (attackDice - defenceDice > 0)
            {
                return attackDice - defenceDice;
            }

            return 0;
        }
    }
}

