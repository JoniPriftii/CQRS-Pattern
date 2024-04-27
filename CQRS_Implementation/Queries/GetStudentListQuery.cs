using CQRS_Implementation.Models;
using MediatR;

namespace CQRS_Implementation.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}
