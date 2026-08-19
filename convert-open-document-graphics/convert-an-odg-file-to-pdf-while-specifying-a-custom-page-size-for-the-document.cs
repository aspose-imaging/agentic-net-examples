// HOW-TO: Convert ODG to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = 800,   // custom width
                    PageHeight = 600   // custom height
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When you need to generate a PDF from an ODG diagram and must fit it into a specific page dimension for printing or embedding.
 * 2. When integrating Aspose.Imaging into a C# application that processes OpenDocument graphics and requires a consistent PDF layout across different devices.
 * 3. When automating batch conversion of ODG files to PDFs while enforcing a uniform page width and height to match a corporate style guide.
 * 4. When creating PDFs from ODG drawings for web preview where the page size must match a predefined thumbnail or viewport size.
 * 5. When converting ODG artwork to PDF in a .NET service and need to set a white background to avoid transparency issues.
 */
