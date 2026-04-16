using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG files
        string[] inputFiles = new[]
        {
            @"C:\Images\example1.svg",
            @"C:\Images\example2.svg"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PNG path
            string outputPath = inputPath + ".png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Start timing
            Stopwatch sw = Stopwatch.StartNew();

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Configure PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save rasterized PNG
                image.Save(outputPath, pngOptions);
            }

            // Stop timing
            sw.Stop();

            // Get output file size
            long fileSize = new FileInfo(outputPath).Length;

            // Log duration and size
            Console.WriteLine($"Rasterized '{inputPath}' to '{outputPath}' in {sw.ElapsedMilliseconds} ms, size: {fileSize} bytes.");
        }
    }
}