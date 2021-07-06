using Data.Sql.Repository.Helper;
using Data.Sql.Sdo;
using Domain.Course.Abstract.Entity;
using Domain.Course.Abstract.Repository;
using Infrastructure.Common.Factory.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data.Sql
{
    
    
    public class CourseRepository:ICourseRepository
    {
        IConfiguration _configuration;
        private readonly IFactoryProvider _factoryProvider;
        public CourseRepository(IConfiguration configuration, IFactoryProvider factoryProvider)
        {
            _configuration = configuration;
            _factoryProvider = factoryProvider;
        }

        public IEnumerable<ICourse> ReadCourseList()
        {
            string connectionString = _configuration.GetConnectionString("SqlConnection");

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_CourseList_Read",conn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<CourseSdo> courseList = new List<CourseSdo>();
            while (dr.Read())
            {
                CourseSdo courseData = new CourseSdo()
                {
                    CourseId = Convert.ToInt32(dr["CourseId"].ToString()),
                    CourseName = dr["CourseName"].ToString(),
                    PassPercentage = Convert.ToInt32(dr["PassPercentage"].ToString())
                };

                courseList.Add(courseData);
            }
            return courseList.ToDomain(_factoryProvider);




        }


    }
}
