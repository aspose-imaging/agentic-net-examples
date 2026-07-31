using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\animation.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG as a raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100u, // 100 ms per frame
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image bound to the output file
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add the single source frame (default frame time applied)
                    apngImage.AddFrame(sourceImage);

                    // Save the APNG (output path already bound via FileCreateSource)
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
 * 1. When a developer needs to turn a static PNG logo into a looping animated PNG for web banners, applying a 100 ms frame delay to create a subtle pulse effect.
 * 2. When building a C# desktop application that generates lightweight APNG sprites from single‑frame PNG assets for UI animations without using GIF.
 * 3. When automating the creation of animated product thumbnails for an e‑commerce site, converting each product’s high‑resolution PNG into a 100 ms per frame APNG preview.
 * 4. When integrating Aspose.Imaging into a server‑side service that produces animated status icons from a single PNG template, ensuring a consistent 100 ms frame timing across all outputs.
 * 5. When developing a game asset pipeline that converts single‑frame PNG textures into APNG sequences with a fixed 100 ms delay for use as animated UI elements in web‑based games.
 */