using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Data.Entities;
using StudentManagement.Services;
using StudentManagement.ViewModels;

namespace StudentManagement.Services;
public class CoursesService : ICoursesService
{
    private readonly CourseDbContext _context;
    private readonly IMapper _mapper;

    public CoursesService(CourseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CourseViewModel>> GetAllFilter(string sortOrder, string currentFilter, string searchString, int? pageNumber, int pageSize)
    {
        if (searchString != null)
        {
            pageNumber = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        var courses = from m in _context.Courses select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            courses = courses.Where(s => s.CourseID!.Contains(searchString)
            || s.CourseName!.Contains(searchString)
            || s.Teacher!.Contains(searchString));
        }

        courses = sortOrder switch
        {
            "CourseID_desc" => courses.OrderByDescending(s => s.CourseID),
            "CourseName" => courses.OrderBy(s => s.CourseName),
            "CourseName_desc" => courses.OrderByDescending(s => s.CourseName),
            "Teacher_date" => courses.OrderBy(s => s.Teacher),
            "Teacher_date_desc" => courses.OrderByDescending(s => s.Teacher),
            _ => courses.OrderBy(s => s.CourseID),
        };

        return PaginatedList<CourseViewModel>.Create(_mapper.Map<IEnumerable<CourseViewModel>>(await courses.ToListAsync()), pageNumber ?? 1, pageSize);
    }

    public async Task<int> Create(CourseRequest request)
    {
        var course = _mapper.Map<Course>(request);
        _context.Add(course);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
        }
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CourseViewModel>> GetAll()
    {
        var products = await _context.Courses.ToListAsync();
        return _mapper.Map<IEnumerable<CourseViewModel>>(products);
    }

    public async Task<CourseViewModel> GetById(int id)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<CourseViewModel>(course);
    }

    public async Task<int> Update(CourseViewModel request)
    {
        if (!CourseExists(request.Id))
        {
            throw new Exception("Course does not exist");
        }
        _context.Update(_mapper.Map<Course>(request));
        return await _context.SaveChangesAsync();
    }

    private bool CourseExists(int id)
    {
        return _context.Courses.Any(e => e.Id == id);
    }
}