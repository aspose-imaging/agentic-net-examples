using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded list of ODG files to convert
        string[] inputFiles = new[]
        {
            @"C:\Images\Input\file1.odg",
            @"C:\Images\Input\file2.odg",
            @"C:\Images\Input\file3.odg"
        };

        // Process files in parallel
        Parallel.ForEach(inputFiles, inputPath =>
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PNG path (same folder, same name with .png)
            string outputPath = Path.ChangeExtension(inputPath, ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Configure PNG save options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG
                image.Save(outputPath, pngOptions);
            }

            Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
        });
    }
}