﻿using CQRS.Model;
using MediatR;

namespace CQRSAndMediatRDemo.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}