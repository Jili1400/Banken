using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Le_Banc
{
    public partial class leTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           BuildingTest();
        }


        /// <summary>
        /// Metod som bygger upp testet.
        /// </summary>

        private void BuildingTest()
        {
            TheTest thisTest = new TheTest();
            List<Question> listQuestion = FillQuestionFromXmlTest();
            List<TheTest> listThisTest = new List<TheTest>();
            
            //foreach (Question question in listQuestion)
            //{
            //    thisTest.Testnr = GetTestNr();

            //    if (thisTest.Testnr == 1) //här är testnumret 
            //    {
            //        string radNrQuestion = "";
            //        string radAnswer = "";
                   int nr = 0;

                    //if (question.Group=="Produkter och hantering")
                    //{  
                        foreach (Question item in listQuestion)
                        {
                            nr++;

                            Label labelNr = new Label();
                            labelNr.Text = nr.ToString()+". ";
                            Label labelquestion = new Label();
                            labelquestion.Text=item.TheQuestion;
                            Label labelGroup = new Label();
                            labelGroup.Text = item.Group;

                            PlaceHolderQuestions.Controls.Add(labelNr);
                            PlaceHolderQuestions.Controls.Add(labelquestion);
                            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));
                            PlaceHolderQuestions.Controls.Add(labelGroup);
                            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));


                            int rbnr = 0;
                            foreach (Answer svaret in item.ListAnswer)
                            {
                                rbnr++;
                                RadioButton radiobutton = new RadioButton();
                                radiobutton.Text = svaret.Svar;
                                radiobutton.ID= "n"+nr.ToString()+"r"+rbnr.ToString();
                                
                              PlaceHolderQuestions.Controls.Add(radiobutton);
                              PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));

                            }

                            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));

                            //thisTest.Date = DateTime.Now;
                            //thisTest.ListQuestion.Add(question);
                            //listThisTest.Add(question);
                        //}
                        //Label1.Text = "<table>" + radNrQuestion + "</table>";
                       // Label1.Visible = true;

                    //}
                    //if (question.Group=="Ekonomi")
                    //{
                        
                    //}
                    //if (question.Group=="")  //här behöver vi skriva in det tredje värdet!!
                    //{
                     //   rlaklötaeklk
                    //}
                }
                
            //}  
        }


        //public static Control findControl(Control );

        //metod som fyller på vilket testnummer det är från databasen
        private int GetTestNr()
        {
            //här måste jag bygga en metod som hämtar hem, vilket test det är i ordningen, från databasen.
            return 1;  //just nu är det alltid test 1, detta måste ändras!!!!
        }

        
        /// <summary>
        /// Metod som fyller question(info om varje fråga) från xml.
        /// </summary>
        /// <returns> lista med questions </returns>

        private List<Question> FillQuestionFromXmlTest()
        {
            string xmlfil = Server.MapPath("test.xml");
            XmlDocument xml = new XmlDocument();

            xml.Load(xmlfil);

            XmlNodeList lista = xml.SelectNodes("test/testquestion");
            List<Question> listQuestions = new List<Question>();
          
            foreach (XmlNode nod in lista)
            {
                Question question = new Question();

                question.Id = Convert.ToInt32(nod.Attributes["id"].Value);
                question.TheQuestion = nod["question"].InnerText;
                question.Group = nod["group"].InnerText;
                question.AmountOfAnswers = Convert.ToInt32(nod["amountofanswers"].InnerText);
                question.AmountOfRightAnswers = Convert.ToInt32(nod["amountofrightanswers"].InnerText);

                question.ListAnswer = FillAnswersFromXmlTest(nod["answers"]);
                question.ListRightAnswer = FillRightAnserFromXmlTest();
                listQuestions.Add(question);

                //Session["listQuestion"] = listQuestions;
            }

            return listQuestions;
        }


        /// <summary>
        /// metod som fyller answers från test.xml
        /// </summary>
        /// <param name="nod"></param>
        /// <returns>lista med svarsalternativ</returns>

        private List<Answer> FillAnswersFromXmlTest(XmlNode nod)  
        {   
            List<Answer> listAnswers = new List<Answer>();
          
            foreach (XmlNode answer in nod)
            {
                            Answer theanswer= new Answer();
                            try
                            {
                                theanswer.Svar=  answer.InnerText;   
                            }
                            catch (Exception)
                            {
                                //throw;
                            }    
                                           
                            listAnswers.Add(theanswer);
             }
      
            return listAnswers;
        }


        /// <summary>
        /// Metod som fyller rightanswers från test.xml
        /// </summary>
        /// <returns>Returnerar lista med de rätta svaren.</returns>
        private List<RightAnswer> FillRightAnserFromXmlTest()
        {
            string xmlfil = Server.MapPath("test.xml");
            XmlDocument xml = new XmlDocument();

            xml.Load(xmlfil);

            XmlNodeList lista = xml.SelectNodes("test/testquestion");
            List<RightAnswer> listRightAnswers = new List<RightAnswer>();

            foreach (XmlNode nod in lista)
            {
                RightAnswer rightAnswer = new RightAnswer();
                rightAnswer.RattSvar = nod["rightanswer"].InnerText;
                listRightAnswers.Add(rightAnswer);
                
            }

            return listRightAnswers;
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //}

        /// <summary>
        /// Knapp som .... 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonLamnaIn_Click(object sender, EventArgs e)
        {
            CollectRbAnswers();
        }
            
        /// <summary>
        /// Metod som hämtar hem vilka radiobuttons och checkboxar som är ifyllda.
        /// </summary>

        private void CollectRbAnswers()
        {
           
            int n = 0;
            foreach (Control control in PlaceHolderQuestions.Controls)
            {
                if (control is RadioButton)
                {
                    n++;
                int r = 1;
                if (control.ID == "n"+n+"r"+r)
                    {
                        RadioButton radio =new RadioButton();
                        radio = (RadioButton)control;
                        Label1.Text = radio.Text;
                        Label1.Visible = true;
                        r++;
                    }
                }
                if(control is CheckBox)
                {
                    n++;
                    int c = 1;
                    if (control.ID == "n" + n + "c" + c)
                    {
                        CheckBox box = new CheckBox();
                        box = (CheckBox)control;
                        Label1.Text = box.Text;
                        Label1.Visible = true;
                        c++;
                    }
                }
            }
            //string answer= PlaceHolderQuestions.FindControl(RadioButton);
        }
       

    }
}