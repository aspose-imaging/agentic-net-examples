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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Export options for masking (in‑memory source)
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking to replace background with transparency
            AutoMaskingGraphCutOptions maskingOptions = new AutoMaskingGraphCutOptions
            {
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions,
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1
            };

            // Perform masking
            using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                // Obtain the foreground mask (index 1)
                using (RasterImage foregroundMask = maskingResult[1].GetMask())
                {
                    // Resize mask to original image size
                    foregroundMask.Resize(sourceImage.Width, sourceImage.Height, ResizeType.NearestNeighbourResample);

                    // Apply mask to the source image
                    ImageMasking.ApplyMask(sourceImage, foregroundMask, maskingOptions);
                }
            }

            // Save the result with PNG options
            sourceImage.Save(outputPath, exportOptions);
        }

        // Verify that the background pixel is transparent
        using (RasterImage resultImage = (RasterImage)Image.Load(outputPath))
        {
            // Load the ARGB value of the top‑left pixel
            int[] pixel = resultImage.LoadArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, 1, 1));
            int argb = pixel[0];
            int alpha = (argb >> 24) & 0xFF;

            if (alpha == 0)
            {
                Console.WriteLine("Background removal successful: transparent pixel detected.");
            }
            else
            {
                Console.WriteLine("Background removal failed: pixel is not transparent.");
            }
        }
    }
}