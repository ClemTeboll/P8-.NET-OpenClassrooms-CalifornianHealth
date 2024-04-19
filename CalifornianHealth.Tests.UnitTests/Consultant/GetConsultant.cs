using Moq;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantRepository;
using CalifornianHealth.Core.Consultant;
using CalifornianHealth.Core.Consultant.Contracts;

namespace CalifornianHealth.Tests.UnitTests.Consultant;

public class GetConsultant
{
    [Fact]
    public void Should_Return_All_Consultants()
    {
        // Arrange
        Mock<IConsultantRepository> mockConsultantRepository = new Mock<IConsultantRepository>();
        Mock<IConsultantManager> mockConsultantManager = new Mock<IConsultantManager>();

        mockConsultantRepository.Setup(x => x.FetchConsultants()).Returns(new List<Infrastructure.Database.Entities.Consultant>
        {
            new()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Speciality = "Cardiology"
            },
            new()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Speciality = "Neurology"
            }
        });

        var productManager = new ConsultantManager(mockConsultantRepository.Object);

        // Act
        var result = productManager.ListConsultants();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count());
    }
}
