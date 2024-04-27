using CQRS_Implementation.Data;
using CQRS_Implementation.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Implementation.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly DbContextClass _dbContext;
        public StudentRepository( DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = _dbContext.Students.Add(studentDetails);

            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int studentId)
        {
            var selectedSudent = _dbContext.Students.Where(x => x.Id == studentId).FirstOrDefault();
            _dbContext.Students.Remove(selectedSudent);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            return await _dbContext.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            _dbContext.Students.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
