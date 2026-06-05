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
            // Hardcoded input file paths
            string[] inputPaths = new string[]
            {
                @"c:\input\image1.jpg",
                @"c:\input\image2.bmp"
            };

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path (same name, .png extension, in c:\output)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(@"c:\output", outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Define a rectangle that crops a 5‑pixel border from each side
                    int cropX = 5;
                    int cropY = 5;
                    int cropWidth = Math.Max(0, image.Width - 10);
                    int cropHeight = Math.Max(0, image.Height - 10);
                    var bounds = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                    // PNG save options (default)
                    var pngOptions = new PngOptions();

                    // Save the cropped region as PNG
                    image.Save(outputPath, pngOptions, bounds);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}