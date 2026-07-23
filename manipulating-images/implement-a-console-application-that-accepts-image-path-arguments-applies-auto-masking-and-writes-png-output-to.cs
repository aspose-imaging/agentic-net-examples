using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\image.png";
            string outputPath = "output\\result.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Export options for the masking process
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options (auto‑masking with GraphCut)
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Perform masking
                var masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    // Retrieve the foreground segment (index 1)
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        // Save the foreground as a PNG file
                        foreground.Save(outputPath, new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(outputPath, false)
                        });
                    }
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
 * 1. When a developer needs to batch‑process product photos from a folder, automatically remove the background with GraphCut auto‑masking and save the transparent PNGs to an output directory.
 * 2. When an e‑commerce platform requires a command‑line tool that accepts image file paths, isolates the foreground objects, and generates PNG files with alpha channels for seamless web display.
 * 3. When a digital asset management system must convert scanned PNG scans into cut‑out images by applying auto‑masking and exporting the result as a true‑color‑with‑alpha PNG.
 * 4. When a game‑development pipeline needs a quick C# console utility to strip backgrounds from sprite sheets using Aspose.Imaging’s ImageMasking and output the masked sprites as PNG files.
 * 5. When a marketing automation script has to process user‑uploaded PNG logos, automatically separate the logo from its background, and store the transparent PNGs for later use in branding materials.
 */