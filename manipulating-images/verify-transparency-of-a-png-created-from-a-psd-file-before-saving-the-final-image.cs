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
            string inputPath = @"C:\temp\input.psd";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Prepare PNG options with alpha support
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
                };

                // Save to a memory stream first
                using (MemoryStream ms = new MemoryStream())
                {
                    psdImage.Save(ms, pngOptions);
                    ms.Position = 0; // Reset stream position for reading

                    // Load the PNG from the memory stream to verify transparency
                    using (PngImage pngImage = (PngImage)Image.Load(ms))
                    {
                        bool hasAlpha = pngImage.HasAlpha;
                        Console.WriteLine($"PNG has alpha channel: {hasAlpha}");
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Write the PNG data to the final output file
                    File.WriteAllBytes(outputPath, ms.ToArray());
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
 * 1. When a web application must convert user‑uploaded Photoshop PSD files to PNG thumbnails and ensure the resulting PNG retains its alpha transparency before publishing the image.
 * 2. When an e‑commerce platform generates product images from layered PSD assets and needs to confirm that the exported PNG contains an alpha channel so that transparent backgrounds display correctly on the storefront.
 * 3. When a desktop publishing tool automates batch conversion of PSD designs to PNG sprites and wants to programmatically verify transparency to avoid visual artifacts in the final UI.
 * 4. When a mobile game pipeline converts PSD artwork to PNG textures and must check the HasAlpha property to guarantee proper blending of transparent game elements.
 * 5. When a digital marketing service processes client PSD logos into PNG logos for email campaigns and needs to validate that the saved PNG preserves its transparency before sending the assets.
 */