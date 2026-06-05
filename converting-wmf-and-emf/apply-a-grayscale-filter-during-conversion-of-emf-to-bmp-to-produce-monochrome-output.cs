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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Prepare BMP save options with rasterization settings
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size
                    }
                };

                // Rasterize EMF to BMP in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    emfImage.Save(ms, bmpOptions);
                    ms.Position = 0;

                    // Load the rasterized BMP image
                    using (BmpImage bmpImage = (BmpImage)Image.Load(ms))
                    {
                        // Convert to grayscale
                        bmpImage.Grayscale();

                        // Save the grayscale BMP to the output path
                        bmpImage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}