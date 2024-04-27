using CQRS_Implementation.Models;
using MediatR;

namespace CQRS_Implementation.Queries
{
    public class GetStudentByIdQuery: IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
