using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToPdfConverter
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\input\sample.odg";
            string outputPath = @"C:\output\sample.pdf";

            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the ODG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options to flatten the document
                    var rasterOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White, // flatten annotations onto a white background
                        PageSize = image.Size
                    };

                    // Set up PDF save options and attach rasterization options
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save the image as a PDF
                    image.Save(outputPath, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                // Report any runtime errors without crashing
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}