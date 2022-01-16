using MurekkepWeb.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models.ViewModel
{
    public class QuestionCreateViewModel
    {
        public Question question { get; set; }

        public List<TagOfQuestion> TagOfQuestions { get; set; }


        public QuestionCreateViewModel()
        {
            question = new Question();
            TagOfQuestions = new List<TagOfQuestion>();
        }
        public void GetAllTags()
        {
            DataBaseContext db = new DataBaseContext();
            List<Tag> tags = db.Tags.ToList();

            foreach (var tag in tags)
            {
                TagOfQuestion temp = new TagOfQuestion();
                temp.tag = tag;
                temp.checkedTag = false;
                TagOfQuestions.Add(temp);
            }
        }

    }
}