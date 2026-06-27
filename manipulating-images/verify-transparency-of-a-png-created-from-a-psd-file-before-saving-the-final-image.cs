using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.psd";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Prepare PNG options with alpha support
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save PSD to a memory stream as PNG to inspect transparency
                using (MemoryStream ms = new MemoryStream())
                {
                    psdImage.Save(ms, pngOptions);
                    ms.Position = 0; // Reset stream position for reading

                    // Load the PNG from the memory stream
                    using (Image pngImage = Image.Load(ms))
                    {
                        // Cast to PngImage to access HasAlpha property
                        PngImage png = (PngImage)pngImage;
                        bool hasAlpha = png.HasAlpha;
                        Console.WriteLine($"PNG has alpha channel: {hasAlpha}");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the final PNG to disk
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
 * 1. When a developer needs to convert a Photoshop PSD file to a PNG while confirming that the resulting image retains its transparent background before saving it to disk.
 * 2. When an automated image pipeline must validate that a generated PNG contains an alpha channel after conversion from a layered PSD to avoid visual artifacts in a web UI.
 * 3. When a batch processing tool has to ensure that exported PNG assets from PSD sources preserve transparency for use in mobile apps or game sprites.
 * 4. When a quality‑control script must load a PSD, save it to a memory stream as PNG, check the HasAlpha property, and only then write the final file to a shared folder.
 * 5. When integrating Aspose.Imaging in a C# application that needs to detect and log the presence of an alpha channel in a PNG derived from a PSD before publishing it to a content management system.
 */