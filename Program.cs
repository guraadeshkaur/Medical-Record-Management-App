// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace MedicalRecordsManagement
{
    class MedicalRecord
    {
        //private static int idCounter = 1;

        public int Id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? gender { get; set; }
        public string? diagnosis { get; set; }

    }
    class Program
    {
        static List<MedicalRecord> records = new List<MedicalRecord>();

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("----- Medical Records Management -----");
                Console.WriteLine("1. Add Medical Record");
                Console.WriteLine("2. View Medical Records");
                Console.WriteLine("3. Search Patient");
                Console.WriteLine("4. Exit");
                Console.WriteLine("--------------------------------------");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddMedicalRecord();
                        break;
                    case 2:
                        ViewMedicalRecords();
                        break;
                    case 3:
                        SearchPatient();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddMedicalRecord()
        {
            Console.WriteLine("----- Add Medical Record -----");
            MedicalRecord record = new MedicalRecord();
            Console.Write("Enter patient id:");
            record.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter patient name: ");
            record.name = Console.ReadLine();
            Console.Write("Enter age: ");
            record.age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter gender (M/F): ");
            record.gender = Console.ReadLine();
            Console.Write("Enter diagnosis: ");
            record.diagnosis = Console.ReadLine();

            records.Add(record);

            Console.WriteLine("Medical record added successfully!");
        }

        static void ViewMedicalRecords()
        {
            Console.WriteLine("----- View Medical Records -----");

            if (records.Count == 0)
            {
                Console.WriteLine("No medical records found.");
            }
            else
            {
                Console.WriteLine("Medical Record List:");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("ID\tName\t\tAge\tGender\tDiagnosis");
                Console.WriteLine("-----------------------------------------------------");

                foreach (var record in records)
                {
                    Console.WriteLine($"{record.Id}\t{record.name}\t\t{record.age}\t{record.gender}\t{record.diagnosis}");
                }

                Console.WriteLine("-----------------------------------------------------");
            }
        }

        static void SearchPatient()
        {
            Console.Write("Enter the patient id to search: ");
            int find = Convert.ToInt32(Console.ReadLine());

            bool recordFound = false;
            foreach (MedicalRecord record in records)
            {
                if (record.Id == find)
                {
                    Console.WriteLine($"Id: {record.Id}");
                    Console.WriteLine($"name: {record.name}");
                    Console.WriteLine($"age: {record.age}");
                    Console.WriteLine($"gender: {record.gender}");
                    Console.WriteLine($"diagnosis: {record.diagnosis}");
                    Console.WriteLine();
                    recordFound = true;
                    break;
                }
            }

            if (!recordFound)
            {
                Console.WriteLine("Record not found.");
            }
        }
    }
}

