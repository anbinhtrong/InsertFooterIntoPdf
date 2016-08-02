using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InsertImageIntoPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfpath = "";

            string imagepath = "Images";

            var doc = new Document();
            var stream = new MemoryStream();
            //var writer = PdfWriter.GetInstance(doc, stream);
            try
            {

                var writer = PdfWriter.GetInstance(doc, new FileStream(pdfpath + "Images.pdf", FileMode.Create));

                doc.Open();
                var partner = new Partner
                {
                    Title1 = "Title1",
                    Title2 = "Title 2",
                    Description1 =
                        "Lý Đăng Huy (李登輝 bính âm: Lǐ Dēnghuī; sinh ngày 15 tháng 1 năm 1923) là một chính trị gia của Trung Hoa Dân Quốc (thường được gọi là Đài Loan), đảng viên Quốc Dân Đảng. Ông là Tổng thống Trung Hoa Dân Quốc trong các nhiệm kỳ thứ 7 (thay Tưởng Kinh Quốc qua đời), 8, 9 của Trung Hoa Dân Quốc giai đoạn 1988-2000. Ông chủ trì một số tiến bộ lớn trong cải cách dân chủ bao gồm cả cuộc bầu cử lại chính bản thân vị trí Tổng thống mà ông đang giữ, đánh dấu cuộc bầu cử tổng thống trực tiếp đầu tiên cho Trung Hoa Dân Quốc. Là người bản địa Đài Loan đầu tiên làm Tổng thống Trung Hoa Dân Quốc cũng như chủ tịch Quốc dân Đảng, Lý Đăng Huy thúc đẩy phong trào bản địa hóa Đài Loan, dẫn đầu một chính sách ngoại giao tích cực để có các đồng minh. Những người chỉ trích cáo buộc ông phản bội đảng ông mà ông làm chủ tịch, hỗ trợ bí mật cho việc Đài Loan độc lập, và liên quan đến tham nhũng (chính trị vàng đen).",
                    Description2 =
                        "Lý Đăng Huy (李登輝 bính âm: Lǐ Dēnghuī; sinh ngày 15 tháng 1 năm 1923) là một chính trị gia của Trung Hoa Dân Quốc (thường được gọi là Đài Loan), đảng viên Quốc Dân Đảng. Ông là Tổng thống Trung Hoa Dân Quốc trong các nhiệm kỳ thứ 7 (thay Tưởng Kinh Quốc qua đời), 8, 9 của Trung Hoa Dân Quốc giai đoạn 1988-2000. Ông chủ trì một số tiến bộ lớn trong cải cách dân chủ bao gồm cả cuộc bầu cử lại chính bản thân vị trí Tổng thống mà ông đang giữ, đánh dấu cuộc bầu cử tổng thống trực tiếp đầu tiên cho Trung Hoa Dân Quốc. Là người bản địa Đài Loan đầu tiên làm Tổng thống Trung Hoa Dân Quốc cũng như chủ tịch Quốc dân Đảng, Lý Đăng Huy thúc đẩy phong trào bản địa hóa Đài Loan, dẫn đầu một chính sách ngoại giao tích cực để có các đồng minh. Những người chỉ trích cáo buộc ông phản bội đảng ông mà ông làm chủ tịch, hỗ trợ bí mật cho việc Đài Loan độc lập, và liên quan đến tham nhũng (chính trị vàng đen).",
                        PackcopyBlock1 = imagepath + "/CrossGame.jpg",
                        PackcopyBlock2 = imagepath + "/tuyet-ding_28303650811_o.jpg",

                };
                var tscPackingSlipFooter = GenerateTscPackingSlipFooter(partner, doc);
                AddNewFooter(tscPackingSlipFooter, writer);
                #region body
                
                var r = new Random();
                PdfPTable table = new PdfPTable(3);

                PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"))
                {
                    Colspan = 3,
                    HorizontalAlignment = 1
                };


                //0=Left, 1=Centre, 2=Right

                table.AddCell(cell);

                table.AddCell("Col 1 Row 1");

                table.AddCell("Col 2 Row 1");

                table.AddCell("Col 3 Row 1");

                table.AddCell("Col 1 Row 2");

                table.AddCell("Col 2 Row 2");

                table.AddCell("Col 3 Row 2");
                doc.Add(table);
                var footerHeight = tscPackingSlipFooter.TotalHeight + 10f;
                for (var i = 0; i <= 100; i++)
                {
                    table = new PdfPTable(3);
                    table.AddCell(r.Next(1, 100).ToString());

                    table.AddCell(r.Next(1, 100).ToString());

                    table.AddCell(r.Next(1, 100).ToString());
                    
                    doc.Add(table);
                    var y = writer.GetVerticalPosition(true);
                    if (i > 0 && y - footerHeight < 24)
                    {
                        AddNewFooter(tscPackingSlipFooter, writer);
                        doc.NewPage();
                    }
                }

                AddNewFooter(tscPackingSlipFooter, writer);
                
                #endregion


                //doc.Add(new Paragraph("GIF"));

                //var gif = Image.GetInstance(imagepath + "/P_20151115_200107.jpg");
                //gif.ScaleToFit(377, 182);
                //doc.Add(gif);
                //gif = Image.GetInstance(imagepath + "/CrossGame.jpg");
                //gif.ScaleToFit(377, 182);
                //doc.Add(gif);
                //doc.Add(new Paragraph("Height = 240"));
                //gif = Image.GetInstance(imagepath + "/P_20151115_200107.jpg");
                //gif.ScaleAbsoluteHeight(182);
                //doc.Add(gif);
                //doc.Add(new Paragraph("Weight = 320"));
                //gif = Image.GetInstance(imagepath + "/P_20151115_200107.jpg");
                //gif.ScaleAbsoluteWidth(372);
                //doc.Add(gif);

                
            }

            catch (Exception ex)
            {

                //Log error;

            }

            finally
            {

                doc.Close();

            }

 
        }

        private static void AddNewFooter(PdfPTable footerLTable, PdfWriter pdfWriter)
        {
            #region new footer
            footerLTable.WriteSelectedRows(0, -1, 5f, footerLTable.TotalHeight + 10f, pdfWriter.DirectContent);
            #endregion
        }

        private static PdfPTable GenerateTscPackingSlipFooter(Partner partner, Document document)
        {
            #region new footer

            var footerLabel = new PdfPTable(2)
            {
                WidthPercentage = 100f
            };
            var newWith = new[] { 50f, 50f };
            footerLabel.SetWidths(newWith);
            //--add copy pack 1
            Phrase phrase1;
            var baseFontTimesRoman = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            var normalFont = new Font(baseFontTimesRoman, 10, Font.NORMAL);
            var boldFont = new Font(baseFontTimesRoman, 10, Font.BOLD);

            var exampleBound = new ImageFrameRectangle(251, 182);
            if (!string.IsNullOrEmpty(partner.PackcopyBlock1))
            {
                var packCopyPack = Image.GetInstance(partner.PackcopyBlock1);
                //packCopyPack.ScaleAbsolute(251, 182);
                var imageSize1 = new ImageFrameRectangle(packCopyPack.Width, packCopyPack.Height);
                var newRec = ExpandToBound(imageSize1, exampleBound);//CalculateNewRectangle(packCopyPack);
                //packCopyPack.ScaleAbsolute(newWith1, 182);
                packCopyPack.ScaleAbsolute(newRec.Width, newRec.Height); 
                var footerCell = new PdfPCell(packCopyPack)
                {
                    PaddingRight = 10f,
                    BorderWidth = 0,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                footerLabel.AddCell(footerCell);
            }
            else
            {
                if (!string.IsNullOrEmpty(partner.Title1))
                {
                    phrase1 = new Phrase
                            {
                                new Chunk(partner.Title1, boldFont),
                                new Chunk("\n" + partner.Description1, normalFont)
                            };
                    var footerCell = new PdfPCell(phrase1)
                    {
                        PaddingRight = 10f,
                        BorderWidth = 0
                    };
                    footerLabel.AddCell(footerCell);
                }
                else
                {
                    var footerCell = new PdfPCell(new Phrase())
                    {
                        PaddingRight = 10f,
                        BorderWidth = 0
                    };
                    footerLabel.AddCell(footerCell);
                }
            }

            //--add copy pack 2
            if (!string.IsNullOrEmpty(partner.PackcopyBlock2))
            {
                var packCopyPack = Image.GetInstance(partner.PackcopyBlock2);
                //var newWith1 = packCopyPack.Width*182/packCopyPack.Height;
                //var newRec = CalculateNewRectangle(packCopyPack);
                //packCopyPack.ScaleAbsolute(newWith1, 182);
                var imageSize1 = new ImageFrameRectangle(packCopyPack.Width, packCopyPack.Height);
                var newRec = ExpandToBound(imageSize1, exampleBound);//CalculateNewRectangle(packCopyPack);
                packCopyPack.ScaleAbsolute(newRec.Width, newRec.Height);                
                var footerCell = new PdfPCell(packCopyPack)
                {
                    PaddingLeft = 10f,
                    BorderWidth = 0,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                footerLabel.AddCell(footerCell);

            }
            else
            {
                if (!string.IsNullOrEmpty(partner.Title2))
                {
                    phrase1 = new Phrase
                        {
                            new Chunk(partner.Title2, boldFont),
                            new Chunk("\n" + partner.Description2, normalFont)
                        };
                    var footerCell = new PdfPCell(phrase1)
                    {
                        PaddingRight = 10f,
                        BorderWidth = 0
                    };
                    footerLabel.AddCell(footerCell);
                }
                else
                {
                    var footerCell = new PdfPCell(new Phrase())
                    {
                        PaddingRight = 10f,
                        BorderWidth = 0
                    };
                    footerLabel.AddCell(footerCell);
                }
            }
            footerLabel.TotalWidth = document.Right - document.Left;
            //footerLabel.WriteSelectedRows(0, -1, 5f, footerLabel.TotalHeight + 10f, pdfWriter.DirectContent);

            #endregion

            return footerLabel;
        }

        //private static ImageFrameRectangle CalculateNewRectangle(Image image)
        //{
        //    var ratio = 251.0/182;
        //    var result = new ImageFrameRectangle();
        //    if (image.Width/image.Height > ratio)
        //    {
        //        result.Width = 251f;
        //        result.Height = 182f*image.Width/251f;
        //    }
        //    else
        //    {
        //        result.Height = 182f;
        //        result.Width = 251f * image.Height / 182;
        //    }
        //    return result;
        //}

        private static ImageFrameRectangle ExpandToBound(ImageFrameRectangle image, ImageFrameRectangle boundingBox)
        {
            double widthScale = 0, heightScale = 0;
            if (image.Width != 0)
                widthScale = (double)boundingBox.Width / (double)image.Width;
            if (image.Height != 0)
                heightScale = (double)boundingBox.Height / (double)image.Height;

            double scale = Math.Min(widthScale, heightScale);

            var result = new ImageFrameRectangle((int)(image.Width * scale),
                                (int)(image.Height * scale));
            return result;
        }
    }

    class Partner
    {
        public string Title1 { get; set; }

        public string Description1 { get; set; }
        /// <summary>
        /// Display on left at TSC packing slip's footer instead
        /// </summary>
        public string PackcopyBlock1 { get; set; }

        public string Title2 { get; set; }

        public string Description2 { get; set; }
        /// <summary>
        /// Display on right at TSC packing slip's footer instead
        /// </summary>
        public string PackcopyBlock2 { get; set; }
    }

    public class ImageFrameRectangle
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public ImageFrameRectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
