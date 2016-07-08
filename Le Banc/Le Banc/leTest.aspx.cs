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


        //metod där jag bygger upp testet
        private void BuildingTest()
        {
            TheTest thisTest = new TheTest();
            List<Question> listQuestion = FillQuestionFromXmlTest();
            List<TheTest> listThisTest = new List<TheTest>();
            
            foreach (Question question in listQuestion)
            {
                thisTest.Testnr = GetTestNr();

                if (thisTest.Testnr == 1) //här är testnumret 
                {
                    //string radNrQuestion = "";
                   // string radAnswer = "";
                    int nr = 0;

                    if (question.Group=="Produkter och hantering")
                    {  
                        foreach (Question item in listQuestion)
                        {
                            nr++;
                            
                            Label labelquestion = new Label();
                            labelquestion.Text=item.TheQuestion;

                            PlaceHolderQuestions.Controls.Add(labelquestion);
                            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));

                            //radNrQuestion += "<tr><td>" + nr + "</td><td>" + question.TheQuestion + "</td></tr>";
                            foreach (Answer answer in question.ListAnswer)
                            {
                                RadioButton radiobutton = new RadioButton();
                                radiobutton.Text = answer.Svar;
                                radiobutton.ID=nr.ToString();
                                
                                //radNrQuestion += "<tr><td>" + answer + "</td><td>";
                              PlaceHolderQuestions.Controls.Add(radiobutton);
                              PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));
                            }
                            
                            

                            //thisTest.Date = DateTime.Now;
                            //thisTest.ListQuestion.Add(question);
                            //listThisTest.Add(question);
                        }
                        //Label1.Text = "<table>" + radNrQuestion + "</table>";
                        Label1.Visible = true;

                    }
                    if (question.Group=="Ekonomi")
                    {
                        
                    }
                    //if (question.Group=="")  //här behöver vi skriva in det tredje värdet!!
                    //{
                     //   rlaklötaeklk
                    //}
                }
                
            }  
        }


        //public static Control findControl(Control );

        //metod som fyller på vilket testnummer det är från databasen
        private int GetTestNr()
        {
            //här måste jag bygga en metod som hämtar hem, vilket test det är i ordningen, från databasen.
            return 1;  //just nu är det alltid test 1, detta måste ändras!!!!
        }

        
        //metod som fyller question
        private List<Question> FillQuestionFromXmlTest()
        {
            string xmlfil = Server.MapPath("test.xml");
            XmlDocument xml = new XmlDocument();

            xml.Load(xmlfil);

            XmlNodeList lista = xml.SelectNodes("test/testquestion");
            List<Question> listQuestions = new List<Question>();
            //string nyRad;
            //nyRad = "<tr><td>Företag</td><td>Köppris(SKr)</td><td>Säljpris(SKr)</td><td>Aktieslag</td><td>Börslista</td></tr>";
            foreach (XmlNode nod in lista)
            {
                Question question = new Question();

                question.Id = Convert.ToInt32(nod.Attributes["id"].Value);
                question.TheQuestion = nod["question"].InnerText;
                question.Group = nod["group"].InnerText;
                question.AmountOfAnswers = Convert.ToInt32(nod["amountofanswers"].InnerText);
                question.AmountOfRightAnswers = Convert.ToInt32(nod["amountofrightanswers"].InnerText);

                question.ListAnswer = FillAnswersFromXmlTest(question.Id);
                question.ListRightAnswer = FillRightAnserFromXmlTest();

                listQuestions.Add(question);

                //Session["listQuestion"] = listQuestions;
                
                
            }

            return listQuestions;
        }


        //metod som fyller answers från test.xml
        private List<Answer> FillAnswersFromXmlTest(int questionId)  //får just nu bara ut frågor som gäller id1, men tar jag bort ifsatsen försvinner alla answers.
        {
            string xmlfil = Server.MapPath("test.xml");
            XmlDocument xml = new XmlDocument();

            xml.Load(xmlfil);

            XmlNodeList xmlAnswers = xml.SelectNodes("test/testquestion/answers");
            XmlNodeList xmlAnswer = xml.SelectNodes("test/testquestion/answers/answer");
            List<Answer> listAnswers = new List<Answer>();
            //int questionId2 = questionId;
        int no = 0;
            foreach (XmlNode answers in xmlAnswers)
            {
                foreach (XmlNode svaret in xmlAnswer)
                {
                     int check = Convert.ToInt32(answers.ParentNode.Attributes["id"].Value);
                
                if (questionId== check)
               // while (check==questionId)
                 //if (questionId == Convert.ToInt32(nod.Attributes["id"].Value))
                {   
                    no++;
		            Answer answer = new Answer();
                    try
                    {
                         answer.Svar = answers["answer"+no].InnerText;
                    }
                    catch (Exception)
                    {
                        //throw;
                        
                    }    
                       
                    
                    
                    listAnswers.Add(answer);
                }
                }
               
               
           }
           
            return listAnswers;
        }


        //metod som fyller rightanswers från test.xml
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

        protected void ButtonLamnaIn_Click(object sender, EventArgs e)
        {
            //RadioButton radiobutton = new RadioButton();
            //string test = PlaceHolderQuestions.
        }

        //metod där jag hämtar hem alla frågor från xml
        //private List<Question> catchQuestionFromXml()
        //{
        //    List<Question> listQuestions = new List<Question>();
        //    return listQuestions;
        //}

    }
}