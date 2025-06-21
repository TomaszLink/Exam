using System.Globalization;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;
using WebApplication1.repositorycontent;
using Task = WebApplication1.models.Task;

namespace WebApplication1;

public class RecordsService(Repository repo)
{
    private readonly Repository repo = repo;



    public Record createRecord(CreateRecordRequest request)
    {
        
        Language language = this.repo.languages.Find(request.LanguageId);
        if (language == null)
        {
            throw new Exception("Language not found");
        }
        
        Student student = this.repo.students.Find(request.StudentId);
        if (student == null)
        {
            throw new Exception("Student not found");
        }

         Task task = findOrCreateTask(request.Task);
         Console.WriteLine();

        Record newRecort = new Record()
        {
            ExecutionTime = request.ExecutionTime,
            CreatedAt = request.CreatedAt,
            StudentId = student.Id,
            Student = student,
            LanguageId = language.Id,
            Language = language,
            Task = task,
            TaskId = task.Id
        };
        this.repo.records.Add(newRecort);
        this.repo.SaveChanges();
        return newRecort;
    }

    public Task findOrCreateTask(TaskRequest taskRequest)
    {
        Task found = this.repo.tasks.Find(taskRequest.Id);
        if (found != null)
        {
            return found;
        }
        
        if (taskRequest.Name == null || taskRequest.Description == null)
        {
            throw new ApplicationException("Task not found");
        }

        Task newTask = new Task()
        {
            Name = taskRequest.Name,
            Description = taskRequest.Description
        };
        this.repo.tasks.Add(newTask);
        this.repo.SaveChanges();
        return newTask;
    }

    public List<Record> getAllRecords()
    {
        return this.repo.records
            .Include(r => r.Task)
            .Include(r => r.Student)
            .Include(r => r.Language)
            .OrderBy(p => p.ExecutionTime)
            .ToList();
    }
}