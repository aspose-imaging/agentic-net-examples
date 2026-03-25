using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page TIFF
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Iterate through each frame
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                // Use the image resolution to decide a frame duration (example logic)
                double dpi = Math.Max(tiffImage.HorizontalResolution, tiffImage.VerticalResolution);
                int frameDurationMs = dpi > 300 ? 100 : 200; // 100 ms for high‑res, otherwise 200 ms

                // Placeholder: Aspose.Imaging does not expose a direct frame‑duration property.
                // If needed, you could store this value in custom metadata or use it in further processing.
                Console.WriteLine($"Frame {i + 1}: DPI={dpi}, Duration={frameDurationMs} ms");
            }

            // Save the TIFF (no changes made to the image itself)
            tiffImage.Save(outputPath);
        }
    }
}