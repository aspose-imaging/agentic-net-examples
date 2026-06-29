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
        string inputPath = "input.jpg";
        string outputPath = "output\\masked.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                AutoMaskingGraphCutOptions maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = exportOptions,
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        foreground.Save(outputPath, new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha
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
 * 1. When a developer needs to automatically remove the background from user‑uploaded JPEG photos and save the resulting transparent PNG for use in web galleries.
 * 2. When an e‑commerce platform must batch‑process product images, applying auto‑masking to isolate the product and export it as a PNG with an alpha channel for overlay on promotional banners.
 * 3. When a mobile app backend receives raw image files and must generate cut‑out images with transparent backgrounds for avatar creation, using GraphCut segmentation in C#.
 * 4. When a digital publishing workflow requires converting scanned JPEG illustrations into PNG assets with transparent backgrounds to embed in PDF layouts.
 * 5. When a content‑management system needs to accept image path arguments, perform auto‑masking, and store the masked PNG in a specified folder for later retrieval by a front‑end UI.
 */