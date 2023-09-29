using CQRS.Model;
using MediatR;

namespace CQRS.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}