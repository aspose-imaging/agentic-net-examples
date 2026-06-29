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
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                Pen dashPen = new Pen(Color.Black, 2);
                dashPen.DashStyle = DashStyle.Custom;
                dashPen.DashPattern = new float[] { 5f, 2f, 1f, 2f };

                Graphics graphics = new Graphics(vectorImage);
                graphics.DrawRectangle(dashPen, new Rectangle(10, 10, vectorImage.Width - 20, vectorImage.Height - 20));

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height,
                    BackgroundColor = Color.White
                };

                vectorImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert an SVG floor‑plan into a printable PDF while highlighting room boundaries with a custom dash pattern.
 * 2. When a web application must generate a PDF brochure from vector logos and apply a stylized dashed outline to each logo for branding consistency.
 * 3. When an engineering tool has to export circuit diagrams as PDFs and emphasize selected wires using a custom dash pattern for review meetings.
 * 4. When a reporting system creates PDF invoices from SVG icons and wants to draw a dashed border around the icon area to meet corporate style guidelines.
 * 5. When a desktop utility processes user‑uploaded SVG illustrations and adds a custom dashed frame before saving the result as a high‑resolution PDF document.
 */