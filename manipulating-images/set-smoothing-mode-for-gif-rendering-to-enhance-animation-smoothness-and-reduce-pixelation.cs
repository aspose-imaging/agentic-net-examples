using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF save options
                GifOptions gifOptions = new GifOptions();

                // Set up vector rasterization options with smoothing to improve animation quality
                VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                {
                    // Use antialiasing for smoother lines and curves
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    // Optional: set background color if needed
                    BackgroundColor = Aspose.Imaging.Color.White,
                    // Preserve original size
                    PageSize = image.Size
                };

                gifOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as GIF with the configured options
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}