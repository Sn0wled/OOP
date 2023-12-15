namespace TransportManagementSystem
{
    internal abstract class Person
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string pName { get; set; }
        public int age { get; set; }
        public Gender gender;
        public Person(string fName, string lName, string pName, int age, Gender gender)
        {
            this.fName = fName;
            this.lName = lName;
            this.pName = pName;
            this.age = age;
            this.gender = gender;
        }
    }

    enum Gender
    {
        Male,
        Female
    }
}
