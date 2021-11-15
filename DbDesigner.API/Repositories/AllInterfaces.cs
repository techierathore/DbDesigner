
namespace DbDesigner.API.Repositories
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        AppUser GetLoginUser(string aLoginEmail, string aPassword);
        AppUser GetUserByEmail(string loginEmail);
        AppUser GetUserByMobile(string aMobileNo);
    }
    public interface IUserLoginRepository : IGenericRepository<UserLogin>
    {
        UserLogin GetUserByToken(long aUserId, string aToken);
    }
    public interface IDbDesignRepository : IGenericRepository<DbDesign>
    { }
}
