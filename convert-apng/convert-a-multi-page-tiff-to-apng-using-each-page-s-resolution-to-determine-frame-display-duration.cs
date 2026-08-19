// HOW-TO: Convert Multi‑Page TIFF to APNG Using DPI for Frame Timing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Use the first frame to obtain dimensions for the APNG canvas
                using (RasterImage firstFrame = (RasterImage)tiffImage.Frames[0])
                {
                    // Create APNG options (no specific defaults needed here)
                    ApngOptions apngOptions = new ApngOptions();

                    // Create an empty APNG image with the same size as the first frame
                    using (ApngImage apngImage = (ApngImage)Image.Create(
                        apngOptions,
                        firstFrame.Width,
                        firstFrame.Height))
                    {
                        // Remove the default single frame that exists after creation
                        apngImage.RemoveAllFrames();

                        // Add each TIFF frame as an APNG frame
                        foreach (TiffFrame tiffFrame in tiffImage.Frames)
                        {
                            RasterImage rasterFrame = (RasterImage)tiffFrame;

                            // Determine frame duration from the frame's horizontal resolution (DPI)
                            // If DPI is unavailable or zero, fall back to a default of 100 ms
                            double dpi = rasterFrame.HorizontalResolution;
                            uint frameTime = dpi > 0 ? (uint)(1000.0 / dpi) : 100;

                            // Set the default frame time for the next added frame
                            apngImage.DefaultFrameTime = frameTime;

                            // Add the raster frame to the APNG
                            apngImage.AddFrame(rasterFrame);
                        }

                        // Save the resulting APNG
                        apngImage.Save(outputPath);
                    }
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
 * 1. When you need to turn a scanned multi‑page document saved as TIFF into an animated PNG where each page’s display time matches its original DPI, this code automates the conversion.
 * 2. When generating web‑ready animations from scientific microscopy image stacks stored in TIFF, you can preserve the exposure timing by mapping each frame’s resolution to APNG frame delays.
 * 3. When creating product‑catalog slideshows from high‑resolution TIFF assets, the script converts them to APNG with per‑frame durations reflecting the intended viewing speed.
 * 4. When migrating legacy TIFF‑based animation sequences to a modern, lossless format for mobile apps, this approach keeps the original frame timing based on DPI values.
 * 5. When building an automated pipeline that ingests multi‑page TIFF invoices and outputs animated PNGs for quick preview, the code ensures each page appears for the correct interval derived from its resolution.
 */
