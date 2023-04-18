

namespace ClientsBlazor.Shared
{
    public  class Klient
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty; //string.empty = column může být null.  Zatím pro všechna null.  
        public string SongName { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public int Orders { get; set; }

    }
}
