
using Data.Sql.Repository.Helper;
using Data.Sql.Sdo;
using Domain.Question.Abstract.Entity;
using Domain.Question.Abstract.Repository.Entity;
using Infrastructure.Common.Factory.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.Sql.Repository
{
    public class PrimaryQuestionRepository : IPrimaryQuestionRepository
    {


        IConfiguration _configuration;

        private readonly IFactoryProvider _factoryProvider;

        public PrimaryQuestionRepository(IConfiguration configuration, IFactoryProvider factoryProvider)
        {
            _configuration = configuration;
            _factoryProvider = factoryProvider;

        }

        public IEnumerable<IQuestionFromPrimaryStorage> QuestionsRead()
        {

            string connectionString = _configuration.GetConnectionString("SqlConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("usp_Questions_Read", conn))
                {

                    List<QuestionsSdo> questions = new List<QuestionsSdo>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        QuestionsSdo questionsSdo = new QuestionsSdo()
                        {
                            CourseId = Convert.ToInt32((dr["CourseId"]).ToString()),
                            QuestionId = dr["QuestionId"].ToString(),
                            Question = dr["Question"].ToString(),
                            Answer = dr["Answer"].ToString(),
                            Option1 = dr["Option1"].ToString(),
                            Option2 = dr["Option2"].ToString()
                        };
                        questions.Add(questionsSdo);
                    }

                    return questions.ToDomainQuestions(_factoryProvider);

                }


            }





        }

        public void DeleteQuestion(string questionId)
        {
            string connectionString = _configuration.GetConnectionString("SqlConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("usp_Questions_Delete @QuestionId", conn);

                cmnd.Parameters.AddWithValue("@QuestionId", questionId);
                cmnd.ExecuteNonQuery();

            }
        }

        public void AddQuestion(IQuestionFromPrimaryStorage questionToPrimary)
        {
            var question = questionToPrimary.ToSdo();

            string connectionString = _configuration.GetConnectionString("SqlConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmnd = new SqlCommand("usp_Questions_Insert @CourseId, @QuestionId, @Question, @Answer, @Option1, @Option2", conn);

                cmnd.Parameters.AddWithValue("@CourseId", question.CourseId);
                cmnd.Parameters.AddWithValue("@QuestionId", question.QuestionId);
                cmnd.Parameters.AddWithValue("@Question", question.Question);
                cmnd.Parameters.AddWithValue("@Option1", question.Option1);
                cmnd.Parameters.AddWithValue("@Option2", question.Option2);
                cmnd.Parameters.AddWithValue("@Answer", question.Answer);

                cmnd.ExecuteNonQuery();

            }


        }
    }
}





