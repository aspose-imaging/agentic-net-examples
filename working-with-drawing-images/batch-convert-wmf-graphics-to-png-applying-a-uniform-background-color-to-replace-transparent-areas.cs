// HOW-TO: Batch Convert WMF Files to PNG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory and list of WMF files to process
            string inputDirectory = @"C:\Images\Wmf";
            string[] wmfFiles = new[]
            {
                Path.Combine(inputDirectory, "image1.wmf"),
                Path.Combine(inputDirectory, "image2.wmf"),
                Path.Combine(inputDirectory, "image3.wmf")
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\Png";

            // Uniform background color to replace transparent areas
            Aspose.Imaging.Color backgroundColor = Aspose.Imaging.Color.White;

            foreach (string inputPath in wmfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .png extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare rasterization options with the desired background color
                    WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = backgroundColor
                    };

                    // Prepare PNG save options and attach rasterization options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PNG
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate printable PNG thumbnails from legacy WMF icons and ensure any transparent regions appear on a solid white canvas.
 * 2. When a reporting system must convert multiple WMF charts to PNG for web display while replacing transparency with a uniform background color.
 * 3. When migrating a desktop application’s assets, you require a C# script to batch rasterize WMF drawings into PNG files with a consistent background for consistent UI styling.
 * 4. When automating document preparation, you need to convert WMF logos to PNG and fill transparent areas so they render correctly in PDF generators that do not support WMF transparency.
 * 5. When creating a batch image processing pipeline that standardizes all vector WMF graphics to PNG format with a predefined background to meet branding guidelines.
 */
