using RedBadge.Data;
using RedBadgeModels.Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = RedBadgeData.Task;

namespace RedBadgeServices
{
    public class TaskService
    {
        private readonly Guid _userId;

        public TaskService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTask(TaskCreate model)
        {
            var entity =
                new Task()
                {
                    Title = model.Title,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tasks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TaskListItem> GetTasks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tasks
                        .Where(x => x.Project.UserId == _userId)
                        .Select(
                        e =>
                            new TaskListItem
                            {
                                TaskId = e.TaskId,
                                ProjectId = e.ProjectId,
                                Title = e.Title,
                                Description = e.Description,
                                IsDone = e.IsDone
                            }
                        );
                return query.ToArray();
            }
        }

        public TaskDetail GetTaskById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tasks
                        .Single(e => e.TaskId == id && e.Project.UserId == _userId);
                return
                    new TaskDetail
                    {
                        TaskId = entity.TaskId,
                        ProjectId = entity.ProjectId,
                        Title = entity.Title, 
                        Description = entity.Description,
                        IsDone = entity.IsDone
                    };
            }
        }

        public bool UpdateTasks(TaskEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tasks
                        .Single(e => e.TaskId == model.TaskId && e.Project.UserId == _userId);

                entity.ProjectId = model.ProjectId;
                entity.Title = model.Title;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTask(int taskId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tasks
                        .Single(e => e.TaskId == taskId && e.Project.UserId == _userId);

                        ctx.Tasks.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
