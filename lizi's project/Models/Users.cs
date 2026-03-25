namespace lizi_s_project.Models
{
    public class Users
    {
        public string Name { get; set; }

    public string Surname { get; set; }

    public int Id { get; set; }

    public Users(string name, string surname, int Id)
    {
        Name = name;
        Surname = surname;
        this.Id = Id;
    }
}


}
