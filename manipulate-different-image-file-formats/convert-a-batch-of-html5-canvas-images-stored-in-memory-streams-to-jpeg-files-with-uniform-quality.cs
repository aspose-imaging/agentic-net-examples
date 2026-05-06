using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputDir);

            // List of input canvas image files (could be PNG, BMP, etc.)
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "canvas1.png"),
                Path.Combine(inputDir, "canvas2.png"),
                Path.Combine(inputDir, "canvas3.png")
            };

            // JPEG save options with uniform quality
            var jpegOptions = new JpegOptions
            {
                Quality = 80 // quality between 1 and 100
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image from a memory stream
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(inputPath)))
                using (Image image = Image.Load(ms))
                {
                    // Determine output file path
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as JPEG with the specified options
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}