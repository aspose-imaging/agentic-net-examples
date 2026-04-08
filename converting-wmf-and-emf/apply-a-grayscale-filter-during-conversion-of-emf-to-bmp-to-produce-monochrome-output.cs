using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_grayscale.bmp";

        // Verify the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for EMF → BMP conversion
            var rasterOptions = new EmfRasterizationOptions
            {
                // Use the original EMF size for the bitmap
                PageSize = emfImage.Size,
                // Optional: set background to white for consistency
                BackgroundColor = Color.White
            };

            // BMP save options with the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized BMP (still in color)
            emfImage.Save(outputPath, bmpOptions);
        }

        // Load the newly created BMP to apply grayscale conversion
        using (BmpImage bmpImage = (BmpImage)Image.Load(outputPath))
        {
            // Convert the bitmap to grayscale (monochrome)
            bmpImage.Grayscale();

            // Overwrite the same file with the grayscale version
            bmpImage.Save(outputPath);
        }
    }
}