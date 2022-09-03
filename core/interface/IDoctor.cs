public interface IDoctor
{
    bool AddDoctor(VmDoctor doc);

    List<VmDoctor> ShowDoctor();

    VmDoctor GetDoctorById(int id);

    bool EditDoctor(VmDoctor doc);

    bool DeleteDoctor(int id);
    int GetCount();
}
