using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.jpg";
        string outputPath = @"C:\temp\sample.pdf";

        // Verify that the input JPEG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF save options
            var pdfOptions = new PdfOptions();

            // Save the image as a PDF document, embedding the raster data
            image.Save(outputPath, pdfOptions);
        }
    }
}