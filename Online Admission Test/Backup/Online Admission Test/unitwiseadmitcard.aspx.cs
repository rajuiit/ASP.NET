using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Online_Admission_Test
{
    public partial class unitwiseadmitcard : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["admissionConnectionString"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string tableExtension = DropDownList1.SelectedValue.ToLower();
            //for show data
            con.Open();
            string sql ="SELECT * FROM apply"+tableExtension+" inner join dbbl,student  where apply"+tableExtension+".mobile_no = dbbl.mobile_no and apply"+tableExtension+".tx_id = dbbl.tx_id  and student.ROLL_NO=dbbl.hsc_roll";

            //SELECT * FROM `student` WHERE `BOARD_NAME`='RAJSHAHI' and `ROLL_NO`= '135323' and `PASS_YEAR`='2011'
            MySqlCommand cmd = new MySqlCommand(sql, con);


            MySqlDataReader reader = cmd.ExecuteReader();


             //intialize page size
              //  var doc1 = new Document(PageSize.A4);
                var doc1 = new Document(new Rectangle(595f, 250f));
                // var doc1 = new Document(new iTextSharp.text.PageSize.LETTER, 20f, 20f,0,0);


                // Setting Document properties e.g.
                // 1. Title
                // 2. Subject
                // 3. Keywords
                // 4. Creator
                // 5. Author
                // 6. Header
                doc1.AddTitle("Admit Card for Admission Test.");
                doc1.AddSubject("This is an Example Admit Card for Admission Test.");
                doc1.AddKeywords("Metadata, iTextSharp 5.4.4, Admit Card, JU");
                doc1.AddCreator("Proshanti Solution Ltd.");
                doc1.AddAuthor("Sayed Mohsin Reza");
                doc1.AddHeader("Nothing", "No Header");





                //use a variable to let my code fit across the page...

                string path = Server.MapPath("PDFs");

                PdfWriter writer = PdfWriter.GetInstance(doc1, new FileStream(path + "/Doc2.pdf", FileMode.Create));
                //calling watermarks
                /* for (int i = 5; i >= 0; i--)
                 {
                     writer.PageEvent = new PDFWriterEvents("Institute of Information Technology, Jahangirnagar University", 10f, (i*100f), (i*75f), 30f);

                 }
                 */
                for (int i = 5; i >= 0; i--)
                {
                    writer.PageEvent = new PDFWriterEvents("Institute of Information Technology, Jahangirnagar University", 10f, (i * 100f), 100, 30f);

                }


                // calling PDFFooter class to Include in document
                // writer.PageEvent = new PDFFooter();
                doc1.Open();
            while(reader.Read())
            {
                string serial = reader.GetString(0).ToString();
                string name = reader.GetString(12).ToString();
                string fname = reader.GetString(13).ToString();
                string mname = reader.GetString(14).ToString();
                string hsc_roll = reader.GetString(17).ToString();
                string imgpath = reader.GetString(1).ToString()+"_"+reader.GetString(2).ToString()+".jpg";

                
                
               
                //for image
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/") + "julogo.GIF");
                gif.ScaleToFit(24f, 32f);
                gif.Alignment = iTextSharp.text.Image.ALIGN_LEFT | iTextSharp.text.Image.TEXTWRAP;
                gif.IndentationRight = 9f;
                gif.SpacingAfter = 9f;
                gif.Border = Rectangle.BOX;

                gif.BorderColor = iTextSharp.text.BaseColor.YELLOW;

                gif.BorderWidth = 5f;

                doc1.Add(gif);
                //end of image


                // string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\KINDEL.TTF";
                //for font
                string fontpath = Server.MapPath("~/font/") + "times.ttf";
                BaseFont basefont = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, true);
                //for end of font
                //set font size

                Font font4 = new iTextSharp.text.Font(basefont, 4, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                Font font4bold = new iTextSharp.text.Font(basefont, 4, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                Font font10bold = new iTextSharp.text.Font(basefont, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                Font font8 = new iTextSharp.text.Font(basefont, 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                Font font8bold = new iTextSharp.text.Font(basefont, 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                Font font6 = new iTextSharp.text.Font(basefont, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                Font font6bold = new iTextSharp.text.Font(basefont, 6, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE);

                Paragraph p = new Paragraph("Jahangirnagar University", font10bold);
                Paragraph pe = new Paragraph("Admission Test 2013-14.", font8);

                doc1.Add(p);
                doc1.Add(pe);


                //setting unit Name A -Unit
                Paragraph p1 = new Paragraph(DropDownList1.SelectedValue + " - UNIT Admit Card", font8bold);
                p1.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                doc1.Add(p1);


                //string date = DateTime.Now.Day.ToString();

                //for student image
                //Server.MapPath("~/Images/") +
                if (File.Exists(Server.MapPath("~/Images/") + imgpath))
                {

                    iTextSharp.text.Image studentpic =iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/") + imgpath);
                     studentpic.ScaleToFit(80f, 60f);
                studentpic.Alignment = iTextSharp.text.Image.ALIGN_RIGHT | iTextSharp.text.Image.TEXTWRAP;
                //studentpic.IndentationLeft = 9f;
                //studentpic.SpacingAfter = 9f;
                studentpic.Border = Rectangle.BOX;

                studentpic.BorderColor = iTextSharp.text.BaseColor.YELLOW;

                studentpic.BorderWidth = 5f;

                doc1.Add(studentpic);
                }
            else
                {
                     iTextSharp.text.Image studentpic =iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/") + "defaultpic.png");
                     studentpic.ScaleToFit(80f, 60f);
                studentpic.Alignment = iTextSharp.text.Image.ALIGN_RIGHT | iTextSharp.text.Image.TEXTWRAP;
                //studentpic.IndentationLeft = 9f;
                //studentpic.SpacingAfter = 9f;
                studentpic.Border = Rectangle.BOX;

                studentpic.BorderColor = iTextSharp.text.BaseColor.YELLOW;

                studentpic.BorderWidth = 5f;

                doc1.Add(studentpic);
                }
               
                //end of image





                Paragraph p3 = new Paragraph("Admission Test Roll No: " + serial, font6);
                p3.Alignment = iTextSharp.text.Image.ALIGN_LEFT;


                doc1.Add(p3);



                Paragraph p4 = new Paragraph("\nName :" + name.ToUpper() + " \nFather Name :" + fname.ToUpper() + " \nMother Name :" + mname.ToUpper(), font6);
                p4.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                doc1.Add(p4);

                string date = DateTime.Now.Day.ToString();
                /*
                            Paragraph p5 = new Paragraph(DateTime.Now.ToString(),font6bold);
                            p5.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                            doc1.Add(p5);
                            */



                Paragraph p6 = new Paragraph("\nNotice : \n1. To give admission exam, An examiner will be take the following things.\n     a) Admit Card     b) HSC Admit Card     c) HSCRegistration Card\n", font6);
                p6.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                doc1.Add(p6);

                //dean sign
                iTextSharp.text.Image din = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/") + DropDownList1.SelectedValue + ".jpg");
                din.ScaleToFit(45f, 15f);
                din.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
                //din.IndentationLeft = 15f;
                //din.SpacingAfter = 5f;
                din.Border = Rectangle.BOX;
                din.BorderColor = iTextSharp.text.BaseColor.WHITE;

                din.BorderWidth = 6f;

                doc1.Add(din);

                //end of dean sign


                Paragraph p7 = new Paragraph("2. The Admission Exam Seat schedule will be published before exam on the following link: http://www.juniv.edu \n3. Admission Seat Schedule and Result can be found by Mobile. As Example: TYPE <JU " + DropDownList1.SelectedValue + " " + hsc_roll + "> and SEND TO <16321>\n4. There is no need to sign on this paper. ", font6);
                p7.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                doc1.Add(p7);
                //Paragraph p7 = new Paragraph("Service By: Institute of Information Technology, Jahangirnagar University.", font8);
                //p7.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                //doc1.Add(p7);


                // Paragraph pic =new Paragraph();

                Paragraph dean = new Paragraph("\nSignature of Dean", font6);
                dean.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
                doc1.Add(dean);
                
                //doc1.NewPage();

            }
            reader.Close();
            con.Close();
            doc1.Close();
            //end show data
            Response.Redirect("~/PDFs/Doc2.pdf");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string tableExtension = DropDownList2.SelectedValue.ToLower();
            //for show data
            con.Open();
            string sql = "SELECT * FROM apply" + tableExtension + " inner join dbbl,student  where apply" + tableExtension + ".mobile_no = dbbl.mobile_no and apply" + tableExtension + ".tx_id = dbbl.tx_id  and student.ROLL_NO=dbbl.hsc_roll and apply"+tableExtension+".serialNo ='"+TextBox1.Text+"' ";

            //SELECT * FROM `student` WHERE `BOARD_NAME`='RAJSHAHI' and `ROLL_NO`= '135323' and `PASS_YEAR`='2011'
            MySqlCommand cmd = new MySqlCommand(sql, con);


            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string serial = reader.GetString(0).ToString();
                string name = reader.GetString(12).ToString();
                string fname = reader.GetString(13).ToString();
                string mname = reader.GetString(14).ToString();
                string hscroll = reader.GetString(17).ToString();
                string imgpath = reader.GetString(1).ToString() + "_" + reader.GetString(2).ToString() + ".jpg";
                createAdmitPDF a = new createAdmitPDF();
                a.createPDF(DropDownList2.SelectedValue, hscroll, serial, name, fname, mname, imgpath);
            }

            reader.Close();
            con.Close();
           
            //end show data
            Response.Redirect("~/PDFs/Doc2.pdf");
        }
    }
}