using System.Text.Json.Serialization;

namespace lab4_1
{
    public enum BillingType
    {
        CreditCard,
        DebitCard,
        Cash, 
        None
    }

    public class Todo
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BillingType BT { get; set; }    
        public int priority { get; set; }
     }
}
