using System;

public class Organization : IStaff
{
    protected List<JobVacancy> jobVacancies = new List<JobVacancy>();
    protected List<JobTitle> jobTitles = new List<JobTitle>();
    protected List<Employee> employees = new List<Employee>();

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
        this.jobVacancies = other.jobVacancies;
        this.jobTitles = other.jobTitles;
        this.employees = other.employees;
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
        Console.WriteLine($"organization '{name}' ({shortName}); {address}; {timeStamp}");
    }

    public virtual List<JobVacancy> getJobVacancies()
    {
        return jobVacancies;
    }

    public virtual List<JobTitle> getJobTitles()
    {
        return jobTitles;
    }

    public virtual List<Employee> getEmployees()
    {
        return employees;
    }

    public virtual int addJobTitle(JobTitle jobTitle)
    {
        try
        {
            jobTitles.Add(jobTitle);
            return jobTitles.Count;
        }
        catch
        {
            return -1;
        }
    }

    public virtual string printJobVacancies()
    {
        return string.Join('\n', jobVacancies.Select(jv => $"{jv.title} [{jv.isOpened}]"));
    }

    public virtual bool delJobTitle(int jobTitleId)
    {
        try
        {
            jobTitles.RemoveAt(jobTitleId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public virtual int openJobVacancy(JobVacancy jobVacancy)
    {
        try
        {
            int index = jobVacancies.FindIndex(jb => jb.title == jobVacancy.title);
            jobVacancies[index].Open();
            return index;
        }
        catch
        {
            return -1;
        }
    }

    public virtual bool closeJobVacancy(int jobId)
    {
        try
        {
            jobVacancies[jobId].Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public virtual Employee recruit(JobVacancy jobVacancy, Person person)
    {
        return new Employee(person.name, name, jobVacancy.title);
    }

    public virtual bool dismiss(int jobId, Reason reason)
    {
        Console.WriteLine($"{jobId} dissmissed because of {reason.description}");
        return true;
    }
}

public class University : Organization, IStaff
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

    public override List<JobVacancy> getJobVacancies()
    {
        return jobVacancies;
    }

    public override List<JobTitle> getJobTitles()
    {
        return jobTitles;
    }

    public override List<Employee> getEmployees()
    {
        return employees;
    }

    public override int addJobTitle(JobTitle jobTitle)
    {
        try
        {
            jobTitles.Add(jobTitle);
            return jobTitles.Count;
        }
        catch
        {
            return -1;
        }
    }

    public override string printJobVacancies()
    {
        return string.Join('\n', jobVacancies.Select(jv => $"{jv.title} [{jv.isOpened}]"));
    }

    public override bool delJobTitle(int jobTitleId)
    {
        try
        {
            jobTitles.RemoveAt(jobTitleId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override int openJobVacancy(JobVacancy jobVacancy)
    {
        try
        {
            int index = jobVacancies.FindIndex(jb => jb.title == jobVacancy.title);
            jobVacancies[index].Open();
            return index;
        }
        catch
        {
            return -1;
        }
    }

    public override bool closeJobVacancy(int jobId)
    {
        try
        {
            jobVacancies[jobId].Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override Employee recruit(JobVacancy jobVacancy, Person person)
    {
        return new Employee(person.name, name, jobVacancy.title);
    }

    public override bool dismiss(int jobId, Reason reason)
    {
        Console.WriteLine($"{jobId} dissmissed because of {reason.description}");
        return true;
    }
}

public class Faculty : Organization, IStaff
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

    public override List<JobVacancy> getJobVacancies()
    {
        return jobVacancies;
    }

    public override List<JobTitle> getJobTitles()
    {
        return jobTitles;
    }

    public override List<Employee> getEmployees()
    {
        return employees;
    }

    public override int addJobTitle(JobTitle jobTitle)
    {
        try
        {
            jobTitles.Add(jobTitle);
            return jobTitles.Count;
        }
        catch
        {
            return -1;
        }
    }

    public override string printJobVacancies()
    {
        return string.Join('\n', jobVacancies.Select(jv => $"{jv.title} [{jv.isOpened}]"));
    }

    public override bool delJobTitle(int jobTitleId)
    {
        try
        {
            jobTitles.RemoveAt(jobTitleId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override int openJobVacancy(JobVacancy jobVacancy)
    {
        try
        {
            int index = jobVacancies.FindIndex(jb => jb.title == jobVacancy.title);
            jobVacancies[index].Open();
            return index;
        }
        catch
        {
            return -1;
        }
    }

    public override bool closeJobVacancy(int jobId)
    {
        try
        {
            jobVacancies[jobId].Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override Employee recruit(JobVacancy jobVacancy, Person person)
    {
        return new Employee(person.name, name, jobVacancy.title);
    }

    public override bool dismiss(int jobId, Reason reason)
    {
        Console.WriteLine($"{jobId} dissmissed because of {reason.description}");
        return true;
    }
}

public interface IStaff
{
    List<JobVacancy> getJobVacancies();
    List<Employee> getEmployees();
    List<JobTitle> getJobTitles();
    int addJobTitle(JobTitle jobTitle);
    string printJobVacancies();
    bool delJobTitle(int jobTitleId);
    int openJobVacancy(JobVacancy jobVacancy);
    bool closeJobVacancy(int jobVacancyId);
    Employee recruit(JobVacancy jobVacancy, Person person);
    bool dismiss(int jobVacancyId, Reason reason);
}

public class JobVacancy
{
    public string title
    {
        get;
        private set;
    }

    public bool isOpened
    {
        get;
        private set;
    }

    public JobVacancy(string title)
    {
        this.title = title;
        isOpened = false;
    }

    public void Open()
    {
        isOpened = true;
    }

    public void Close()
    {
        isOpened = false;
    }
}

public class Employee : Person
{
    public string department
    {
        get;
        private set;
    }

    public string job
    {
        get;
        private set;
    }

    public Employee(string name, string department, string job) : base(name)
    {
        this.department = department;
        this.job = job;
    }
}

public class Person
{
    public string name
    {
        get;
        private set;
    }

    public Person(string name)
    {
        this.name = name;
    }
}

public class JobTitle
{
    public string title
    {
        get;
        private set;
    }

    public JobTitle(string title)
    {
        this.title = title;
    }
}

public class Department
{

}

public class Reason
{
    public string description
    {
        get;
        private set;
    }

    public Reason(string description)
    {
        this.description = description;
    }
}

class Program
{
    static void Main()
    {
        Organization org = new Organization("ITArt", "ITArt", "Belarussian");
        org.printInfo();

        University uni = new University("BSTU", "BSTU", "Sverdlova");
        uni.printInfo();

        Faculty faculty1 = new Faculty("IT Faculty", "FIT", "Sverdlova");
        Faculty faculty2 = new Faculty("Forest Faculty", "LID", "Sverdlova");
        uni.addFaculty(faculty1);
        uni.addFaculty(faculty2);
        uni.printInfo();

        Department dep1 = new Department();
        Department dep2 = new Department();
        faculty1.addDepartment(dep1);
        faculty1.addDepartment(dep2);
        faculty1.printInfo();

        JobVacancy jobVacancy1 = new JobVacancy("software engineer");
        JobVacancy jobVacancy2 = new JobVacancy("designer");
        org.addJobTitle(new JobTitle("software engineer"));
        org.addJobTitle(new JobTitle("designer"));
        org.getJobVacancies().Add(jobVacancy1);
        org.getJobVacancies().Add(jobVacancy2);

        Console.WriteLine(org.printJobVacancies());

        org.openJobVacancy(jobVacancy1);
        Console.WriteLine(org.printJobVacancies());


        Person person1 = new Person("Gleb Shersh");
        Employee employee1 = org.recruit(jobVacancy1, person1);
        org.getEmployees().Add(employee1);
        Console.WriteLine($"employee: {employee1.name}, department: {employee1.department}, job: {employee1.job}");

        Reason reason = new Reason("end contract");
        org.dismiss(0, reason);
    }
}