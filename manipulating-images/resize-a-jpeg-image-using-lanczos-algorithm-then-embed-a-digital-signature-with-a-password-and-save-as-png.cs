// HOW-TO: Resize JPEG with Lanczos and Add Password Protected Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Load JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Resize using Lanczos algorithm (example size 800x600)
                raster.Resize(800, 600, ResizeType.LanczosResample);

                // Embed digital signature with a valid password
                raster.EmbedDigitalSignature("secure123");

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image as PNG
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to shrink a high‑resolution JPEG for web display while preserving quality with Lanczos resampling and then protect the image by embedding a password‑protected digital signature before converting it to PNG.
 * 2. When an e‑commerce platform must generate thumbnail PNGs from product JPEG photos, ensuring the thumbnails are resized accurately and tamper‑evident by adding a secure signature.
 * 3. When a document management system archives scanned JPEG documents as PNG files and requires each file to carry a cryptographic signature that can only be verified with a known password.
 * 4. When a mobile app uploads user‑provided JPEG images, resizes them to a standard size using Lanczos, embeds a signature to prevent unauthorized modifications, and stores them as PNG for consistent rendering.
 * 5. When a legal compliance tool needs to convert client‑submitted JPEG evidence into PNG, resize it to fit reporting templates, and embed a password‑protected digital signature to guarantee integrity.
 */
