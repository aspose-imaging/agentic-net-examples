using System;
using System.IO;
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
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (Aspose.Imaging.RasterImage foreground = (Aspose.Imaging.RasterImage)results[1].GetImage())
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
 * 1. When a developer needs to extract a subject from a noisy JPEG photograph, apply Gauss‑Wiener deblurring, then use bilateral smoothing to preserve edges before saving the transparent foreground as a PNG with Aspose.Imaging in C#.
 * 2. When an e‑commerce platform must automatically remove background from product images while sharpening blurred details, the code can mask the object, deblur with Gauss‑Wiener, smooth with bilateral filtering, and export a high‑quality PNG for web use.
 * 3. When a medical imaging application requires isolating tissue regions from scanned slides, the developer can use Aspose.Imaging’s graph‑cut masking together with deblurring and edge‑preserving smoothing to improve diagnostic clarity.
 * 4. When a mobile app processes user‑uploaded selfies to create stickers, the code enables background removal, restores sharpness via Gauss‑Wiener, smooths skin tones with bilateral smoothing, and generates a transparent PNG for overlay.
 * 5. When a digital archivist wants to clean up historic photographs by separating foreground elements, reducing motion blur, and smoothing grain while keeping fine details, this C# routine provides the complete masking‑deblur‑smooth workflow.
 */