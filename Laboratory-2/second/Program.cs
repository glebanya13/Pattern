public class Organization
{

    public int id
    {
        get;
        private set;
    }

    public string name
    {
        get;
        protected set;
    }

    public string shortName
    {
        get;
        protected set;
    }

    public string address
    {
        get;
        protected set;
    }

    public DateTime timeStamp
    {
        get;
        protected set;
    }

    public Organization()
    {
        name = string.Empty;
        shortName = string.Empty;
        address = string.Empty;
        timeStamp = DateTime.Now;
    }

    public Organization(Organization other)
    {
        this.id = other.id;
        this.name = other.name;
        this.shortName = other.shortName;
        this.address = other.address;
        this.timeStamp = other.timeStamp;
    }

    public Organization(string name, string shortName, string address)
    {
        this.name = name;
        this.shortName = shortName;
        this.address = address;
        timeStamp = DateTime.Now;
    }

    public void printInfo()
    {
        Console.WriteLine($"Organization '{name}' ({shortName}); {address}; {timeStamp}");
    }
}

public class University : Organization
{
    protected List<Faculty> faculties = new List<Faculty>();

    public University() : base()
    {

    }

    public University(University other) : base(other)
    {
        this.faculties = other.faculties;
    }

    public University(string name, string shortName, string address) : base(name, shortName, address)
    {

    }

    public int addFaculty(Faculty faculty)
    {
        try
        {
            faculties.Add(faculty);
            return faculties.Count;
        }
        catch
        {
            return -1;
        }
    }

    public bool delFaculty(int facultyId)
    {
        try
        {
            faculties.RemoveAt(facultyId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool updDepartment(Faculty faculty)
    {
        return false;
    }

    private bool verFaculty(int facultyId)
    {
        return faculties.Count > facultyId;
    }

    public List<Faculty> getFaculties()
    {
        return faculties;
    }

    public new void printInfo()
    {
        Console.WriteLine($"university '{name}' ({shortName}); {address}; {timeStamp}; {faculties.Count} faculties");
    }
}

public class Faculty : Organization
{
    protected List<Department> departments = new List<Department>();

    public Faculty() : base()
    {

    }

    public Faculty(Faculty other) : base(other)
    {
        this.departments = other.departments;
    }

    public Faculty(string name, string shortName, string address) : base(name, shortName, address)
    {

    }

    public int addDepartment(Department department)
    {
        try
        {
            departments.Add(department);
            return departments.Count;
        }
        catch
        {
            return -1;
        }
    }

    public bool delDepartment(int departmentId)
    {
        try
        {
            departments.RemoveAt(departmentId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool updDepartment(Department department)
    {
        return false;
    }

    private bool verDepartment(int departmentId)
    {
        return departments.Count > departmentId;
    }

    public List<Department> getDepartments()
    {
        return departments;
    }

    public new void printInfo()
    {
        Console.WriteLine($"faculty '{name}' ({shortName}); {address}; {timeStamp}; {departments.Count} departments");
    }
}

public class Department
{

}

public class Program
{
    public static void Main()
    {
        Department ISITDepartment = new Department();
        Department POITDepartment = new Department();

        Faculty fitFaculty = new Faculty("Information System Faculty", "FIT", "Sverdlova");
        fitFaculty.addDepartment(ISITDepartment);
        fitFaculty.addDepartment(POITDepartment);

        Faculty chemistryFaculty = new Faculty("Chemistry Faculty", "TOV", "Sverdlova");

        University university = new University("Forest University", "LID", "Sverdlova");
        university.addFaculty(fitFaculty);
        university.addFaculty(chemistryFaculty);

        university.printInfo();

        foreach (var faculty in university.getFaculties())
        {
            faculty.printInfo();
        }
    }
}