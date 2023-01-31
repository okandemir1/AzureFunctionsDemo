namespace ToDoItems.Models
{
    public class ToDoItem
    {
        //id küçük harf ile başlamak zorunda Id yazmış olsaydım cosmodb id'yi otomatik eklemiş olacaktı
        //iki tane id gibi oluyor bu durumda küçük harfli yaptım ki ben sana id sağlıyorum bunu sen kendi id'in olarak kullan demiş olduk
        public Guid id { get; set; } = Guid.NewGuid();
        public string ItemType { get; set; } = "Mission";
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.Now.AddHours(4);

        public override string ToString()
        {
            return $"Id:{id}, ItemType:{ItemType}, Name:{Name}";
        }
    }
}