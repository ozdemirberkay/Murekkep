using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models.ViewModel
{
    public class QuestionDetailViewModel
    {
        public Question question { get; set; }

        public Answer newAnswer { get; set; }
    }
}