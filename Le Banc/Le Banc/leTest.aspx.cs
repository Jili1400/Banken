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
        //  rad 120 Session["listthistest"] = listThisTest;
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

            Label labelhedding = new Label();
            labelhedding.Text = "Test";
            PlaceHolderQuestions.Controls.Add(labelhedding);
            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));
            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));
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
                           

                            //int randomnr= GetRandomNr(listQuestion);
                            
                            //if (item.Id==randomnr)
                            //{
                           

                            Label labelNr = new Label();
                            labelNr.Text = nr.ToString()+". ";
                            Label labelquestion = new Label();
                            labelquestion.Text=item.TheQuestion;
                            Label labelGroup = new Label();
                            labelGroup.Text = "("+item.Group+")";

                            PlaceHolderQuestions.Controls.Add(labelNr);
                            PlaceHolderQuestions.Controls.Add(labelquestion);
                            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));

                            if (item.AmountOfRightAnswers==1)
                            {
                                 int rbnr = 0;
                                foreach (Answer svaret in item.ListAnswer)
                                {
                                    rbnr++;
                                    RadioButton radiobutton = new RadioButton();
                                    radiobutton.Text = svaret.Svar;
                                    radiobutton.ID= "n"+nr.ToString()+"r"+rbnr.ToString();
                                    radiobutton.GroupName = item.Id.ToString();
                                    //radiobutton.GroupName = nr.ToString();
                                
                                    PlaceHolderQuestions.Controls.Add(radiobutton);
                                    PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));
                                    TheTest questioninfo = new TheTest();
                                    questioninfo.Date = DateTime.Now;
                                    questioninfo.questionId = item.Id;
                                    //questioninfo.Testnr=.... ;

                                    listThisTest.Add(questioninfo);
                                }
                            }

                            else
                            {
                                Label labelAmountOfRightAnswers = new Label();
                                labelAmountOfRightAnswers.Text = "Fyll i " + item.AmountOfRightAnswers + " svar.";
                                PlaceHolderQuestions.Controls.Add(labelAmountOfRightAnswers);
                                PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));
                                int cbnr = 0;
                                foreach (Answer svaret in item.ListAnswer)
                                {
                                    cbnr++;
                                    CheckBox checkbox = new CheckBox();
                                    checkbox.Text = svaret.Svar;
                                    checkbox.ID = "n" + nr.ToString() + "c" + cbnr.ToString();

                                    PlaceHolderQuestions.Controls.Add(checkbox);
                                    PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));

                                    TheTest questioninfo = new TheTest();
                                    questioninfo.Date = DateTime.Now;
                                    questioninfo.questionId = item.Id;
                                    //questioninfo.Testnr=.... ;

                                    listThisTest.Add(questioninfo);
                                }
                            }

                            PlaceHolderQuestions.Controls.Add(labelGroup);
                            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));
                            PlaceHolderQuestions.Controls.Add(new LiteralControl("<br/>"));

                            Session["listthistest"] = listThisTest;

                            //thisTest.Date = DateTime.Now;
                            //thisTest.ListQuestion.Add(item);
                            //listThisTest.Add(question);
                        //}
                       
                    //}
                    //if (question.Group=="Ekonomi")
                    //{
                        
                    //}
                    //if (question.Group=="")  //här behöver vi skriva in det tredje värdet!!
                    //{
                     //   rlaklötaeklk
                    //}

                  //}
                }
                
            //}  
        }

        /// <summary>
        /// Metod som tar fram ett unikt random nr, vilket ligger i intervallet mellan 1 och analet frågor i listQuestion.
        /// </summary>
        /// <param name="listQuestion2"></param>
        //    private Int32 GetRandomNr(List<Question> listQuestion2)
        //{
        //    List<int> listrandnr = new List<Int32>();
        //    Random randnr = new Random();
        //    int randnrInt = Convert.ToInt32(randnr.Next(1, listQuestion2.Count));
        //    listrandnr.Add(randnrInt);
        //    foreach (int rand in listrandnr)
        //    {
        //        if (rand == randnrInt)
        //        {
        //          //  GetRandomNr(listQuestion2, listrandnr);
                    
        //        }
        //   }
        //   return randnrInt;
        //}


        /// <summary>
        /// Overload Metod som tar fram ett unikt random nr, vilket ligger i intervallet mellan 1 och analet frågor i listQuestion.
        /// </summary>
        /// <param name="listQuestion2"></param>
        /// <param name="listrandnr2"></param>
        //private bool GetRandomNr(List<Question> listQuestion2, List<int> listrandnr2)
        //{
        //    List<int> listrandnr = new List<int>();
        //    Random randnr = new Random();
            
        //    int randnrInt = Convert.ToInt32(randnr.Next(1, listQuestion2.Count));
        //    listrandnr.Add(randnrInt);
        //    foreach (int rand2 in listrandnr2)
        //    {
        //        if (rand2 == randnrInt)
        //        {
        //            //randomnumber = randnrInt;
        //            //GetRandomNr(listQuestion2, listrandnr2, out randnrInt);

        //        }
               
        //    }

        //   // randomnumber = randnrInt;
        //}

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
                //plocka fram ett random nummer på frågeid kolla vilken grupp.
                Question question = new Question();

                question.Id = Convert.ToInt32(nod.Attributes["id"].Value);
                question.TheQuestion = nod["question"].InnerText;
                question.Group = nod["group"].InnerText;
                question.AmountOfAnswers = Convert.ToInt32(nod["amountofanswers"].InnerText);
                question.AmountOfRightAnswers = Convert.ToInt32(nod["amountofrightanswers"].InnerText);
               
                question.ListAnswer = FillAnswersFromXmlTest(nod["answers"]);
                //if (question.AmountOfRightAnswers>1)
                //{
                question.ListRightAnswer = FillRightAnswerFromXmlTest(nod["rightanswers"]);
                //}
                //else if (question.AmountOfRightAnswers==1)
                //{
                //    question.RightAnswer = nod["rightanswer"].InnerText;
                //}
               
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
            private List<RightAnswer> FillRightAnswerFromXmlTest(XmlNode nod)
        {
         
            List<RightAnswer> listRightAnswers = new List<RightAnswer>();

            foreach (XmlNode rightAnswer in nod)
            {
                RightAnswer theRightAnswer = new RightAnswer();
                try
                {
                    theRightAnswer.RattSvar = rightAnswer.InnerText;
                }
                catch (Exception)
                {
                    //throw;
                }

                listRightAnswers.Add(theRightAnswer);
                //RightAnswer rightAnswer = new RightAnswer();
                //rightAnswer.RattSvar = rattSvar["rightanswer"].InnerText;
                //listRightAnswers.Add(rightAnswer);
                
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
            int sumTotal = 0;
            int sumEkonomi = 0;
            int sumEtik = 0;
            int sumProdukter= 0;

            //Radiobuttoncheck(sumTotal, sumEkonomi, sumEtik, sumProdukter);

            //List<CollectedAnswer> listhamtadeSvar = new List<CollectedAnswer>();
            //listhamtadeSvar = CollectAnswers();
            //List<RightAnswer> listRattaSvaren = new List<RightAnswer>();

            //List<TheTest> listtestet = Session["listthistest"] as List<TheTest>;
            //List<Question> listQuestion = FillQuestionFromXmlTest();

            //foreach (Question questionitem in listQuestion)
            //{
            //    int g = 0;
                //foreach (TheTest thetestitem in listtestet)
                //{
                    //for (int i = 0; i < questionitem.AmountOfRightAnswers ; i++)
                    //{
                        //foreach (RightAnswer rightansweritem in questionitem.ListRightAnswer)
                        //{
                        //    foreach (TheTest testitem in listtestet)
                        //    {
                        //        if (testitem.ToString()==rightansweritem.ToString())
                        //        {
                        //            g++;
                        //            //if (i==questionitem.AmountOfRightAnswers)
                        //            //{
                        //                if (g==questionitem.AmountOfRightAnswers)
                        //                {
                        //                    sumTotal++;
                        //                     if (questionitem.Group=="Produkter och hantering")
                        //                     {
                        //                         sumProdukter++;
                        //                     }
                        //                     else if (questionitem.Group == "Ekonomi")
                        //                     {
                        //                         sumEkonomi++;
                        //                     }
                        //                     else if (questionitem.Group == "Etik")
                        //                     {
                        //                         sumEtik++;
                        //                     }
                        //                //}
                        //            }
                        //        } 
                        //    }
                        //}
                    //}

                    //if (questionitem.Id == thetestitem.questionId)
                    //{
                    //    foreach (RightAnswer rightanswer in questionitem.ListRightAnswer)
                    //    { 
                    //        if (questionitem.AmountOfRightAnswers==1)
                    //        {
                            
                    //            if (rightanswer.RattSvar!= thetestitem.collectedAnswer)
                    //            {
                    //                return;                  
                    //            }
                    //            else
                    //            {
                    //                 SumTotal++;//nu får jag ju poäng för varje rightanswer även om det är fyra stycket i checkboxen.
                                
                    //                if (questionitem.Group=="Produkter och hantering")
                    //                {
                    //                    sumProdukter++;
                    //                }
                    //                else if (questionitem.Group == "Ekonomi")
                    //                {
                    //                    sumEkonomi++;
                    //                }
                    //                else if (questionitem.Group=="Etik")
                    //                {
                    //                    sumEtik++;
                    //                }
                                          
                    //            }
                               
                    //        }
                           
                    //    }
                    //}
                
    
            //Label1.Text = "Summa: " + sumTotal + " summaEtik: " + sumEtik + " summa Ekonomi: " + sumEkonomi + " summa produkter: " + sumProdukter;
            //Label1.Visible = true;

            //int lengthListQuestion=listQuestion.Count;
            //double total = sumTotal/listQuestion.Count;
            ////double product=sumProdukter/
            //if (sumTotal/listQuestion.Count> 0.7)
            //{
            //    Label1.Text = "Summa: "+sumTotal+" summaEtik: "+sumEtik+" summa Ekonomi: " +sumEkonomi+ " summa produkter: "+sumProdukter;
            //    Label1.Visible= true;
            //} 
        }


        /// <summary>
        /// Metod som hämtar hem information från Radiobutton, rättar svaret och ökar summan på provet.
        /// </summary>
        private void Radiobuttoncheck(int sumTotal, int sumEkonomi, int sumEtik, int sumProdukter)
        {
            foreach (Control control in PlaceHolderQuestions.Controls)
            {
                List<Question> xmlQuestionList = FillQuestionFromXmlTest();

                if (control is RadioButton)
                {
                    RadioButton radioknapp = new RadioButton();
                    if (radioknapp.Checked==true)
                    {
                        foreach (Question xmlquestion in xmlQuestionList)
	                    {
		                    if (xmlquestion.Id.ToString()==radioknapp.ID)
                            {
                                if (xmlquestion.RightAnswer==radioknapp.Text)
                                {
                                     sumTotal++;
                                             if (xmlquestion.Group=="Produkter och hantering")
                                             {
                                                 sumProdukter++;
                                             }
                                             else if (xmlquestion.Group == "Ekonomi")
                                             {
                                                 sumEkonomi++;
                                             }
                                             else if (xmlquestion.Group == "Etik")
                                             {
                                                 sumEtik++;
                                             }
                                }
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Metod som hämtar hem vilka radiobuttons och checkboxar som är ifyllda.
        /// </summary>

        private List<CollectedAnswer> CollectAnswers()
        {
            List<Question> listQuestion = FillQuestionFromXmlTest();
            List<CollectedAnswer> listCollectedAnswers = new List<CollectedAnswer>();
            //int n = 0;
            int p = 0;
            int nr1 =1;
            foreach (Control control in PlaceHolderQuestions.Controls)
            {
                //if (control is Label)
                //{
                //    Label labelnr = new Label();
                //    labelnr=(Label)control;
                //    if (labelnr.ID==p.ToString())
                //    {
                        
                //    }8
                //}
                

                //if (PlaceHolderQuestions.Controls.Contains(labelNr) == true)
                //{
                    //int n = Convert.ToInt32(PlaceHolderQuestions.Controls.ToString());

                    if (control is RadioButton)
                    {
                        //n++;
                        int r = 1;
                        //if (control.ID == "n" + n + "r" + r)
                        //{

                            RadioButton radio = new RadioButton();
                            radio = (RadioButton)control;

                            //while (radio.GroupName==nr1.ToString())
                            //{
                            //    for (int i = 0; i < length; i++)
                            //    {
                                    
                            //    }
                            //    if (radio.Checked == true)
                            //    {
                            //        CollectedAnswer collectedAnsw = new CollectedAnswer();
                            //        collectedAnsw.hamtatSvar = radio.Text;
                            //    //Label1.Text = radio.Text;
                            //    //Label1.Visible = true;
                            //        r++;
                            //        listCollectedAnswers.Add(collectedAnsw);
                            //    }
                            //}
                            nr1++;
                        
                        //}
                    }
                    ////////if (control is CheckBox)
                    ////////{
                    ////////   // n++;
                    ////////    int c = 1;
                    ////////    if (control.ID == "n" + n + "c" + c)
                    ////////    {
                    ////////        CheckBox box = new CheckBox();
                    ////////        box = (CheckBox)control;
                    ////////        CollectedAnswer collectedAnsw = new CollectedAnswer();
                    ////////        collectedAnsw.hamtatSvar = box.Text;
                    ////////        //Label1.Text = box.Text;
                    ////////        //Label1.Visible = true;
                    ////////        c++;
                    ////////        listCollectedAnswers.Add(collectedAnsw);
                    ////////    }
                    ////////}

                //}
                
            }
            return listCollectedAnswers;
            //string answer= PlaceHolderQuestions.FindControl(RadioButton);
        }
       

    }
}