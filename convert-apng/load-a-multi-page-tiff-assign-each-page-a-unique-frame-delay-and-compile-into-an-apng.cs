// HOW-TO: Create Animated APNG from Multi‑Page TIFF with Custom Frame Delays in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animated.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image tiffImage = Image.Load(inputPath))
            {
                if (tiffImage is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    // Use the first page to determine canvas size
                    using (RasterImage firstPage = (RasterImage)multipage.Pages[0])
                    {
                        if (!firstPage.IsCached) firstPage.CacheData();

                        // Prepare APNG creation options
                        ApngOptions createOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        // Create the APNG image
                        using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, firstPage.Width, firstPage.Height))
                        {
                            // Remove the default empty frame
                            apngImage.RemoveAllFrames();

                            // Add each TIFF page as a frame with a unique delay
                            for (int i = 0; i < multipage.PageCount; i++)
                            {
                                using (RasterImage page = (RasterImage)multipage.Pages[i])
                                {
                                    if (!page.IsCached) page.CacheData();

                                    // Example: delay increases by 100 ms per page
                                    uint frameDelay = (uint)((i + 1) * 100);
                                    apngImage.AddFrame(page, frameDelay);
                                }
                            }

                            // Save the resulting APNG
                            apngImage.Save();
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image or contains no pages.");
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
 * 1. When you need to turn a scanned multi‑page document (TIFF) into a lightweight animated PNG for web preview with per‑page timing.
 * 2. When you want to generate an animated product showcase by converting each layer of a multi‑page TIFF into frames with individual delays using C#.
 * 3. When you have a series of medical imaging slices stored as a TIFF stack and must create an APNG to visualize the sequence with custom frame intervals.
 * 4. When you are building a desktop application that exports user‑created multi‑page drawings as an animated PNG with precise control over each frame’s display time.
 * 5. When you need to automate the conversion of archival TIFF animations into APNG files for compatibility with modern browsers while preserving frame‑by‑frame timing.
 */
