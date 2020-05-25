using Physiotherapy.Context;
using Physiotherapy.IDA;
using Physiotherapy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Physiotherapy.DAL
{
    public class EducationDA : IEducationDA
    {
        public EducationVO Save(EducationVO model, EducationContext ctx)
        {
            try
            {
                ctx.Educations.Add(model);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }


        public List<EducationVO> FindEducationsByMemberId(int memberId, EducationContext ctx)
        {
            List<EducationVO> model = new List<EducationVO>();
            try
            {
                var query = (from edu in ctx.Educations.AsEnumerable()
                                   where edu.MemberId == memberId
                                   select new EducationVO
                                   {
                                       Degree = edu.Degree,
                                       School = edu.School,
                                       Department = edu.Department,
                                       StartYear = edu.StartYear,
                                       GraduationYear = edu.GraduationYear,
                                       Grade = edu.Grade
                                   }).ToList();

                foreach (EducationVO edu in query)
                {
                    EducationVO education = new EducationVO()
                    {
                        Degree = edu.Degree.Equals(DBNull.Value) ? null : (string)edu.Degree,
                        School = edu.School.Equals(DBNull.Value) ? null : (string)edu.School,
                        Department = edu.Department.Equals(DBNull.Value) ? null : (string)edu.Department,
                        StartYear = edu.StartYear.Equals(DBNull.Value) ? null : (string)edu.StartYear,
                        GraduationYear = edu.GraduationYear.Equals(DBNull.Value) ? null : (string)edu.GraduationYear,
                        Grade = edu.Grade.Equals(DBNull.Value) ? 0 : (decimal)edu.Grade,
                    };
                    model.Add(education);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}