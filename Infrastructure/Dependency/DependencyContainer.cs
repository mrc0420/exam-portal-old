using Data.Mongo;
using Data.Sql;
using Data.Sql.Repository;
using Domain.Course.Abstract.Entity;
using Domain.Course.Abstract.Repository;
using Domain.Course.Abstract.Service;
using Domain.Course.Entity;
using Domain.Course.Service;
using Domain.Question.Abstract.Document;
using Domain.Question.Abstract.Entity;
using Domain.Question.Abstract.Repository.Document;
using Domain.Question.Abstract.Repository.Entity;
using Domain.Question.Abstract.Service;
using Domain.Question.Document;
using Domain.Question.Entity;
using Domain.Question.Service;
using Infrastructure.Common.Factory;
using Infrastructure.Common.Factory.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dependency
{
  public static class DependencyContainer
    {
        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IPrimaryQuestionRepository, PrimaryQuestionRepository>();
            services.AddScoped<ISecondaryQuestionRepository, SecondaryQuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddTransient<IQuestionFromPrimaryStorage, QuestionFromPrimaryStorage>();
            services.AddTransient<IQuestionFromSecondaryStorage, QuestionFromSecondaryStorage>();
            services.AddTransient<IFactoryProvider, FactoryProvider>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourse, Course>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            



        }


    }
}
