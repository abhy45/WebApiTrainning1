using FifthExample_RepoPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public interface IRepo<T>
{
    Task<IEnumerable<T>> Get();

    Task<T> Get(int id);

    Task<T> Add(T e);
    Task<T> Update(T e);

    void Delete(int id);
}

public interface IStudentRepository : IRepo<Student>
{
    Task<IEnumerable<Student>> FindByName(string name);
}
public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext context;

    public StudentRepository(StudentDbContext context)
    {
        this.context = context;
    }
    public async Task<Student> Add(Student e)
    {
        context.Students.Add(e);
        await context.SaveChangesAsync();
        return e;
    }

    public async void Delete(int id)
    {
        var rec = await context.Students.FindAsync(id);
        context.Students.Remove(rec);
        context.SaveChanges();
    }

    public async Task<IEnumerable<Student>> FindByName(string name)
    {
        var recs = await context.Students.Where((s) => s.StudentName.Contains(name)).ToListAsync();
        return recs;
    }

    public async Task<IEnumerable<Student>> Get()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Student> Get(int id)
    {
        return await context.Students.FindAsync(id);
    }

    public async Task<Student> Update(Student e)
    {
        var rec = await context.Students.FindAsync(e.StudentId);
        rec.StudentName = e.StudentName;
        rec.Phoneno = e.Phoneno;
        rec.CurrentClass = e.CurrentClass;
        await context.SaveChangesAsync();
        return rec;
    }
}