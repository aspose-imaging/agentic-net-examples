using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
                PdfOptions pdfOptions = new PdfOptions();

                using (Image pdfImage = Image.Create(pdfOptions, vectorImage.Width, vectorImage.Height))
                {
                    Graphics graphics = new Graphics(pdfImage);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(vectorImage, new Point(0, 0));

                    Pen dashPen = new Pen(Color.Red, 2);
                    dashPen.DashPattern = new float[] { 5f, 3f, 2f, 3f };
                    graphics.DrawRectangle(dashPen, new Rectangle(0, 0, vectorImage.Width, vectorImage.Height));

                    pdfImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert an SVG vector drawing into a PDF report while adding a custom red dashed border around the artwork.
 * 2. When an engineering application must export schematics as PDF files with highlighted outlines using a specific dash pattern for better visual distinction.
 * 3. When a web service generates printable invoices from SVG logos and wants to emphasize the logo edges with a red dash style before saving as PDF.
 * 4. When a desktop tool creates PDF portfolios of design assets and requires a consistent dashed frame around each vector image for branding purposes.
 * 5. When an automated batch process converts multiple SVG files to PDF and applies a custom dash pattern to indicate revision status on the document borders.
 */