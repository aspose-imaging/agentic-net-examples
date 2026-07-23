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

                using (MaskingResult result = new ImageMasking(image).Decompose(autoOptions))
                {
                    using (RasterImage foreground = (RasterImage)result[1].GetImage())
                    {
                        foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
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
 * 1. When a developer needs to automatically remove the background from a high‑resolution product photograph (JPEG) but must manually refine tiny hair strands or logo details that the Graph Cut algorithm missed, they can combine auto‑masking with a point array to produce a clean PNG with an alpha channel.
 * 2. When processing scanned archival documents where the auto‑masking separates text from the paper background but leaves small ink specks unmasked, a developer can add manual points to the mask to ensure those specks are removed before saving the result as a transparent PNG.
 * 3. When creating assets for a mobile game, a developer may use auto‑masking to extract a character sprite from a JPEG background and then use a manual point array to fix missed pixels around the character’s edges, resulting in a PNG with smooth feathered edges.
 * 4. When preparing medical imaging slides for analysis, a developer can apply Graph Cut auto‑masking to isolate tissue regions and then manually add points to correct small gaps in the mask, ensuring accurate segmentation before exporting to PNG.
 * 5. When building an AR application that overlays virtual objects onto real‑world scenes, a developer can auto‑mask the foreground from a camera‑captured JPEG and manually adjust the mask with point coordinates to capture fine details like wires or thin objects, producing a transparent PNG for seamless compositing.
 */