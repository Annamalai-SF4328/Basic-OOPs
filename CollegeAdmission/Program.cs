using System;
using System.Collections.Generic;
namespace CollegeAdmission;
class Program
{
    static List<StudentDetails> studentsList = new List<StudentDetails>();
    static List<DepartmentDetails> departmentsList = new List<DepartmentDetails>();
    static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
    static StudentDetails CurrentStudentID;

    public static void Main(string[] args)
    {
        LoadDefaultData();
        bool flag = true;
        do
        {
            Console.WriteLine("Main Menu\n1. Student Registration\n2. Student Login\n3. Department wise seat availability\n4. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        SeatAvailability();
                        break;
                    }
                case 4:
                    {
                        flag = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice.");
                        break;
                    }
            }
        } while (flag);

    }

    public static void LoadDefaultData()
    {
        StudentDetails student1 = new StudentDetails("Ravichandran", "Ettapparajan", DateTime.ParseExact("11/11/1999", "MM/dd/yyyy", null), Gender.Male, 95, 95, 95);
        StudentDetails student2 = new StudentDetails("Baskaran", "Sethurajan", DateTime.ParseExact("11/11/1999", "MM/dd/yyyy", null), Gender.Male, 95, 95, 95);

        studentsList.Add(student1);
        studentsList.Add(student2);


        DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
        DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
        DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
        DepartmentDetails department4 = new DepartmentDetails("ECE", 30);

        departmentsList.Add(department1);
        departmentsList.Add(department2);
        departmentsList.Add(department3);
        departmentsList.Add(department4);

        AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", DateTime.ParseExact("05/11/2022", "MM/dd/yyyy", null), AdmissionStatus.Admitted);
        AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", DateTime.ParseExact("05/12/2022", "MM/dd/yyyy", null), AdmissionStatus.Admitted);

        admissionList.Add(admission1);
        admissionList.Add(admission2);
    }

    public static void SeatAvailability()
    {
        foreach (DepartmentDetails department1 in departmentsList)
        {
            Console.WriteLine("\nDepartment ID : " + department1.DepartmentID);
            Console.WriteLine("Department name : " + department1.DepartmentName);
            Console.WriteLine("Number of seats : " + department1.NumberOfSeats);
        }
    }

    public static void Registration()
    {
        // get student’s details.
        Console.WriteLine("\nEnter student name : ");
        string studentName = Console.ReadLine();
        Console.WriteLine("Enter student Father name : ");
        string fatherName = Console.ReadLine();
        Console.WriteLine("Enter student Date of birth : (as MM/dd/yyyy)");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
        Console.WriteLine("Enter student Gender : ");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
        Console.WriteLine("Enter student Physics mark : ");
        double physics = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter student Chemistry mark : ");
        double chemistry = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter student Maths mark : ");
        double maths = double.Parse(Console.ReadLine());

        // object create and add to list
        StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physics, chemistry, maths);
        Console.WriteLine("\nStudent Registered Successfully and StudentID is " + student.StudentID);
        studentsList.Add(student);
    }

    public static void Login()
    {
        // get Student ID from user
        Console.WriteLine("Enter student ID : ");
        string loginID = Console.ReadLine().ToUpper();

        // validate the customer ID from customer list
        bool flag = true;
        foreach (StudentDetails student in studentsList)
        {
            if (loginID == student.StudentID)
            {
                CurrentStudentID = student;
                flag = false;
                // Display submenu
                SubMenu();
            }
        }
        if (flag)
        {
            Console.WriteLine("Invalid student ID");
        }
    }
    public static void SubMenu()
    {
        bool flag = true;
        do
        {
            Console.WriteLine();
            Console.WriteLine("SubMenu \n1. check eligibility\n2. show details\n3. take admission\n4. cancel admission\n5. show admission deatils\n6. Exit");
            int choice1 = int.Parse(Console.ReadLine());
            switch (choice1)
            {
                case 1:
                    {
                        CheckEligibility();
                        break;
                    }
                case 2:
                    {
                        ShowDeatails();
                        break;
                    }
                case 3:
                    {
                        TakeAdmission();
                        break;
                    }
                case 4:
                    {
                        CancelAdmission();
                        break;
                    }
                case 5:
                    {
                        ShowAdmissionDetails();
                        break;
                    }
                case 6:
                    {
                        flag = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Choice");
                        break;
                    }
            }
        } while (flag);
    }
    public static void CheckEligibility()
    {
        if (CurrentStudentID.CheckEligibility())
        {
            Console.WriteLine("Student is eligible");
        }
        else if (!CurrentStudentID.CheckEligibility())
        {
            Console.WriteLine("Student is not eligible");
        }
    }

    public static void ShowDeatails()
    {
        Console.WriteLine($"student ID : {CurrentStudentID.StudentID}\nstudent name : {CurrentStudentID.StudentName}\nstudent father name : {CurrentStudentID.FatherName}\nDOB : {CurrentStudentID.DOB}\nGender : {CurrentStudentID.Gender}\nPhysics : {CurrentStudentID.Physics}\nChemistry : {CurrentStudentID.Chemistry}\nMaths : {CurrentStudentID.Maths}");
    }

    public static void TakeAdmission()
    {
        // show department details
        foreach (DepartmentDetails department in departmentsList)
        {
            Console.WriteLine("\ndepartment ID : " + department.DepartmentID + "\nDepartment : " + department.DepartmentName + "\nAvailable seats : " + department.NumberOfSeats);
        }

        // get department by student
        Console.WriteLine("\nEnter Department ID : ");
        string departmentLoginID = Console.ReadLine().ToUpper();

        // validate the department ID
        bool checkDepartmentID = true;
        foreach (DepartmentDetails department1 in departmentsList)
        {
            if (department1.DepartmentID == departmentLoginID)
            {
                // check eligible for admission
                checkDepartmentID = false;
                bool checkOldStudent = true;
                foreach (AdmissionDetails admission2 in admissionList)
                {
                    if (admission2.StudentID == CurrentStudentID.StudentID)
                    {
                        checkOldStudent = false;
                        break;
                    }
                }
                if (checkOldStudent)
                {
                    checkOldStudent = false;
                    if (CurrentStudentID.CheckEligibility())
                    {
                        // check seat available
                        if (department1.NumberOfSeats >= 1)
                        {
                            // check he is fresher
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (admission.StudentID != CurrentStudentID.StudentID)
                                {
                                    // reduce seat count
                                    department1.NumberOfSeats--;

                                    // create admission
                                    AdmissionDetails admission1 = new AdmissionDetails(CurrentStudentID.StudentID, department1.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                    
                                    // add to list
                                    admissionList.Add(admission1);
                                    
                                    // Finally show “Admission took successfully. Your admission ID – SF3001”.
                                    Console.WriteLine("Admission took successfully. Your admission ID is " + admission1.AdmissionID);
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You are already do course in our institute.");
                }
            }
        }
        // if invalid product ID print invalid 
        if (checkDepartmentID)
        {
            Console.WriteLine("Invalid DepartmentID.");
        }
    }

    public static void CancelAdmission()
    {
        // show the current student admission details
        foreach (AdmissionDetails admit in admissionList)
        {
            if (admit.StudentID == CurrentStudentID.StudentID)
            {
                Console.WriteLine("Admission ID : " + admit.AdmissionID);
                Console.WriteLine("Student ID : " + admit.StudentID);
                Console.WriteLine("Department ID : " + admit.DepartmentID);
                Console.WriteLine("Admission Date : " + admit.AdmissionDate);
                Console.WriteLine("Admission Status : " + admit.AdmissionStatus);

                // change status
                admit.AdmissionStatus = AdmissionStatus.Cancelled;
                Console.WriteLine("\nAdmission Status Changed to " + admit.AdmissionStatus);

                // return seat
                foreach (DepartmentDetails department in departmentsList)
                {
                    if (admit.DepartmentID == department.DepartmentID)
                    {
                        department.NumberOfSeats++;
                        Console.WriteLine("Admission cancelled successfully.");
                        break;
                    }
                }
                break;
            }
        }

    }
    public static void ShowAdmissionDetails()
    {
        foreach (AdmissionDetails admit in admissionList)
        {
            if (admit.StudentID == CurrentStudentID.StudentID)
            {
                Console.WriteLine("Admission ID : " + admit.AdmissionID);
                Console.WriteLine("Student ID : " + admit.StudentID);
                Console.WriteLine("Department ID : " + admit.DepartmentID);
                Console.WriteLine("Admission Date : " + admit.AdmissionDate);
                Console.WriteLine("Admission Status : " + admit.AdmissionStatus);
            }
        }
    }


}