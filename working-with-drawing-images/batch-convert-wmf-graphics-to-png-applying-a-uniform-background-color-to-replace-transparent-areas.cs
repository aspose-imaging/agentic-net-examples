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
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // List of WMF files to process
            string[] files = new[] { "image1.wmf", "image2.wmf", "image3.wmf" };

            foreach (var fileName in files)
            {
                // Build full input path and verify existence
                string inputPath = Path.Combine(inputFolder, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build full output path and ensure directory exists
                string outputPath = Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".png"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options with a uniform background color
                    var rasterOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Aspose.Imaging.Color.White // replace transparent areas with white
                    };

                    // Set PNG save options and attach rasterization options
                    var pngOptions = new PngOptions
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
 * 1. When a developer needs to batch convert legacy WMF vector graphics to PNG raster images for web display while ensuring any transparent regions are filled with a solid background color.
 * 2. When an application must automatically process a folder of Windows Metafile (WMF) files and generate PNG thumbnails with a uniform white background for use in a product catalog.
 * 3. When a reporting tool has to embed WMF charts into PDF or HTML reports that only support PNG images, requiring conversion and background color replacement in C#.
 * 4. When a migration script moves old WMF icons into a modern mobile app that expects PNG assets, and the code must replace transparent areas with a specific color to match the app’s theme.
 * 5. When a CI/CD pipeline needs to validate and convert WMF assets to PNG during build time, applying a consistent background to avoid rendering issues in downstream image processing steps.
 */