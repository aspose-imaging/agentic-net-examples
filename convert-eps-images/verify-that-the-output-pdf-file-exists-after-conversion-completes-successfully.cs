using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded relative paths
        string inputPath = Path.Combine("Input", "sample.jpg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save as PDF
                image.Save(outputPath, new PdfOptions());
            }

            // Verify that the PDF was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("PDF file created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create PDF file.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}