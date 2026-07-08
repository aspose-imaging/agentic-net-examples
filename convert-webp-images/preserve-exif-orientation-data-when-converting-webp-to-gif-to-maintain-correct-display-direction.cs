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
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

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

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Apply EXIF orientation if present
                webPImage.AutoRotate();

                // Prepare GIF save options and keep original metadata
                GifOptions gifOptions = new GifOptions
                {
                    KeepMetadata = true
                };

                // Save as GIF
                webPImage.Save(outputPath, gifOptions);
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
 * 1. When a web application needs to display user‑uploaded WebP photos in legacy browsers that only support GIF, while preserving the original EXIF orientation so the images appear upright.
 * 2. When an e‑commerce platform converts product images from WebP to animated GIF for email newsletters and must keep the correct rotation defined in the image’s metadata.
 * 3. When a mobile app syncs images to a server that stores them as GIF for archival, and the conversion code must automatically apply the EXIF orientation to avoid sideways thumbnails.
 * 4. When a digital asset management system batch‑processes WebP files into GIF thumbnails for preview panes, ensuring the AutoRotate method respects the original orientation tags.
 * 5. When a social media scheduler generates GIF versions of WebP memes for cross‑platform posting and needs to retain the photographer’s intended orientation without manual image editing.
 */