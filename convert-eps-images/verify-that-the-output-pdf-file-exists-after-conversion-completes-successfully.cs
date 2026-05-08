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
            // Hardcoded relative input and output paths
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image and convert to PDF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
            }

            // Verify that the PDF file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"PDF file successfully created: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine($"Failed to create PDF file: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}