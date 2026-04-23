using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG files
        string[] inputFiles = new[]
        {
            @"C:\Images\example1.svg",
            @"C:\Images\example2.svg",
            @"C:\Images\example3.svg"
        };

        // Create a single SvgRasterizationOptions instance to be reused
        var rasterizationOptions = new SvgRasterizationOptions();

        // Configure rasterization options as needed (e.g., default page size will be set per image)
        // Additional settings can be applied here if required:
        // rasterizationOptions.BackgroundColor = Aspose.Imaging.Color.White;
        // rasterizationOptions.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;
        // rasterizationOptions.TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias;

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output BMP path (same folder, .bmp extension)
            string outputPath = Path.ChangeExtension(inputPath, ".bmp");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Set page size for rasterization based on the loaded image size
                rasterizationOptions.PageSize = image.Size;

                // Prepare BMP save options and assign the shared rasterization options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}