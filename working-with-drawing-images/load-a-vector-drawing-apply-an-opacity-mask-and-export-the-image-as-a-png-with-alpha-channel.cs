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
            string inputPath = "vector.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector drawing as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Export options for PNG with alpha channel
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Masking options: transparent background, no decomposition
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions,
                    Args = new AutoMaskingArgs()
                };

                // Perform masking to obtain the foreground with opacity
                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                using (RasterImage resultImage = (RasterImage)maskingResult[1].GetImage())
                {
                    resultImage.Save(outputPath, exportOptions);
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
 * 1. When a developer needs to convert an SVG logo into a PNG with a transparent background for web UI branding.
 * 2. When an application must generate thumbnails of vector illustrations while preserving the alpha channel for overlay effects.
 * 3. When a reporting tool has to embed vector diagrams into PDF reports as PNG images with proper opacity masking.
 * 4. When a game engine imports SVG assets and requires them as PNG textures with transparent regions for sprite rendering.
 * 5. When an e‑commerce platform automates the creation of product watermarks by applying an opacity mask to vector graphics and exporting them as PNG files with alpha.
 */