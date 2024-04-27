using CQRS_Implementation.Commands;
using CQRS_Implementation.Repositories;
using MediatR;
using System.Runtime.CompilerServices;

namespace CQRS_Implementation.Handlers
{
    public class DeleteStudentHandler: IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand command, CancellationToken token)
        {
            var selectedStudent = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (selectedStudent == null)
            {
                return default;
            }
            return await _studentRepository.DeleteStudentAsync(selectedStudent.Id);
        }
    }
}
