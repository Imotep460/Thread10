namespace Thread10
{
    public class Money
    {
        public int Value { get; set; }
        public string Owner { get; set; }
        public string Zip { get; set; }

        public Money(int v, string o, string z)
        {
            Value = v;
            Owner = o;
            Zip = z;
        }
    }
}
