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
        public EducationVO Insert(EducationContext ctx, EducationVO model)
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

        public void Update(EducationContext ctx, EducationVO model)
        {
            try
            {
                ctx.Entry(model).State = EntityState.Modified;
                ctx.Educations.Attach(model);
                ctx = UpdateProperties(model, ctx);
                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                                 Id = edu.Id,
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
                        Id = FillItemForDatabase.FillItem(edu.Id),
                        Degree = FillItemForDatabase.FillItem(edu.Degree),
                        School = FillItemForDatabase.FillItem(edu.School),
                        Department = FillItemForDatabase.FillItem(edu.Department),
                        StartYear = FillItemForDatabase.FillItem(edu.StartYear),
                        GraduationYear = FillItemForDatabase.FillItem(edu.GraduationYear),
                        Grade = FillItemForDatabase.FillItem(edu.Grade),
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

        public EducationVO FindEducationById(int id, EducationContext ctx)
        {
            EducationVO model = new EducationVO();
            try
            {
                var query = (from edu in ctx.Educations.AsEnumerable()
                             where edu.Id == id
                             select new EducationVO
                             {
                                 Id = edu.Id,
                                 MemberId = edu.MemberId,
                                 Degree = edu.Degree,
                                 School = edu.School,
                                 Department = edu.Department,
                                 StartYear = edu.StartYear,
                                 GraduationYear = edu.GraduationYear,
                                 Grade = edu.Grade
                             }).Single();

                model.Id = FillItemForDatabase.FillItem(query.Id);
                model.MemberId = FillItemForDatabase.FillItem(query.MemberId);
                model.Degree = FillItemForDatabase.FillItem(query.Degree);
                model.School = FillItemForDatabase.FillItem(query.School);
                model.Department = FillItemForDatabase.FillItem(query.Department);
                model.StartYear = FillItemForDatabase.FillItem(query.StartYear);
                model.GraduationYear = FillItemForDatabase.FillItem(query.GraduationYear);
                model.Grade = FillItemForDatabase.FillItem(query.Grade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        private EducationContext UpdateProperties(EducationVO model, EducationContext ctx)
        {
            try
            {
                ctx.Entry(model).Property("Degree").IsModified = UpdateItemToDatabasecs.Item(model.Degree);
                ctx.Entry(model).Property("School").IsModified = UpdateItemToDatabasecs.Item(model.School);
                ctx.Entry(model).Property("Department").IsModified = UpdateItemToDatabasecs.Item(model.Department);
                ctx.Entry(model).Property("Grade").IsModified = UpdateItemToDatabasecs.Item(model.Grade);
                ctx.Entry(model).Property("StartYear").IsModified = UpdateItemToDatabasecs.Item(model.StartYear);
                ctx.Entry(model).Property("GraduationYear").IsModified = UpdateItemToDatabasecs.Item(model.GraduationYear);
                ctx.Entry(model).Property("CreatedDate").IsModified = UpdateItemToDatabasecs.Item(model.CreatedDate);
                ctx.Entry(model).Property("MemberId").IsModified = UpdateItemToDatabasecs.Item(model.MemberId);
                ctx.Entry(model).Property("ModifiedDate").IsModified = UpdateItemToDatabasecs.Item(model.ModifiedDate);
            }
            catch
            {
                throw;
            }
            return ctx;
        }
    }
}