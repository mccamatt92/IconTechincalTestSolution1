namespace Solution_1.Model;

public record ApiResponse
{
    public List<UserResponseModel> Data { get; set; }
    public int Total { get; set; }
    public int PerPage { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public object Support { get; set; }
}
