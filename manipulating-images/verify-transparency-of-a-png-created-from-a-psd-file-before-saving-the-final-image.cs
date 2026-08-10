// HOW-TO: Check PNG Transparency After Converting PSD to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.psd";
            string outputPath = @"C:\Images\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save PSD to a memory stream as PNG
                using (MemoryStream pngStream = new MemoryStream())
                {
                    psdImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0; // Reset stream for reading

                    // Load the PNG from the memory stream to inspect transparency
                    using (PngImage pngImage = (PngImage)Image.Load(pngStream))
                    {
                        // Verify if the PNG has an alpha channel (transparency)
                        bool hasAlpha = pngImage.HasAlpha;
                        Console.WriteLine($"PNG has alpha (transparency): {hasAlpha}");

                        // Save the final PNG to the output path
                        pngImage.Save(outputPath, pngOptions);
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
 * 1. When you need to ensure a PNG generated from a Photoshop PSD retains its alpha channel before publishing it on a website.
 * 2. When an automated image pipeline must convert PSD files to PNG and validate that the resulting files contain transparency for proper overlay in UI designs.
 * 3. When a desktop application processes user‑uploaded PSD assets and must confirm the exported PNG includes transparency before saving it to disk.
 * 4. When you are building a batch conversion tool that checks each converted PNG for an alpha channel to avoid losing transparent regions in printed materials.
 * 5. When a server‑side service uses Aspose.Imaging to transform PSD images to PNG and requires a runtime check of the HasAlpha property to decide further processing steps.
 */
