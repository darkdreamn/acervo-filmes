namespace acervo_filmes
{
    public abstract class CollectionDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public Genders Gender { get; set; }
        public bool Deleted { get; set; }

        public CollectionDetails(int id, string name, string description, string year, Genders gender)
        {
            Id = id;
            Name = name;
            Description = description;
            Year = year;
            Gender = gender;
            Deleted = false;
        }
    }
}