using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure masking to replace background with transparent color
                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    Args = new AutoMaskingArgs(),
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    }
                };

                // Perform masking
                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                {
                    // Retrieve foreground image (masked result)
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        // Save the foreground image as PNG
                        foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            // Verify that the background pixel is transparent
            using (RasterImage resultImage = (RasterImage)Image.Load(outputPath))
            {
                // Load ARGB pixel at (0,0)
                int[] pixelData = resultImage.LoadArgb32Pixels(new Rectangle(0, 0, 1, 1));
                int pixel = pixelData[0];
                int alpha = (pixel >> 24) & 0xFF;

                if (alpha == 0)
                {
                    Console.WriteLine("Background removal test passed: pixel is transparent.");
                }
                else
                {
                    Console.WriteLine($"Background removal test failed: pixel alpha = {alpha}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}