namespace Player_Potion_Making
{
    public class OrderPotion
    {
        public int id;
        public int quantity;

        public OrderPotion()
        {
            id = 1;
            quantity = 1;
        }

        public OrderPotion(int id, int quantity)
        {
            this.id = id;
            this.quantity = quantity;
        }
    }
}