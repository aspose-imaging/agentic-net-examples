// HOW-TO: Interactively Adjust Feather Radius for Image Masking in C# (Aspose.Imaging for .NET)
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
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            while (true)
            {
                Console.Write("Enter feather radius (or press Enter to exit): ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    break;

                if (!int.TryParse(line, out int radius) || radius < 0)
                {
                    Console.WriteLine("Invalid radius. Please enter a non‑negative integer.");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, $"masked_feather_{radius}.png");
                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    var maskingOptions = new AutoMaskingGraphCutOptions
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

                    using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                    {
                        using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                        {
                            resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        }
                    }
                }

                Console.WriteLine($"Masked image saved to: {outputPath}");
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
 * 1. When building a desktop photo‑editing tool that lets users fine‑tune mask edges on a JPEG and instantly see the softened PNG result.
 * 2. When creating a batch script that processes a series of images and needs to experiment with different feather radii to achieve the best blend for each file.
 * 3. When generating PNG assets with soft‑edge cutouts for UI overlays, where the developer must control the feather radius to avoid harsh borders.
 * 4. When preparing images for compositing in video or graphics projects and wants to preview how varying feather sizes affect the transition between foreground and background.
 * 5. When developing a medical‑imaging application that extracts regions of interest from scans and requires adjustable feathering to smooth the mask for accurate analysis.
 */
