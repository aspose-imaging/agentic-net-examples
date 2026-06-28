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
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            while (true)
            {
                Console.Write("Enter feather radius (empty to quit): ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    break;

                if (!int.TryParse(line, out int radius) || radius < 0)
                {
                    Console.WriteLine("Invalid radius. Please enter a non‑negative integer.");
                    continue;
                }

                // Load source image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Configure masking options with user‑specified feather radius
                    var options = new GraphCutMaskingOptions
                    {
                        FeatheringRadius = radius,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new StreamSource(new MemoryStream())
                        },
                        BackgroundReplacementColor = Color.Transparent
                    };

                    // Perform masking
                    using (MaskingResult results = new ImageMasking(image).Decompose(options))
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        // Save preview image with radius in filename
                        string previewPath = Path.Combine(
                            Path.GetDirectoryName(outputPath) ?? "",
                            $"preview_{radius}.png");

                        resultImage.Save(previewPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        Console.WriteLine($"Preview saved to: {previewPath}");
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
 * 1. When a developer needs to let users fine‑tune the softness of a background‑removal mask for e‑commerce product photos, they can use this interactive feather‑radius loop to generate PNGs with transparent edges.
 * 2. When building a desktop tool that lets designers preview how a soft‑edge mask will look on a portrait before exporting to PNG with an alpha channel, the code provides real‑time adjustment of the GraphCut feathering radius.
 * 3. When preparing images for print layouts where the transition between subject and background must be smooth, developers can employ this C# snippet to experiment with different FeatheringRadius values and instantly see the refined mask.
 * 4. When creating medical imaging applications that require precise segmentation of tissues with adjustable edge smoothing, the interactive console allows radiologists to set the GraphCutMaskingOptions feather radius and view the resulting mask in real time.
 * 5. When generating game assets that need feathered transparency for sprites or UI icons, developers can use this code to iteratively adjust the feather radius and export the result as a TruecolorWithAlpha PNG.
 */