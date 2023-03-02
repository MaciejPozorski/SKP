namespace SKP.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Person person = new Person(
                1, 
                "Adam", 
                "P¹czek", 
                123456789, 
                12345678911, 
                new DateOnly(1111, 11, 11)
                );

            Mock<IService<Person>> mock = new Mock<IService<Person>>();
            mock.Setup(s => s.GetItemById(1)).Returns(person);

            PersonManager manager = new PersonManager(new MenuService(), mock.Object);

            //Act
            Person item = manager.GetPersonById(person.Id);

            //Assert
            Assert.Equal(person, item);
        }
    }
}