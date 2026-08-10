// HOW-TO: Extract Each Frame From Multi‑Page TIFF and Save As BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputDirectory = @"C:\Images\Frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access frames
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF image.");
                    return;
                }

                // Iterate over each frame and export to BMP
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP using default BmpOptions
                    tiffImage.Frames[i].Save(outputPath, new BmpOptions());
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
 * 1. When you need to separate individual pages of a multi‑page TIFF scan into separate BMP files for legacy Windows applications.
 * 2. When a document‑management system requires each TIFF frame to be stored as an uncompressed BMP for accurate pixel‑by‑pixel analysis.
 * 3. When converting scanned medical images from TIFF to BMP to feed into a diagnostic tool that only accepts BMP input.
 * 4. When preparing assets for a game engine that cannot read TIFF but can load BMP textures for each frame of an animation.
 * 5. When archiving each page of a multi‑page TIFF as a BMP to ensure compatibility with older printing hardware that only supports BMP files.
 */
