using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input\";
        string outputDir = @"C:\Images\Output\";

        // List of PSD files to process
        string[] psdFiles = new string[]
        {
            "image1.psd",
            "image2.psd",
            "image3.psd"
        };

        try
        {
            foreach (string fileName in psdFiles)
            {
                // Build full input path
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (PNG with same base name)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access AdjustGamma
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply gamma correction (example gamma value)
                    rasterImage.AdjustGamma(2.2f);

                    // Save as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}