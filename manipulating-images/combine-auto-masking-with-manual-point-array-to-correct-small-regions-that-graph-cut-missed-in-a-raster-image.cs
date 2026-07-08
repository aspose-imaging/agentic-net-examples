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
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var autoOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource("temp_auto.png")
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(autoOptions))
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                if (File.Exists("temp_auto.png"))
                {
                    File.Delete("temp_auto.png");
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
 * 1. When a developer needs to automatically remove the background of product photos in JPEG format, then fine‑tune small edge artifacts with a manual point array before exporting a transparent PNG for e‑commerce listings.
 * 2. When an image‑processing pipeline must extract foreground objects from scanned documents, apply Graph Cut auto‑masking, and manually correct missed regions to produce a clean PNG with an alpha channel for OCR preprocessing.
 * 3. When a mobile app generates user avatars by auto‑segmenting portrait photos, then uses a point‑based mask to fix hair strands that Graph Cut missed, saving the result as a true‑color PNG with transparency.
 * 4. When a digital‑art workflow requires batch processing of JPEG illustrations, automatically separating characters with Graph Cut and manually adjusting tiny details like accessories via point coordinates before saving as PNG for compositing.
 * 5. When a developer integrates Aspose.Imaging into a content‑management system to auto‑mask backgrounds of uploaded images, then applies a custom point array to patch small holes left by the algorithm, delivering a transparent PNG for web publishing.
 */