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
        // Hardcoded input and output paths
        string inputPath = "static.png";
        string outputPath = "static_apng.png";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the static raster image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Prepare APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    // Optional: set a default frame duration (e.g., 500 ms)
                    DefaultFrameTime = 500,
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

                    // Add the single static frame
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
 * 1. When an e‑commerce platform wants to future‑proof product thumbnails by saving them as APNG while still supporting legacy systems that expect a single static PNG, this code creates an APNG with only the original frame to maintain backward compatibility.
 * 2. When a mobile game engine reads PNG assets but the asset pipeline has been upgraded to output APNG, developers can use this snippet to wrap a static PNG into an APNG so the engine continues to display the image correctly.
 * 3. When a content management system migrates legacy PNG icons to the APNG format for possible animation, but some icons remain static, this code ensures those icons are saved as APNG files that still render as regular PNGs in browsers that only support static images.
 * 4. When an automated build script processes a batch of images and must guarantee that any file saved as APNG will not break third‑party tools expecting a single frame, the example shows how to remove the default empty frame and add the original raster image as the sole frame.
 * 5. When a developer implements a fallback for email newsletters that embed APNG images, this code generates a single‑frame APNG that email clients treat as a normal PNG, ensuring consistent rendering across all clients.
 */