using CQRS_Implementation.Commands;
using CQRS_Implementation.Models;
using CQRS_Implementation.Repositories;
using MediatR;

namespace CQRS_Implementation.Handlers
{
    public class AddStudentHandler: IRequestHandler<AddStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(AddStudentCommand command, CancellationToken token)
        {
            var StudentDetails = new StudentDetails()
            {
                StudentName = command.StudentName,
                StudentAddress = command.StudentAddress,
                StudentEmail = command.StudentEmail,
                StudentAge = command.StudentAge
            };
            return await _studentRepository.AddStudentAsync(StudentDetails);
        }
    }
}
