using MurekkepWeb.Models.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{


    [Table("Question")]
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(1000)]
        public string title { get; set; }
        public string body { get; set; }
        public List<TagOfQuestion> tags { get; set; }
        public virtual User asker { get; set; }

        public int vote { get; set; }
        public int viewCount { get; set; }
        public int answerCount { get; set; }

        public List<Answer> answers { get; set; }

        public DateTime CreateDateTime { get; set; }

        public Question()
        {
            answers = new List<Answer>();
            
        }


        public Question(int id)
        {
            this.GetQuestionAnswers();
            this.GetQuestionTags();
        }

        public void GetQuestionAnswers()
        {
            DataBaseContext db = new DataBaseContext();
            answers = db.Answers.Where(x => x.questionId == id).ToList();
        }

        public void GetQuestionTags()
        {
            DataBaseContext db = new DataBaseContext();
            tags  = db.TagOfQuestions.Where(x => x.questionId == id).ToList();

            foreach (var tagOfQuestion in tags)
            {
                tagOfQuestion.tag = db.Tags.First(c => c.id == tagOfQuestion.tag.id);
            }

      
        }





    }
}



//[DisplayName("Title"), Required(ErrorMessage = "Default yerine mesaj kullanmak {0} "), MinLength(5), MaxLength(300), DataType(DataType.Text)]
/*
 * /*[Range(1,100)]
   public int test { get; set; }

 * postta if model.asd != "asdd"
 * ModelState.addmodelerror("title", ""var bu")   
 */
