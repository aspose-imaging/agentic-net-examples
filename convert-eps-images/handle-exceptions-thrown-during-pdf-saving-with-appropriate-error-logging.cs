using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set up PDF options (default settings)
                var pdfOptions = new PdfOptions();

                // Save the image as PDF, handling any exceptions in the outer try-catch
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Log any errors that occur during processing or saving
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}