using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MurekkepWeb.Models;
using MurekkepWeb.Models.Managers;
using MurekkepWeb.Models.ViewModel;

namespace MurekkepWeb.Controllers
{
    public class QuestionsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Questions
        public async Task<ActionResult> Index()
        {
            return View(await db.Questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            QuestionCreateViewModel newQuestionCreateViewModel = new QuestionCreateViewModel();

            return View(newQuestionCreateViewModel);
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.question.CreateDateTime = DateTime.Now;
                db.Questions.Add(createViewModel.question);

                foreach (TagOfQuestion tagOfQuestion in createViewModel.TagOfQuestions)
                {
                    if (tagOfQuestion.checkedTag)
                    {
                        tagOfQuestion.questionId = createViewModel.question.id;
                        db.TagOfQuestions.Add(tagOfQuestion);
                    }
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(createViewModel);
        }

        // GET: Questions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,title,body")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Question question = await db.Questions.FindAsync(id);
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public PartialViewResult QuestionPartial()
        {

            List<Question> questions = new List<Question>();
            questions = db.Questions.ToList();

            return PartialView("QuestionPartial", questions);
        }



        public async Task<ActionResult> Q(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            question.viewCount = question.viewCount + 1;
            db.SaveChanges();
            question.GetQuestionAnswers();
            question.GetQuestionTags();
            if (question == null)
            {
                return HttpNotFound();
            }

            

            QuestionDetailViewModel questionDetailViewModel = new QuestionDetailViewModel();
            questionDetailViewModel.question = question;
            
            Answer answer = new Answer();
            questionDetailViewModel.newAnswer = answer;

           

            return View(questionDetailViewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Q(QuestionDetailViewModel questionDetailViewModel, int id)
        {

            Question question = await db.Questions.FindAsync(id);
            
            questionDetailViewModel.question = question;


            Answer answer = questionDetailViewModel.newAnswer;
            answer.questionId = id;
            answer.CreateDateTime = DateTime.Now;
            db.Answers.Add(answer);

            question.answerCount = question.answerCount + 1;

            db.SaveChanges();


            questionDetailViewModel.question.GetQuestionAnswers();
            questionDetailViewModel.newAnswer = new Answer();
            return View(questionDetailViewModel);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
