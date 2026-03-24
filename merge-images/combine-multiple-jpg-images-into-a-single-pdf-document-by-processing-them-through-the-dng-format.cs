using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded output PDF file
        string outputPath = @"C:\Images\Combined.pdf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files (uses Image.Create(string[]))
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Set up PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}