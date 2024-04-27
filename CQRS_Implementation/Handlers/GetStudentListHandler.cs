using CQRS_Implementation.Models;
using CQRS_Implementation.Queries;
using CQRS_Implementation.Repositories;
using MediatR;

namespace CQRS_Implementation.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentDetails>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDetails>> Handle(GetStudentListQuery query, CancellationToken token)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}
