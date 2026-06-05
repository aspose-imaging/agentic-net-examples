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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set rasterization options for vector to raster conversion
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure JPEG options with quality 95%
                var jpegOptions = new JpegOptions
                {
                    Quality = 95,
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as high‑quality JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}