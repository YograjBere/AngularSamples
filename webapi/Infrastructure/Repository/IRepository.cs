using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Infrastructure.Repository
{
    public interface IPagedList<T>
    {
        PagedList<T> GetPagedList(PageContext<T> pageContext);
    }

    public interface IStudentRepository : IPagedList<Student>
    {
        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns></returns>
        int CreateStudent(Student student);

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteStudent(int id);

        /// <summary>
        /// Gets the student by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Student GetStudentById(int id);

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetStudents();

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="student">The student.</param>
        void UpdateStudent(Student student);
        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        // IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> predicate);

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        // IEnumerable<Student> GetStudents(Func<Student, bool> predicate = null, int pageIndex = 1, int pageSize = 10);
    }

    public class PageContext<T>
    {
        public List<Func<T, bool>> FiltersApplied { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    /// <summary>
    /// Class representing the paged data of model T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>
    {
        /// <summary>
        /// Gets or sets the filters applied.
        /// </summary>
        /// <value>
        /// The filters applied.
        /// </value>
        public List<Expression<Func<T, bool>>> FiltersApplied { get; set; }

        /// <summary>
        /// Gets or sets the paged data.
        /// </summary>
        /// <value>
        /// The paged data.
        /// </value>
        public IEnumerable<T> PagedData { get; set; }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }
        /// <summary>
        /// Gets or sets the record count.
        /// </summary>
        /// <value>
        /// The record count.
        /// </value>
        public int RecordCount { get; private set; }
    }
    /// <summary>
    /// Represents the repository for student entity
    /// </summary>
    /// <seealso cref="webapi.Infrastructure.Repository.IStudentRepository" />
    public class StudentRepository : IStudentRepository
    {
        private StudentDbContext _dbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            _dbContext = studentDbContext;
        }

        public int CreateStudent(Student student)
        {
            student.CreatedDate = DateTime.Now;
            student.UpdatedDate = DateTime.Now;
            var studentCreated = _dbContext.Students.Add(student);
            Save();
            return studentCreated.Id;
        }

        public void DeleteStudent(int id)
        {
            var studentToDelete = GetStudentById(id);
            _dbContext.Students.Remove(studentToDelete);
            Save();
        }

        public PagedList<Student> GetPagedList(PageContext<Student> pageContext)
        {
            throw new NotImplementedException();
        }

        //private IQueryable<Student> GetFilteredData(params Func<Student, bool>[] filters)
        //{
        //    IQueryable<Student> filteredStudents = _dbContext.Students.AsQueryable();

        //    for (int i = 0; i < filters.Length; i++)
        //    {
        //        filteredStudents = filteredStudents.Where(filters[i]);

        //    }
        //}

        //public PagedList<Student> GetPagedList(PageContext<Student> pageContext)
        //{

        //    if (pageContext == null) throw new ArgumentNullException("No page context has been set.");


        //    //apply filters
        //    pageContext.FiltersApplied.ForEach((student) =>
        //    {
        //        student()

        //    });


        //    _dbContext.Students.Where()

        //    int recordsToSkip = pageContext.PageIndex * pageContext.PageSize;
        //    int recordsToGet = pageContext.PageSize;

        //    IQueryable<Student> studentsRetrieved = _dbContext.Students.Skip(recordsToSkip).Take(recordsToGet);

        //    return new PagedList<Student> { }

        //}

        public Student GetStudentById(int id)
        {
            var student = _dbContext.Students.Find(id);
            return student;
        }

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetStudents()
        {
            return _dbContext.Students;
        }

        //public IEnumerable<Student> GetStudents(Expression<Func<Student, bool>> predicate)
        //{
        //    if (predicate != null)
        //        return _dbContext.Students.Where(predicate);
        //    return _dbContext.Students;
        //}

        //public IEnumerable<Student> GetStudents(Func<Student, bool> predicate = null, int pageIndex = 1, int pageSize = 10)
        //{
        //    Expression<Func<Student, bool>> filter = x => predicate(x);
        //    IEnumerable<Student> students = GetStudents(filter);


        //    return new PagedList<Student> { FiltersApplied =  }
        //}

        public void UpdateStudent(Student student)
        {
            _dbContext.Entry(student).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
