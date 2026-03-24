using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the image (APNG or single-frame raster)
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is an APNG (multi-frame)
            if (image is ApngImage apngImage)
            {
                // Apply Magic Wand mask to each frame
                foreach (var page in apngImage.Pages)
                {
                    // Each page is a RasterImage
                    var frame = (RasterImage)page;

                    // Create mask based on a reference point (50,50) with a threshold of 100
                    MagicWandTool
                        .Select(frame, new MagicWandSettings(50, 50) { Threshold = 100 })
                        .Apply();
                }

                // Save the modified APNG
                apngImage.Save(outputPath, new ApngOptions());
            }
            // If the loaded image is a single-frame raster image
            else if (image is RasterImage rasterImage)
            {
                // Apply Magic Wand mask to the raster image
                MagicWandTool
                    .Select(rasterImage, new MagicWandSettings(50, 50) { Threshold = 100 })
                    .Apply();

                // Save the result as an APNG (single-frame)
                rasterImage.Save(outputPath, new ApngOptions());
            }
        }
    }
}