using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "InputWmf";
            string outputDirectory = "OutputPng";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add WMF files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get WMF files
            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WMF image
                using (Aspose.Imaging.FileFormats.Wmf.WmfImage wmfImage = (Aspose.Imaging.FileFormats.Wmf.WmfImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    // Set up rasterization options with transparent background
                    var rasterOptions = new Aspose.Imaging.ImageOptions.WmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.Transparent,
                        PageSize = wmfImage.Size
                    };

                    // Configure PNG options for 32‑bit color depth (Truecolor with Alpha)
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        BitDepth = 8,
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PNG
                    wmfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a library of legacy Windows Metafile (WMF) icons into high‑quality 32‑bit PNG images with a transparent background for use in a modern web application.
 * 2. When an automation script must process multiple WMF diagrams from a CAD system and generate PNG files that preserve vector detail while supporting alpha transparency for inclusion in PDF reports.
 * 3. When a content management system requires bulk conversion of WMF logos uploaded by users into PNG format so they render correctly on mobile devices with transparent backgrounds.
 * 4. When a game development pipeline needs to rasterize WMF sprite sheets into 32‑bit PNG textures with no background color to integrate seamlessly with the engine’s rendering pipeline.
 * 5. When a documentation generation tool has to batch convert WMF flowcharts into PNG images that retain full color depth and transparent backgrounds for embedding in HTML help files.
 */