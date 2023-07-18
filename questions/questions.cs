using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using questions;

namespace questions
{
    [Activity(Label = "questions")]
    public class QuestionActivity : Activity, Android.Views.View.IOnClickListener, ITriviaFunctions
    {
        Button btnq, btna1, btna2, btna3, btna4;
        TextView tvQuestion;
        TextView tvSol, tvStatus, tvPoints, tvFinish;
        int current;
        Question currentQuestion;
        Questions questions;
        int points = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.questions);
            // Create your application here
            questions = new Questions();
            tvQuestion = FindViewById<TextView>(Resource.Id.tvQuestion);
            btna1 = FindViewById<Button>(Resource.Id.btna1);
            btna2 = FindViewById<Button>(Resource.Id.btna2);
            btna3 = FindViewById<Button>(Resource.Id.btna3);
            btna4 = FindViewById<Button>(Resource.Id.btna4);

            btna1.SetOnClickListener(this);
            btna2.SetOnClickListener(this);
            btna3.SetOnClickListener(this);
            btna4.SetOnClickListener(this);

            tvStatus = FindViewById<TextView>(Resource.Id.tvStatus);
            tvPoints = FindViewById<TextView>(Resource.Id.tvPoints);

            tvFinish = FindViewById<TextView>(Resource.Id.tvFinish);
            tvFinish.Visibility = Android.Views.ViewStates.Invisible;
            initQuestions();
            nextQuestions();

        }
        public void initQuestions()
        {
            current = questions.getCurrent();//referance to current question
                                             // currentQuestion = questions.getQuestions().get(current);
        }
        public void nextQuestions()
        {
            if (current < questions.getQuestions().Count)
            {
                currentQuestion = questions.getQuestions()[current];
                tvQuestion.Text = currentQuestion.getQuestion();
                btna1.Text = currentQuestion.getA1();
                btna2.Text = currentQuestion.getA2();
                btna3.Text = currentQuestion.getA3();
                btna4.Text = currentQuestion.getA4();
                current++;
            }
            else
            {
                //To do finish game
                tvFinish.Visibility = Android.Views.ViewStates.Visible;

                this.savePoints();
                createDialog();
            }

        }


        public void isCorrectAnswer()
        {

        }

        public void OnClick(View v)
        {

            if (btna1 == v)
            {
                if (currentQuestion.getCorrect() == 0)
                {
                    points++;
                }
            }
            else if (btna2 == v)
            {
                if (currentQuestion.getCorrect() == 1)
                {
                    points++;

                }

            }
            else if (btna3 == v)
            {
                if (currentQuestion.getCorrect() == 2)
                {
                    points++;

                }
            }
            else if (btna4 == v)
            {
                if (currentQuestion.getCorrect() == 3)//number 3 - correct ansewr
                {
                    points++;
                }
            }
            if (current < questions.getQuestions().Count)
            {
                tvPoints.Text = "points :" + points;
                tvStatus.Text = "Question number :" + (current + 1);
            }
            nextQuestions();
        }
        public void savePoints()
        {
            ISharedPreferences sp = GetSharedPreferences("triv", 0);
            int max = sp.GetInt("points", 0);
            if (this.points > max)
            {
                var editor = sp.Edit();
                editor.PutInt("points", this.points);
                editor.Commit();

            }
        }

        public void createDialog()
        {
            CustomDialog customDialog = new CustomDialog(this);
            customDialog.Show();
        }

        public void resetGame()
        {
            this.points = 0;
            this.current = 0;
            tvPoints.Text = "points :" + points;
            tvStatus.Text = "Question number :" + (current + 1);
            this.nextQuestions();
        }

    }


    class Question
    {
        private String question, a1, a2, a3, a4;
        private String category;
        private int correct;

        public Question(String question, String a1, String a2, String a3, String a4, String category, int correct)
        {
            this.question = question;
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
            this.a4 = a4;
            this.category = category;
            this.correct = correct;
        }

        public String getQuestion()
        {
            return question;
        }

        public void setQuestion(String question)
        {
            this.question = question;
        }

        public String getA1()
        {
            return a1;
        }

        public void setA1(String a1)
        {
            this.a1 = a1;
        }

        public String getA2()
        {
            return a2;
        }

        public void setA2(String a2)
        {
            this.a2 = a2;
        }

        public String getA3()
        {
            return a3;
        }

        public void setA3(String a3)
        {
            this.a3 = a3;
        }

        public String getA4()
        {
            return a4;
        }

        public void setA4(String a4)
        {
            this.a4 = a4;
        }

        public String getCategory()
        {
            return category;
        }

        public void setCategory(String category)
        {
            this.category = category;
        }

        public int getCorrect()
        {
            return correct;
        }

        public void setCorrect(int correct)
        {
            this.correct = correct;
        }



    }


/**
 * Created by asafamir on 13/03/2017.
 */
    class Questions
    {
        public int current = 0;
        private List<Question> questions;

        public List<Question> getQuestions()
        {
            return questions;
        }

        public void setQuestions(List<Question> questions)
        {
            this.questions = questions;
        }

        public int getCurrent()
        {
            return current;
        }

        public void setCurrent(int current)
        {
            this.current = current;
        }



        public Questions()
        {
            questions = new List<Question>();
            Question q1 = new Question("1+10", "1", "11", "3", "100", "c", 1);
            Question q2 = new Question("1+2", "1", "2", "3", "100", "c", 2);
            Question q3 = new Question("1+3", "1", "2", "4", "100", "c", 2);
            Question q4 = new Question("1+4", "5", "2", "3", "100", "c", 0);

            Question q5 = new Question("12-11", "1", "11", "3", "100", "c", 1);
            Question q6 = new Question("14+2", "1", "16", "3", "100", "c", 1);
            Question q7 = new Question("15+3", "1", "2", "18", "100", "c", 2);
            Question q8 = new Question("16+4", "20", "2", "3", "100", "c", 0);

            Question q9 = new Question("1+10", "1", "11", "3", "100", "c", 1);
            Question q10 = new Question("13+2", "1", "2", "15", "100", "c", 2);
            Question q11 = new Question("16+3", "1", "2", "19", "100", "c", 2);
            Question q12 = new Question("15+4", "19", "12", "3", "100", "c", 0);

            questions.Add(q1);
            questions.Add(q2);
            questions.Add(q3);
            questions.Add(q4);
            //        questions.Add (q5);
            //        questions.Add (q6);
            //        questions.Add (q7);
            //        questions.Add (q8);
            //        questions.Add (q9);
            //        questions.Add (q10);
            //        questions.Add (q11);
            //        questions.Add (q12);



        }


    }


}