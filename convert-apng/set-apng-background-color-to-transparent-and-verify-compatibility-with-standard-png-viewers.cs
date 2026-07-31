using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\input.png";
            string outputPath = "output\\output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (single‑frame raster image)
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Configure APNG creation options with alpha support
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 500 // 500 ms per frame (single frame in this case)
                };

                // Create a new APNG image with the same dimensions as the source
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Set background color to fully transparent
                    apngImage.BackgroundColor = Color.Transparent;
                    apngImage.HasBackgroundColor = true;

                    // Add the source image as the only frame
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
 * 1. When a developer needs to convert a static PNG logo into an animated PNG (APNG) with a fully transparent background so that the image can be overlaid on any web page without a visible rectangle.
 * 2. When a mobile app must generate custom APNG stickers from user‑uploaded PNGs and ensure the background is transparent for seamless integration with chat interfaces that only support standard PNG viewers.
 * 3. When an e‑learning platform creates step‑by‑step tutorial frames as a single‑frame APNG to preserve alpha transparency while guaranteeing that legacy PNG viewers still display the image correctly.
 * 4. When a game engine toolchain programmatically produces APNG assets from existing PNG textures and needs to set the background color to transparent to avoid rendering artifacts in UI overlays.
 * 5. When an automated reporting service embeds transparent APNG charts into PDF documents and must verify that the resulting file remains viewable in any standard PNG viewer without loss of the alpha channel.
 */