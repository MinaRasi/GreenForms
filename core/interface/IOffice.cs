public interface IOffice
{
    bool AddOffice(VmOffice off);
    List< VmOffice> ShowOffice();
    VmOffice GetOfficeById(int id);
    bool EditOffice(VmOffice off);
    bool DeleteOffice(int id);
}