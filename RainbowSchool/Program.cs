using System;
using System.Collections.Generic;
using System.IO;
namespace RainbowSchool
{
    class Teacher
    {
        public Teacher(string id, string name, string Claass, string section)
        {
            ID = id;
            Name = name;
            Class = Claass;
            Section = section;
        }

        public String ID { get; set; }
        public String Name { get; set; }
        public String Class { get; set; }
        public String Section { get; set; }

        public override string ToString()
        {
            return ID + "," + Name + "," + Class + "," + Section;
        }
    }
    class TeacherAll
    {
        private List<Teacher> teachers;
        public TeacherAll()
        {
            teachers = new List<Teacher>();
        }
        public List<Teacher> GetAllTeachers() => teachers;
        public void AddTacher(Teacher teach)
        {
            teachers.Add(teach);
        }
        public void deletTeacher(string id)
        {
            int index = teachers.FindIndex(x => x.ID.Equals(id));
            teachers.RemoveAt(index);
        }
    }
    class Program
    {
      
            static readonly string textFile = @"C:\Users\Hind\Documents\teacherData.txt";
            public static string[] UpdateFileTxt(TeacherAll teachers)
            {
                List<Teacher> ii = teachers.GetAllTeachers();
                List<string> bb = new List<string>();
                foreach (Teacher m in ii)
                    bb.Add(m.ToString());
                return bb.ToArray();
            }
            static void Main(string[] args)
            {
                TeacherAll teachers = new TeacherAll();
                bool EmptyFil = true;
                int userInput = 0;
                int userInput2 = 0;
                string id;
                string name;
                string Class;
                string section;
                if (!File.Exists(textFile))
                {
                    Console.WriteLine("There is no text file");
                }
                else
                {
                    // Read entire text file content in one string   
                    string[] lines = System.IO.File.ReadAllLines(textFile);
                    if (lines.Length > 0)
                    {
                        EmptyFil = false;
                        foreach (string line in lines)
                        {
                            string[] singleLine = line.Split(',');
                            teachers.AddTacher(new Teacher(singleLine[0], singleLine[1], singleLine[2], singleLine[3]));
                        }
                    }
                    Console.WriteLine("Welocom to Rainbow Schol System");
                    do
                    {
                        Console.WriteLine("Choose what do you wanna do ." +
                            "\n1.Reterive data .\n2.Update data file .\n3.Exit .");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                {
                                    if (!EmptyFil)
                                    {
                                        List<Teacher> teach = teachers.GetAllTeachers();
                                        foreach (Teacher TeacherInfo in teach)
                                            Console.WriteLine($"{TeacherInfo.ID} {TeacherInfo.Name} " +
                                                $"{TeacherInfo.Class} {TeacherInfo.Section} ");
                                    }
                                    else
                                        Console.WriteLine("there's no data ");
                                    break;
                                }
                            case 2:
                                {
                                    do
                                    {
                                        Console.WriteLine("Choose what do you wanna do ." +
                                            "\n1.Add teacher .\n2.Remove teacher file ." +
                                            "\n3.Return to main menue .");
                                        userInput2 = Convert.ToInt32(Console.ReadLine());
                                        switch (userInput2)
                                        {
                                            case 1:
                                                {
                                                    EmptyFil = false;
                                                    Console.Write("Enter teacher ID : ");
                                                    id = Console.ReadLine();
                                                    Console.Write("Enter teacher Name : ");
                                                    name = Console.ReadLine();
                                                    Console.Write("Enter teacher Class : ");
                                                    Class = Console.ReadLine();
                                                    Console.Write("Enter teacher Section : ");
                                                    section = Console.ReadLine();
                                                    teachers.AddTacher(new Teacher(id, name, Class, section));
                                                    //Update the file 
                                                    File.WriteAllLines(textFile, UpdateFileTxt(teachers));
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.Write("Enter teacher ID : ");
                                                    id = Console.ReadLine();
                                                    teachers.deletTeacher(id);
                                                    //Update the file 
                                                    File.WriteAllLines(textFile, UpdateFileTxt(teachers));
                                                }
                                                break;

                                        }
                                    } while (userInput2 != 3);
                                    break;
                                }
                        }
                    } while (userInput != 3);
                }
            }
        }
    }

