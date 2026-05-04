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
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with high quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 95
                };

                // Set up vector rasterization options for proper EMF rendering
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}