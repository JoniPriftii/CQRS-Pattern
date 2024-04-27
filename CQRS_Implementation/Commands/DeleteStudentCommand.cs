using MediatR;

namespace CQRS_Implementation.Commands
{
    public class DeleteStudentCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
