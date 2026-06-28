using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

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
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options (you can adjust as needed)
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Truecolor,
                    BitDepth = 8
                };

                // Save the image in PNG format
                image.Save(outputPath, pngOptions);
            }

            Console.WriteLine($"Image successfully converted and saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors gracefully
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to convert user‑uploaded JPEG photos to PNG for lossless storage while ensuring missing files or permission issues are caught gracefully.
 * 2. When a desktop batch‑processing tool must read JPEG images from a configurable folder, create the output directory if it doesn’t exist, and save them as PNG using Aspose.Imaging with error handling to prevent crashes.
 * 3. When an automated build pipeline generates thumbnails by loading source JPEG assets, applying PNG save options, and wrapping the conversion in try‑catch to log any runtime exceptions.
 * 4. When a cloud service processes incoming image streams, validates the source file path, converts the JPEG to a true‑color 8‑bit PNG, and uses exception handling to return a meaningful error response to the client.
 * 5. When a legacy .NET application upgrades its image handling code to use Aspose.Imaging for JPEG‑to‑PNG conversion and needs robust try‑catch blocks to manage unexpected I/O or format errors.
 */