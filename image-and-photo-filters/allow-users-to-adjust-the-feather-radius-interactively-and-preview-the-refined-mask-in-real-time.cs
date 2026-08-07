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

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            while (true)
            {
                Console.Write("Enter feather radius (0 to exit): ");
                string line = Console.ReadLine();
                if (!int.TryParse(line, out int radius) || radius < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non‑negative integer.");
                    continue;
                }

                if (radius == 0)
                    break;

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    var options = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = true,
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

                    var results = new ImageMasking(image).Decompose(options);

                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }

                Console.WriteLine($"Mask saved to {outputPath} with feather radius {radius}.");
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
 * 1. When a developer needs to let a user fine‑tune the edge softness of a cut‑out in a JPEG photo and instantly see the transparent PNG result for product photography.
 * 2. When building a desktop tool that lets designers experiment with different feather radii to create smooth masks for images that will be layered in a UI mockup.
 * 3. When implementing an automated batch‑processing UI where operators can adjust the GraphCut feathering radius before exporting each image as a PNG with an alpha channel.
 * 4. When creating a C# console utility for e‑commerce sellers to remove backgrounds from product images and preview how varying feather radius affects the final transparent PNG.
 * 5. When developing a proof‑of‑concept for an image‑editing plugin that requires real‑time feedback on mask refinement using Aspose.Imaging’s AutoMaskingGraphCutOptions.
 */