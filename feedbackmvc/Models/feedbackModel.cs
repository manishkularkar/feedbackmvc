using feedbackmvc.Data;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace feedbackmvc.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Feedback1 { get; set; }

        public string Savefeedbackfrom(FeedbackModel model)
        {
            var msg = "Data Saved Sucessfully!";
            ghrceEntities db = new ghrceEntities();
            var reg = db.feedbacks.Where(p => p.Id == model.Id).FirstOrDefault();
            if (model.Id == 0)
            {
                var data = new feedback()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Contact = model.Contact,
                    City = model.City,
                    Email = model.Email,
                    Feedback1 = model.Feedback1,

                };
                db.feedbacks.Add(data);
                db.SaveChanges();
            }
            else
            {
                reg.Id = model.Id;
                reg.Name = model.Name;
                reg.Contact = model.Contact;
                reg.City = model.City;
                reg.Email = model.Email;
                reg.Feedback1 = model.Feedback1;              
                db.SaveChanges();
                msg = "update successfully!";
            }
            return msg;
        }

        public List<FeedbackModel> Getlist()
        {
            ghrceEntities db = new ghrceEntities();
            List<FeedbackModel>lstfeedback = new List<FeedbackModel>();
            var data = db.feedbacks.ToList();
            if (data != null)
            {
                foreach (var Addfeedback in data)
                {
                    lstfeedback.Add(new FeedbackModel()
                    { 
                        Id = Addfeedback.Id,
                        Name = Addfeedback.Name,
                        Contact = Addfeedback.Contact,
                        City = Addfeedback.City,
                        Email = Addfeedback.Email,
                        Feedback1 = Addfeedback.Feedback1
                    });
                    
                }
               
            }
            return lstfeedback;
          
        }

        public string deletefeedback(int Id)
        {
            var msg = "delete successfully";
            ghrceEntities db = new ghrceEntities ();
            var data = db.feedbacks.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                db.feedbacks.Remove(data);
                db.SaveChanges();
            }
            return msg;

        }
        public FeedbackModel geteditbyId(int Id)
        {
            FeedbackModel model = new FeedbackModel();
            ghrceEntities db = new ghrceEntities();
            var data = db.feedbacks.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                model.Id = data.Id;
                model.Name = data.Name;
                model.Contact = data.Contact;
                model.City = data.City;
                model.Email = data.Email;
                model.Feedback1 = data.Feedback1;
            };
            return model;
        }

    }
}   