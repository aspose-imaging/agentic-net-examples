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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                // Prepare APNG options (default frame time will be overridden per frame)
                ApngOptions apngOptions = new ApngOptions
                {
                    DefaultFrameTime = 100 // placeholder, will be set per frame
                };

                // Create an APNG image with the size of the first frame
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    apngOptions,
                    tiffImage.Frames[0].Width,
                    tiffImage.Frames[0].Height))
                {
                    // Remove the automatically created first frame
                    apngImage.RemoveAllFrames();

                    // Add each TIFF frame as an APNG frame
                    foreach (TiffFrame tiffFrame in tiffImage.Frames)
                    {
                        // Cast the frame to RasterImage to access resolution properties
                        RasterImage raster = (RasterImage)tiffFrame;

                        // Determine frame duration based on horizontal resolution (fallback to 100 ms)
                        uint frameDuration = 100;
                        if (raster.HorizontalResolution > 0)
                        {
                            // Example: higher DPI -> shorter display time
                            frameDuration = (uint)(1000 / raster.HorizontalResolution);
                            if (frameDuration == 0) frameDuration = 1;
                        }

                        // Set the default frame time for this frame
                        apngImage.DefaultFrameTime = frameDuration;

                        // Add the frame to the APNG
                        apngImage.AddFrame(raster);
                    }

                    // Save the resulting APNG
                    apngImage.Save(outputPath);
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
 * 1. When a developer needs to turn a multi‑page TIFF scanned document into an animated PNG for web preview, using each page’s DPI to set the display time of each frame.
 * 2. When building a C# application that converts high‑resolution medical imaging TIFF series into an APNG slideshow where the pixel density of each slice determines how long it stays visible.
 * 3. When creating an automated pipeline that transforms multi‑page TIFF receipts into a compact APNG animation, with the horizontal resolution of each page controlling the frame delay for better readability.
 * 4. When developing a digital publishing tool that exports layered TIFF artwork as an animated PNG, leveraging Aspose.Imaging to read the resolution of each layer and assign appropriate frame durations.
 * 5. When implementing a C# utility that generates an APNG from a multi‑page TIFF satellite image stack, using the resolution metadata of each frame to calculate realistic animation timing for GIS applications.
 */