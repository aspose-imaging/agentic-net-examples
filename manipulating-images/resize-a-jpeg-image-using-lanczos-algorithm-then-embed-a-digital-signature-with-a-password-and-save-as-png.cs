using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";
            string password = "mySecret";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Resize using Lanczos algorithm (example size 800x600)
                int newWidth = 800;
                int newHeight = 600;
                jpegImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Embed digital signature with password
                jpegImage.EmbedDigitalSignature(password);

                // Save as PNG
                PngOptions pngOptions = new PngOptions();
                jpegImage.Save(outputPath, pngOptions);
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
 * 1. When a web application must generate thumbnail PNGs from user‑uploaded JPEG photos while preserving visual quality with Lanczos resampling and protecting the images with a password‑protected digital signature.
 * 2. When an e‑commerce platform needs to convert high‑resolution product JPEGs to smaller PNGs for faster page loads, using Aspose.Imaging’s Lanczos algorithm and embedding a signature to verify authenticity.
 * 3. When a digital asset management system requires batch processing of JPEG artwork to create PNG previews of 800×600 pixels and embed a secure digital signature to prevent tampering.
 * 4. When a mobile backend service resizes uploaded JPEG screenshots to a standard size, saves them as PNG for lossless storage, and adds a password‑protected digital signature for compliance auditing.
 * 5. When a document‑generation tool converts scanned JPEG pages into PNG images with high‑quality Lanczos scaling and embeds a digital signature to ensure the integrity of the final PDF output.
 */