using CQRS_Implementation.Commands;
using CQRS_Implementation.Models;
using CQRS_Implementation.Repositories;
using MediatR;

namespace CQRS_Implementation.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand command, CancellationToken token)
        {
            var StudentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (StudentDetails == null)
            {
                return default;
            }
            StudentDetails.StudentEmail = command.StudentEmail;
            StudentDetails.StudentName = command.StudentName;
            StudentDetails.StudentAge = command.StudentAge;
            StudentDetails.StudentAddress = command.StudentAddress;
            return await _studentRepository.UpdateStudentAsync(StudentDetails);
        }
    }
}
