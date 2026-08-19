// HOW-TO: Extract First Frame from Animated APNG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputPath = "output\\static.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated APNG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apng = image as ApngImage;
                if (apng != null && apng.PageCount > 0)
                {
                    // Extract the first frame
                    using (RasterImage firstFrame = (RasterImage)apng.Pages[0])
                    {
                        // Save the first frame as a static PNG
                        firstFrame.Save(outputPath, new PngOptions());
                    }
                }
                else
                {
                    // Fallback: save the whole image as PNG if not an APNG
                    image.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a thumbnail from an animated APNG for a website preview.
 * 2. When you must extract the initial frame of a sprite sheet stored as an APNG to use as a static icon.
 * 3. When converting user‑uploaded animated PNGs to a single PNG for compatibility with systems that only support static images.
 * 4. When creating a fallback image for email newsletters that cannot display animated PNGs.
 * 5. When preprocessing animation assets in a game pipeline to obtain a non‑animated PNG for texture atlases.
 */
