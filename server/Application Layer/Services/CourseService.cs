using CodeCombat.Contracts;
using CodeCombat.DataAccess.Entity;
using CodeCombat.DataAccess.Repositories;
using CodeCombat.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CodeCombat.Services;

public class CourseService
{
    private readonly CourseRepository _courseRepository;
    public CourseService(CourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }   
    public async Task AddCourse(UserEntity user, CoursePostRequest course)
    {
        var Id = await _courseRepository.CreateCourseAsync(user, course.Title, course.Description, course.Tags);
        if(course.Modules != null)
        course.Modules.Select(
            async m => 
            {
            switch(m.Type)
            {

                
            }
            }
            );
    }
}