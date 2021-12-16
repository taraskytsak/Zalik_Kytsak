using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp11
{
    abstract class Actor
    {
        protected string role; // роль
        protected string suit; // костюм
        public abstract void Create(string suit);
    }
    class MainActor : Actor
    {
        public MainActor()
        {
            role = "Main Role";
        }
        public override void Create(string suit)
        {
            this.suit = suit;
            Console.WriteLine("Вибрано головного актора з костюмом {0}", suit);
        }
    }
    class MassActor : Actor
    {
        public MassActor()
        {
            role = "Secondary Role";
        }
        public override void Create(string suit)
        {
            this.suit = suit;
            Console.WriteLine("Вибрано актора масовки з костюмом {0}", suit);
        }
    }
    class MainActorFactory
    {
        private Hashtable actors = new Hashtable();

        public MainActor GetMainActor(string suit)
        {
            string key = suit.Replace(" ", "");
            MainActor actor = actors[key] as MainActor;


            if (actor == null)
            {
                actor = new MainActor();
                actor.Create(suit);
                actors.Add(key, actor);

            }
            return actor;
        }
    }
    class MassActorFactory
    {
        private Hashtable actors = new Hashtable();

        public MassActor GetMassActor(string suit)
        {
            string key = suit.Replace(" ", "");
            MassActor actor = actors[key] as MassActor;


            if (actor == null)
            {
                actor = new MassActor();
                actor.Create(suit);
                actors.Add(key, actor);

            }
            return actor;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MainActorFactory factory = new MainActorFactory();
            factory.GetMainActor("Suit number 1");
            factory.GetMainActor("Suit number 2");
            factory.GetMainActor("Suit number 3");

            MassActorFactory factory1 = new MassActorFactory();
            factory1.GetMassActor("Suit number 5");
            factory1.GetMassActor("Suit number 7");
            factory1.GetMassActor("Suit number 8");
        }
    }
}
