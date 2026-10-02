// HOW-TO: Unit Test for Removing Background from PNG and Verifying Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
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
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult result = new ImageMasking(image).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    foreground.Save(outputPath, saveOptions);
                }
            }

            using (RasterImage resultImage = (RasterImage)Image.Load(outputPath))
            {
                int[] pixelData = resultImage.LoadArgb32Pixels(new Rectangle(0, 0, 1, 1));
                int argb = pixelData[0];
                int alpha = (argb >> 24) & 0xFF;
                if (alpha == 0)
                {
                    Console.WriteLine("Test passed: background is transparent.");
                }
                else
                {
                    Console.WriteLine("Test failed: background not transparent.");
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
 * 1. When you need to automatically remove a solid background from product photos in PNG format and ensure the resulting image has transparent pixels for seamless web display.
 * 2. When you want to create a unit test that validates Aspose.Imaging's auto‑masking graph‑cut algorithm correctly isolates foreground objects and replaces the original background with transparency.
 * 3. When integrating image preprocessing into an e‑commerce pipeline, you can use this code to confirm that uploaded PNGs are cleaned of unwanted backgrounds before they are stored or shown to customers.
 * 4. When developing a desktop application that lets users edit images, you can employ this approach to automatically generate transparent PNG assets and verify the output during continuous integration.
 * 5. When preparing graphics for overlay on different UI themes, this snippet helps ensure that the background removal process produces a PNG with an alpha channel so the image blends correctly on any background color.
 */
