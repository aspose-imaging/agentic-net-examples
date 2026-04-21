using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Apply a 10‑pixel border crop
                    int cropX = 10;
                    int cropY = 10;
                    int cropWidth = Math.Max(0, image.Width - 20);
                    int cropHeight = Math.Max(0, image.Height - 20);
                    if (cropWidth > 0 && cropHeight > 0)
                    {
                        image.Crop(new Aspose.Imaging.Rectangle(cropX, cropY, cropWidth, cropHeight));
                    }

                    // Save as PNG
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}