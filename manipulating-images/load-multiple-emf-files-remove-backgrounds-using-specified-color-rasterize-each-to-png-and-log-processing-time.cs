using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input EMF files
        string[] inputFiles = new string[]
        {
            @"C:\Images\file1.emf",
            @"C:\Images\file2.emf"
        };

        // Hardcoded output directory for PNG files
        string outputDir = @"C:\Images\Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output PNG path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDir, fileName + ".png");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Start timing
            Stopwatch sw = Stopwatch.StartNew();

            // Load EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Remove background if the image is a vector image
                if (image is VectorImage vectorImage)
                {
                    vectorImage.RemoveBackground();
                }

                // Configure PNG options with vector rasterization
                var pngOptions = new PngOptions();
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White, // specified background color
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = vectorOptions;

                // Save rasterized PNG
                image.Save(outputPath, pngOptions);
            }

            // Stop timing and log
            sw.Stop();
            Console.WriteLine($"Processed '{inputPath}' in {sw.ElapsedMilliseconds} ms");
        }
    }
}