using System;
using System.Diagnostics;
using System.IO;
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

            // Measure conversion time
            Stopwatch sw = Stopwatch.StartNew();

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PNG save options
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save rasterized PNG
                image.Save(outputPath, saveOptions);
            }

            sw.Stop();

            // Log duration in milliseconds
            Console.WriteLine($"Conversion duration: {sw.ElapsedMilliseconds} ms");

            // Log output file size
            long fileSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Output file size: {fileSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}