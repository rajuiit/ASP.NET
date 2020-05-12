using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Online_Admission_Test
{
    public class createAdmitPDF : System.Web.UI.Page
    {
        public void createPDF(string unitName,string rollNo,string serialNo,string studentName,string fatherName,string motherName,string studentImgPath)
        {
            //intialize page size
            //var doc = new Document(PageSize.A5);
            //  var doc1 = new Document(new Rectangle(595f,421f));
            var doc1 = new Document(new Rectangle(PageSize.A5.Rotate()));


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
               writer.PageEvent = new PDFWriterEvents("Institute of Information Technology, Jahangirnagar University", 10f, (i * 100f), 200, 30f);

           }
           
            
            // calling PDFFooter class to Include in document
            // writer.PageEvent = new PDFFooter();
            doc1.Open();
            //for image
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/") + "julogo.GIF");
            gif.ScaleToFit(50f, 50f);
            gif.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_LEFT;
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
            Font font16 = new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Font font16bold = new iTextSharp.text.Font(basefont, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            Font font14bold = new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            Font font6 = new iTextSharp.text.Font(basefont, 6, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Font font14 = new iTextSharp.text.Font(basefont, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Font font12 = new iTextSharp.text.Font(basefont, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Font font10 = new iTextSharp.text.Font(basefont, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            Font font8 = new iTextSharp.text.Font(basefont, 8, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLUE);

            Paragraph p = new Paragraph("Jahangirnagar University", font14bold);
            Paragraph pe = new Paragraph("Admission Test 2013-14.", font12);

            doc1.Add(p);
            doc1.Add(pe);
            

            //setting unit Name A -Unit
            Paragraph p1 = new Paragraph(unitName+" - UNIT", font16bold);
            p1.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            doc1.Add(p1);

            Paragraph p2 = new Paragraph("Admit Card", font14bold);
            p2.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

            doc1.Add(p2);
            //string date = DateTime.Now.Day.ToString();

            //for student image
            //Server.MapPath("~/Images/") +
            iTextSharp.text.Image studentpic = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/") + studentImgPath);
            studentpic.ScaleToFit(80f, 100f);
            studentpic.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
            studentpic.IndentationLeft = 9f;
            studentpic.SpacingAfter = 9f;
            studentpic.Border = Rectangle.BOX;

            studentpic.BorderColor = iTextSharp.text.BaseColor.YELLOW;

            studentpic.BorderWidth = 5f;

            doc1.Add(studentpic);
            //end of image

            




            Paragraph p3 = new Paragraph("Roll No:"+rollNo+"                    Serial No: "+serialNo, font12);
            p3.Alignment = iTextSharp.text.Image.ALIGN_LEFT | iTextSharp.text.Image.TEXTWRAP;


            doc1.Add(p3);



            Paragraph p4 = new Paragraph("\nName :" + studentName.ToUpper() + " \nFather Name :" + fatherName.ToUpper() + " \nMother Name :" + motherName.ToUpper(), font12);

            doc1.Add(p4);

            string date = DateTime.Now.Day.ToString();

            Paragraph p5 = new Paragraph(DateTime.Now.ToString());
            p5.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            doc1.Add(p5);
            Paragraph p6 = new Paragraph("\nNotice : \n1. To give admission exam, An examiner will be take the following things.\n     a) Admit Card     b) HSC Admit Card     c) HSCRegistration Card\n2. The Admission Exam Seat schedule will be published before exam on the following link: http://www.juniv.edu \n3. Admission Seat Schedule and Result can be found by Mobile. As Example: TYPE <JU "+unitName+" "+rollNo+"> and SEND TO <16321>\n4. There is no need to sign on this paper. ", font10);
            p6.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            doc1.Add(p6);
            ////dean sign
            //iTextSharp.text.Image din = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/") + unitName + ".jpg");
            //din.ScaleToFit(45f, 15f);
            //din.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
            ////din.IndentationLeft = 15f;
            ////din.SpacingAfter = 5f;
            //din.Border = Rectangle.BOX;
            //din.BorderColor = iTextSharp.text.BaseColor.WHITE;

            //din.BorderWidth = 6f;

            //doc1.Add(din);

            //end of dean sign

           

            Paragraph p7 = new Paragraph("Service By: Institute of Information Technology, Jahangirnagar University.", font8);
            p7.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            doc1.Add(p7);

            //Paragraph dean = new Paragraph("\nSignature of Dean", font6);
            //dean.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            //doc1.Add(dean);

            doc1.Close();
           
        
        }
    }
}