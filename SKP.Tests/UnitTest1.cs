using Castle.Core.Logging;
using FluentAssertions;

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

        [Fact]
        public void Test2()
        {
            WorkDay workDay = new WorkDay(1, 1, new DateOnly(2011, 10, 09), 8);


            Mock<IService<WorkDay>> mock = new Mock<IService<WorkDay>>();
            mock.Setup(s => s.GetItemById(1)).Returns(workDay);

            WorkDayManager manager = new WorkDayManager(new MenuService(), mock.Object);

            //Act
            WorkDay day = manager.GetWorkDayById(workDay.Id);

            //Assert
            day.Should().NotBeNull();
            day.Should().BeOfType<WorkDay>();
            day.Should().BeSameAs(workDay);
            
        }

        [Fact]
        public void Test3()
        {
            Person person = new Person(
                5,
                "jacek",
                "nazwisko",
                123654,
                654,
                new DateOnly(3232, 5, 7));


            Mock<IService<Person>> mock = new Mock<IService<Person>>();
            mock.Setup(s => s.GetItemById(person.Id)).Returns(person);
            mock.Setup(s => s.RemoveItem(It.IsAny<Person>()));

            PersonManager manager = new PersonManager(new MenuService(), mock.Object);

            manager.RemovePersonById(person.Id);

            mock.Verify(m => m.RemoveItem(person));
        }

        [Fact]
        public void Test4()
        {
            Person person = new Person(
                5,
                "jacek",
                "nazwisko",
                123654,
                654,
                new DateOnly(3232, 5, 7));


            Mock<IService<Person>> mock = new Mock<IService<Person>>();
            mock.Setup(s => s.GetItemById(person.Id)).Returns(person);
            mock.Setup(s => s.AddItem(It.IsAny<Person>()));

            PersonManager manager = new PersonManager(new MenuService(), mock.Object);

            manager.AddPerson(person);

            mock.Verify(m => m.AddItem(person));
        }

    }
}