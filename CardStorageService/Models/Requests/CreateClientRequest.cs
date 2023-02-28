namespace CardStorageService.Models.Requests
{
    // для добавления
    public class CreateClientRequest
    {
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Patronymic { get; set; }
    }
}
