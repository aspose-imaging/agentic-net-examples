// HOW-TO: Create Transparent Background APNG from PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load source image (single-frame raster image)
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha // support alpha channel
                };

                // Create APNG image with the same dimensions as the source
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Set background color to fully transparent
                    apngImage.BackgroundColor = Color.Transparent;
                    apngImage.HasBackgroundColor = true;

                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add the source image as the first (and only) frame
                    apngImage.AddFrame(sourceImage);

                    // Save the APNG file
                    apngImage.Save();
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
 * 1. When you need to convert a static PNG into an animated PNG with a fully transparent canvas so it displays correctly in browsers and image viewers.
 * 2. When you want to generate APNG assets for a game UI where the background must be invisible to blend with underlying scenes.
 * 3. When an e‑commerce platform requires product images with transparent animation frames that still open in regular PNG viewers.
 * 4. When automating a build pipeline that creates transparent‑background APNGs from source PNGs for marketing banners.
 * 5. When testing compatibility of APNG files with standard PNG viewers by explicitly setting the background color to transparent using Aspose.Imaging in C#.
 */
