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
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_grayscale.bmp";

        // Verify input file exists
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
            // Configure rasterization options for BMP conversion
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White
            };

            // BMP save options with the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save to a temporary BMP file (required to apply grayscale)
            string tempBmpPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.bmp");
            Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));
            emfImage.Save(tempBmpPath, bmpOptions);

            // Load the temporary BMP, apply grayscale, and save final output
            using (BmpImage bmpImage = (BmpImage)Image.Load(tempBmpPath))
            {
                // Transform the image to grayscale
                bmpImage.Grayscale();

                // Save the grayscale BMP to the desired location
                bmpImage.Save(outputPath);
            }

            // Clean up the temporary file
            try { File.Delete(tempBmpPath); } catch { }
        }
    }
}