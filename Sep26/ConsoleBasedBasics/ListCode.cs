class Program{
    static void Main(){
        //LISTS in C#
        const int noOfStudents = 5;
        //create a list
        List<int> marks = new List<int>();
        //loop to input 5 marks
        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine($"Enter marks of student{i}: ");
            //add the elements to the list using Add() method
            marks.Add(int.Parse(Console.ReadLine()));
        }
        //calculate the total
        int total = 0;
        foreach(int mark in marks)
        {
            total += mark;
        }
        int average = total / noOfStudents;
        Console.WriteLine($"Average is: {average}");
    }
}