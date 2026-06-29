using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\animation_input.webp";
        string outputPath = @"C:\Images\animation_resized_apng.png";

        try
        {
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

                // Resize all frames proportionally
                webPImage.Resize(newWidth, newHeight);

                // Save as APNG (Animated PNG)
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
 * 1. When a mobile app needs to display a lightweight animated WebP preview but must deliver a compatible animated PNG for browsers that don’t support WebP, a developer can load the WebP, halve its size, and save it as APNG.
 * 2. When an e‑learning platform wants to reduce bandwidth by shrinking animated illustrations stored as WebP and then provide them as APNG for cross‑platform playback, this code resizes and converts the animation.
 * 3. When a game UI designer requires animated icons at a smaller resolution for high‑DPI screens and needs them in the APNG format for Unity, the snippet loads the WebP, scales it down, and saves it as an animated PNG.
 * 4. When a content management system automatically generates thumbnail‑size animated previews from user‑uploaded WebP files and stores them as APNG for consistent rendering, the code performs the resize‑and‑convert operation.
 * 5. When a marketing automation tool needs to batch‑process animated WebP banners, halve their dimensions to fit email templates, and output them as APNG to ensure compatibility with most email clients, this example provides the necessary steps.
 */