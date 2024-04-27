using CQRS_Implementation.Models;
using CQRS_Implementation.Queries;
using CQRS_Implementation.Repositories;
using MediatR;

namespace CQRS_Implementation.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery , StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(GetStudentByIdQuery query, CancellationToken token)
        {
            return await _studentRepository.GetStudentByIdAsync(query.Id);
        }
    }
}
