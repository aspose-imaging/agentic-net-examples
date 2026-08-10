// HOW-TO: Verify WebP to GIF Conversion Keeps Original Dimensions in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.webp";
            string outputPath = "Output/sample_converted.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the original WebP image and capture its dimensions
            using (WebPImage webP = new WebPImage(inputPath))
            {
                int webPWidth = webP.Width;
                int webPHeight = webP.Height;

                // Convert WebP to GIF using default GifOptions
                using (GifOptions gifOptions = new GifOptions())
                {
                    webP.Save(outputPath, gifOptions);
                }

                // Load the resulting GIF image and capture its dimensions
                using (GifImage gif = (GifImage)Image.Load(outputPath))
                {
                    int gifWidth = gif.Width;
                    int gifHeight = gif.Height;

                    // Compare dimensions and report the result
                    if (webPWidth == gifWidth && webPHeight == gifHeight)
                    {
                        Console.WriteLine($"Dimensions match: {webPWidth}x{webPHeight}");
                    }
                    else
                    {
                        Console.WriteLine($"Dimension mismatch: WebP ({webPWidth}x{webPHeight}) vs GIF ({gifWidth}x{gifHeight})");
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
 * 1. When you need to ensure that converting a WebP image to GIF does not alter its width and height for layout consistency.
 * 2. When validating an image processing pipeline that requires the source and target formats to retain identical dimensions.
 * 3. When generating GIF previews from WebP assets and must guarantee they fit the same UI space as the originals.
 * 4. When automating batch conversions and need to log any size mismatches for quality control.
 * 5. When integrating Aspose.Imaging into a content management system and want to confirm that format conversion retains the original image dimensions.
 */
