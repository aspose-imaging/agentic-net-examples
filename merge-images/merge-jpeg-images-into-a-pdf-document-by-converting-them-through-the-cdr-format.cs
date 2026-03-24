using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG file paths
        string inputPath1 = @"C:\Images\image1.jpg";
        string inputPath2 = @"C:\Images\image2.jpg";
        string inputPath3 = @"C:\Images\image3.jpg";

        // Verify each input file exists
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

        // Hardcoded output PDF path
        string outputPath = @"C:\Output\merged.pdf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPEG files
        string[] jpegFiles = new[] { inputPath1, inputPath2, inputPath3 };
        using (Image multipageImage = Image.Create(jpegFiles))
        {
            // Prepare PDF export options (no special rasterization needed for raster images)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a single PDF document
            multipageImage.Save(outputPath, pdfOptions);
        }
    }
}