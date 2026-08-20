// HOW-TO: Find Optimal Threshold for JPEG Binarization and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            int[] thresholds = new int[] { 50, 100, 150, 200 };

            foreach (int threshold in thresholds)
            {
                string outputPath = Path.Combine(outputDirectory, $"masked_{threshold}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.BinarizeFixed((byte)threshold);

                    PngOptions saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    image.Save(outputPath, saveOptions);
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
 * 1. When you need to convert a colorful JPEG photograph into a high‑contrast black‑and‑white mask and compare several threshold levels to choose the best one for a multicolored background.
 * 2. When you want to generate a series of PNG images with alpha channel from a single JPEG to test how different binarization thresholds affect the size and quality of the resulting mask.
 * 3. When you are building an automated preprocessing step that extracts foreground objects from JPEGs by applying fixed thresholds before feeding the images into a computer‑vision pipeline.
 * 4. When you must evaluate the impact of various threshold values on the compression ratio of PNG masks created from a JPEG source with complex colors.
 * 5. When you are creating a batch tool in C# that experiments with threshold settings to fine‑tune the mask generation for graphic design or OCR preprocessing tasks.
 */
