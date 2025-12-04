namespace RPG_Game
{
    public abstract class Character
    {
        private string _name;
        private int _health;
        private int _maxHealth;
        private int _strenght;
       /// private int _agility;
       /// private int _intelligence;
       /// private int _luck;

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public int Health
        {
            get => _health;
            protected set => _health = Math.Max(0, Math.Min(value, _maxHealth));
        }

        public int MaxHealth
        {
            get => _maxHealth;
            protected set => _maxHealth = value;
        }

        public int Strenght
        {
            get => _strenght; 
            protected set => _strenght = value;
        }

        public bool IsAlive => _health > 0;

        protected Character(string name, int health, int strenght) 
        {
            _name = name;
            _health = health;
            _maxHealth = health;
            _strenght = strenght;
        }

        public abstract void Attack(Character target);

        public virtual void TakeDamage(int damage)
        { 
            Health -= damage;
            Console.WriteLine($"{Name} отримав {damage} пошкоджень! (НР: {Health}/{MaxHealth})");

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} загинув!");
            }
        }

        public void Heal(int amount)
        {
            var oldHealth = Health;
            Health += amount;
            Console.WriteLine($"{Name} відновив {Health - oldHealth} НР! (НР: {Health}/{MaxHealth})");
        }
    }
}
