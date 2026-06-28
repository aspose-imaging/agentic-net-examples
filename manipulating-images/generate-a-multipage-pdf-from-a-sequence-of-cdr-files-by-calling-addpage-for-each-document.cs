using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = @"input1.cdr";
            string inputPath2 = @"input2.cdr";
            string inputPath3 = @"input3.cdr";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            using (Image img1 = Image.Load(inputPath1))
            using (Image img2 = Image.Load(inputPath2))
            using (Image img3 = Image.Load(inputPath3))
            {
                Image[] images = new Image[] { img1, img2, img3 };

                using (Image multiPage = Image.Create(images, true))
                {
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = multiPage.Width,
                            PageHeight = multiPage.Height
                        }
                    };

                    string outputPath = @"output\merged.pdf";

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    multiPage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer uses C# and Aspose.Imaging to merge multiple CorelDRAW (CDR) files into a single PDF portfolio for client review.
 * 2. When an automated C# reporting tool needs to convert a sequence of CDR diagrams into a multi‑page PDF for archival storage.
 * 3. When a .NET web service allows users to upload several CDR files and returns a merged PDF ready for printing.
 * 4. When a batch‑processing script in C# consolidates CDR pages from different design projects into one PDF to simplify version control.
 * 5. When a document‑management workflow requires rasterizing vector CDR artwork into a PDF with a white background and uniform page dimensions using Aspose.Imaging.
 */