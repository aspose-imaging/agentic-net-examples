using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\InputPsd";
        string outputDir = @"C:\Images\OutputPng";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PSD files in the input directory
            string[] psdFiles = Directory.GetFiles(inputDir, "*.psd", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in psdFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image, deskew, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access NormalizeAngle
                    if (image is RasterImage rasterImage)
                    {
                        // Deskew without resizing, using LightGray as background
                        rasterImage.NormalizeAngle(false, Color.LightGray);
                    }

                    // Save as PNG (extension determines format)
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}