using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputDir = "InputImages";
        string outputDir = "OutputSvgs";

        try
        {
            // Ensure input directory exists
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each file in the input directory
            foreach (var inputPath in Directory.GetFiles(inputDir))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };

                    image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to automatically convert a large collection of JPEG or PNG photos stored in a folder into scalable SVG graphics while enforcing a 16:9 aspect ratio for consistent web display.
 * 2. When a content management system must batch‑process user‑uploaded images, crop them to a widescreen 16:9 frame, and store the results as SVG files for resolution‑independent rendering.
 * 3. When an e‑learning platform wants to prepare lecture slide images by trimming them to a 16:9 ratio and converting them to SVG so they scale cleanly on any device.
 * 4. When a marketing automation script has to scan an input directory, resize each image to a 16:9 canvas, and export the assets as SVG for inclusion in responsive email templates.
 * 5. When a desktop application written in C# needs to iterate over a directory of product photos, apply a 16:9 crop, and save each one as an SVG vector file for high‑quality print and web use.
 */