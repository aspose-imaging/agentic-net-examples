using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                int originalWidth = webPImage.Width;
                int originalHeight = webPImage.Height;

                // Save as GIF
                webPImage.Save(outputPath, new GifOptions());

                // Load the resulting GIF to verify dimensions
                using (GifImage gifImage = (GifImage)Image.Load(outputPath))
                {
                    int gifWidth = gifImage.Width;
                    int gifHeight = gifImage.Height;

                    // Compare dimensions
                    if (originalWidth == gifWidth && originalHeight == gifHeight)
                    {
                        Console.WriteLine($"Dimensions match: {originalWidth}x{originalHeight}");
                    }
                    else
                    {
                        Console.WriteLine($"Dimension mismatch: WebP ({originalWidth}x{originalHeight}) vs GIF ({gifWidth}x{gifHeight})");
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
 * 1. When a developer needs to batch‑convert user‑uploaded WebP avatars to GIFs for legacy browsers while guaranteeing the avatar size stays unchanged.
 * 2. When an e‑commerce platform generates product animation GIFs from original WebP files and must verify that the displayed dimensions match the catalog specifications.
 * 3. When a content‑management system automatically creates animated GIF previews from WebP assets and needs to confirm that the preview does not distort the original layout.
 * 4. When a mobile app syncs image assets to a server that only accepts GIFs, and the sync routine must ensure the converted GIF retains the original width and height for UI consistency.
 * 5. When a digital‑marketing tool resizes campaign images to WebP, then re‑exports them as GIFs for email newsletters and must check that the conversion preserves the exact pixel dimensions.
 */