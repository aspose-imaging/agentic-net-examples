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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputImages";
            string outputDirectory = @"C:\OutputPdfs";

            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 500x500 pixels
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Resize(500, 500);
                    }

                    // Prepare PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Determine output PDF path
                    string outputPath = Path.Combine(outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the resized image as a PDF document
                    image.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}