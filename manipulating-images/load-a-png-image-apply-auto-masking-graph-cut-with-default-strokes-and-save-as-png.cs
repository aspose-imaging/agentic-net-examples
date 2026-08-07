using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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
                AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource("tempMask.png", false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                MaskingResult results = new ImageMasking(image).Decompose(options);

                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                if (File.Exists("tempMask.png"))
                {
                    File.Delete("tempMask.png");
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
 * 1. When a developer needs to automatically remove the background from a user‑uploaded PNG photo for a web‑based avatar editor, they can load the image, apply Aspose.Imaging’s auto‑masking Graph Cut with default strokes, and save the transparent PNG.
 * 2. When an e‑commerce platform wants to generate product thumbnails with clean cut‑outs from supplier PNG files, the code can segment the object using Graph Cut, feather the edges, and output a PNG with an alpha channel.
 * 3. When a mobile app requires batch processing of PNG icons to create transparent versions for dark‑mode themes, the developer can use this routine to auto‑mask each image and preserve the truecolor with alpha format.
 * 4. When a digital publishing workflow needs to isolate scanned illustrations from their white backgrounds before embedding them in PDFs, the Graph Cut auto‑masking in C# quickly produces a PNG mask that can be composited later.
 * 5. When a machine‑learning pipeline prepares training data by extracting foreground objects from PNG samples, the code provides an efficient way to generate masked PNGs with transparent backgrounds for model input.
 */