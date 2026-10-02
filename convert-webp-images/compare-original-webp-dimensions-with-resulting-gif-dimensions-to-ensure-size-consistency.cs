// HOW-TO: Verify WebP to GIF Conversion Keeps Original Image Dimensions in C# (Aspose.Imaging for .NET)
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
            // Hardcoded paths
            string inputWebPPath = "input.webp";
            string outputGifPath = "output.gif";

            // Input file existence check
            if (!File.Exists(inputWebPPath))
            {
                Console.Error.WriteLine($"File not found: {inputWebPPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath) ?? ".");

            // Load WebP image
            using (WebPImage webpImage = (WebPImage)Image.Load(inputWebPPath))
            {
                int originalWidth = webpImage.Width;
                int originalHeight = webpImage.Height;

                // Save as GIF
                GifOptions gifOptions = new GifOptions();
                webpImage.Save(outputGifPath, gifOptions);

                // Load resulting GIF
                using (GifImage gifImage = (GifImage)Image.Load(outputGifPath))
                {
                    int gifWidth = gifImage.Width;
                    int gifHeight = gifImage.Height;

                    // Compare dimensions
                    if (originalWidth == gifWidth && originalHeight == gifHeight)
                    {
                        Console.WriteLine("Success: GIF dimensions match the original WebP dimensions.");
                    }
                    else
                    {
                        Console.WriteLine($"Mismatch: Original WebP ({originalWidth}x{originalHeight}) vs GIF ({gifWidth}x{gifHeight}).");
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
 * 1. When you need to batch‑convert WebP assets to GIF while guaranteeing that the output files retain the exact width and height of the source images.
 * 2. When validating that a third‑party service’s WebP‑to‑GIF conversion does not alter image dimensions before displaying them in a responsive UI.
 * 3. When performing automated tests to ensure that Aspose.Imaging’s GIF export preserves the original pixel size of WebP graphics.
 * 4. When generating GIF previews of WebP pictures for email newsletters and must keep the original dimensions to avoid layout shifts.
 * 5. When troubleshooting mismatched image sizes after conversion and need a quick C# script to compare WebP and GIF dimensions.
 */
