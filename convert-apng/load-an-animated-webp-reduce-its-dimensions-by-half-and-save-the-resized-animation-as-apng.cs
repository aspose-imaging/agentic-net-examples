using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output\\resized.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Calculate new dimensions (half of original)
                int newWidth = webPImage.Width / 2;
                int newHeight = webPImage.Height / 2;

                // Resize all frames of the animation
                webPImage.Resize(newWidth, newHeight);

                // Save the resized animation as APNG
                webPImage.Save(outputPath, new ApngOptions());
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
 * 1. When a mobile app needs to display a smaller animated WebP banner but the platform only supports APNG, a developer can resize the animation by half and convert it to APNG for seamless playback.
 * 2. When an e‑learning website wants to reduce bandwidth by shrinking animated WebP illustrations and deliver them as APNG files compatible with all modern browsers, this code automates the resizing and format conversion.
 * 3. When a game developer prepares animated UI assets for a low‑resolution mode, they can use this snippet to halve the dimensions of WebP sprites and save them as APNG for the engine’s texture pipeline.
 * 4. When a digital marketing tool generates custom animated stickers from user‑uploaded WebP files, the code ensures the stickers are resized for email newsletters and saved in APNG, which many email clients accept.
 * 5. When a content management system batch‑processes uploaded animated WebP files to create thumbnail previews, the developer can resize each animation to 50 % of its original size and store the result as APNG for fast preview rendering.
 */