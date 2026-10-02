// HOW-TO: Convert BMP Image to PDF Document Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a PDF report that includes scanned BMP graphics.
 * 2. When an application must archive legacy BMP files as searchable PDF files for easier distribution.
 * 3. When a web service receives BMP uploads and must return them as PDF attachments.
 * 4. When converting BMP screenshots into PDF manuals without losing image quality.
 * 5. When integrating BMP assets into a PDF portfolio for compliance documentation.
 */
