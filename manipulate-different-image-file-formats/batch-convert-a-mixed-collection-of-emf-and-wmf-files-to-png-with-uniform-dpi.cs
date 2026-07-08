using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded list of input EMF and WMF files
            string[] inputFiles = new[]
            {
                "input1.emf",
                "input2.wmf",
                "input3.emf"
            };

            // Output directory
            string outputFolder = "Output";
            Directory.CreateDirectory(outputFolder);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load vector image and save as PNG with uniform DPI
                using (Image image = Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300) // uniform DPI
                    };
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
 * 1. When a developer needs to batch convert a mixed collection of EMF and WMF vector graphics into high‑resolution PNG files for web publishing, they can use this code to load each file and save it with a uniform 300 DPI.
 * 2. When migrating legacy Windows Metafile assets to a modern image format for inclusion in a cross‑platform .NET application, this snippet automates the conversion of EMF and WMF files to PNG while preserving consistent resolution.
 * 3. When preparing printable marketing materials that require raster images at a specific DPI, a developer can employ this routine to transform vector EMF/WMF logos into 300 DPI PNGs in a single batch.
 * 4. When building an automated build pipeline that extracts vector icons from a design repository and generates PNG thumbnails for a mobile app, this code provides a simple C# solution for bulk conversion with fixed DPI settings.
 * 5. When creating a document‑generation service that accepts user‑uploaded EMF or WMF diagrams and needs to embed them as PNG images in PDF reports, this example shows how to convert the files uniformly before insertion.
 */