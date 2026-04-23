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

        // Load the EMF image and rasterize it to BMP
        using (Image emfImage = Image.Load(inputPath))
        {
            // Set up rasterization options for EMF
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

        // Load the saved BMP, apply grayscale, and overwrite the file
        using (BmpImage bmpImage = (BmpImage)Image.Load(outputPath))
        {
            // Convert to grayscale (monochrome effect)
            bmpImage.Grayscale();

            // Save the modified BMP back to the same path
            bmpImage.Save(outputPath);
        }
    }
}