namespace PageObjectsExample
{
    internal class ExampleComment
    {
        public ExampleComment()
        {
            Author = Faker.Name.FullName();
            Email = Faker.Internet.Email();
            Content = Faker.Lorem.Paragraph();
        }

        public string Author { get; private set; }
        public string Email { get; private set; }
        public string Content { get; private set; }
    }
}