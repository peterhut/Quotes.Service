namespace QuoteService
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quote
    {
        public Quote(){
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string Attribution { get; set; }
    }
}
