using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = image.Size,
                    // Optional: set background color if needed
                    BackgroundColor = Color.White
                };

                // Configure PNG save options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Measure rasterization duration
                var stopwatch = Stopwatch.StartNew();

                // Save rasterized PNG
                image.Save(outputPath, pngOptions);

                stopwatch.Stop();

                // Get output file size
                long fileSize = new FileInfo(outputPath).Length;

                // Log duration and size
                Console.WriteLine($"Rasterization completed in {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine($"Output file size: {fileSize} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}