using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.bmp";

        // Ensure any runtime exception is reported without crashing
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

            // Load the WMF image
            using (Image wmfImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for vector to raster conversion
                var rasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = wmfImage.Size,
                    BackgroundColor = Color.White // optional: set background color
                };

                // Configure BMP save options with 24‑bit color depth
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as a 24‑bit BMP
                wmfImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}