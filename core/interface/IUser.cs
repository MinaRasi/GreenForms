public interface IUser
{
    bool adduser(VmUser u);
    bool Deluser(int id);
    List<VmUser> Showuser();
    VmUser GetId(int id);
    bool EditUser(VmUser m);
    bool ActiveUser(int id);
    int GetUserCount();
    
}