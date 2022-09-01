using Core.Entities;
using System;


namespace Entities.DTOs
{
    public class LessonDetailDto : IDto
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }
    }
}