using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.bmp";

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
            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Set up rasterization options for EMF to BMP conversion
                var rasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size
                };

                // BMP save options with the rasterization settings
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as BMP
                emfImage.Save(outputPath, bmpOptions);
            }

            // Ensure output directory exists again before second save (unconditional as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image to apply grayscale
            using (Image bmpImage = Image.Load(outputPath))
            {
                // Cast to BMP-specific class to access Grayscale method
                var bmp = (BmpImage)bmpImage;
                bmp.Grayscale(); // Convert to grayscale

                // Overwrite the BMP file with the grayscale version
                bmp.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}