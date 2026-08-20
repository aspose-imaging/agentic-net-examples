// HOW-TO: Remove Background and Apply Median Filter to PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output.png";

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

                AutoMaskingArgs argsMask = new AutoMaskingArgs();

                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = argsMask,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                {
                    using (RasterImage foregroundMask = maskingResult[1].GetMask())
                    {
                        foregroundMask.Resize(image.Width, image.Height, ResizeType.NearestNeighbourResample);

                        using (RasterImage originImage = (RasterImage)Image.Load(inputPath))
                        {
                            ImageMasking.ApplyMask(originImage, foregroundMask, maskingOptions);

                            originImage.Save(outputPath, new PngOptions
                            {
                                ColorType = PngColorType.TruecolorWithAlpha,
                                Source = new FileCreateSource(outputPath, false)
                            });
                        }
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
 * 1. When preparing product photos for an e‑commerce site, a developer can remove the original background and smooth remaining noise with a median filter before saving the PNG for web display.
 * 2. When cleaning scanned documents that contain stray specks after isolating the text region, a C# program can mask out the background and apply a median filter to improve OCR accuracy.
 * 3. When generating transparent icons from screenshots, a developer can use Aspose.Imaging to automatically cut out the background and then denoise the foreground with a median filter to keep crisp edges.
 * 4. When processing medical imaging slices that require background subtraction, applying a median filter after masking helps reduce pixel‑level artifacts while preserving diagnostic details.
 * 5. When creating assets for a game engine, a programmer can strip the background from character sprites and apply a median filter to eliminate residual grain before exporting the PNG with alpha transparency.
 */
