namespace JWTAuthProject
{
    public interface IServices
    {
           string GenerateToken(int userId, string username, string role);
     
    }
}
