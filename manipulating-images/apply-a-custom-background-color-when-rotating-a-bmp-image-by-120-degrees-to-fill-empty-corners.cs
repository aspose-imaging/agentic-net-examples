using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

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

            // Load BMP image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Cache data for better performance (optional)
                if (!image.IsCached)
                    image.CacheData();

                // Rotate 120 degrees, resize proportionally, fill empty corners with red background
                image.Rotate(120f, true, Color.FromArgb(255, 255, 0, 0));

                // Prepare BMP save options with bound source
                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the rotated image
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}