using Core.DomainModel;
using DomainServices.Repositories;
using Fysio_WebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Library.Data.Tests.Repositories
{
    public class EFPracticeRoomRepositoryTests
    {
        private readonly Mock<IPracticeRoomRepository> mock;
        public EFPracticeRoomRepositoryTests()
        {
            mock = new Mock<IPracticeRoomRepository>();
        }

        [Fact]
        public void FindAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var room = getSampleRooms();
            mock.Setup(x => x.PracticeRooms).Returns(room.AsQueryable());

            var controller = new PracticeRoomController(mock.Object);

            // Act
            var actionResult = controller.Index();
            var result = actionResult as ViewResult;
            var model = result.Model as IEnumerable<PracticeRoom>;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(getSampleRooms().Count(), model.Count());

        }

        [Fact]
        public void UpdatePracticeRoom_StateUnderTest_ExpectedBehavior()
        {
            //arrange
            var PracticeRooms = getSampleRooms();
            mock.Setup(x => x.PracticeRooms).Returns(PracticeRooms.AsQueryable());
            var newPracticeRoom = PracticeRooms[0];

            var controller = new PracticeRoomController(mock.Object);

            var editedPracticeRoom = newPracticeRoom;
            editedPracticeRoom.Name = "Room New";

            // Act
            var actionResult = controller.Edit(newPracticeRoom.Id, newPracticeRoom);

            // Assert
            Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.Equal(editedPracticeRoom.Name, mock.Object.PracticeRooms.FirstOrDefault(X => X.Id == 1).Name);

        }

        private List<PracticeRoom> getSampleRooms()
        {
            List<PracticeRoom> output = new List<PracticeRoom>
            {
                new PracticeRoom
                {
                    Id = 1,
                    Name = "Room 1",
                },
                new PracticeRoom
                {
                    Id = 2,
                    Name = "Room 2",
                }
            };
            return output;
        }
    }
}
