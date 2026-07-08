using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output_contrast_lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific methods
                GifImage gifImage = (GifImage)image;

                // Adjust contrast (value in range [-100, 100])
                gifImage.AdjustContrast(50f);

                // Prepare lossy GIF save options
                GifOptions saveOptions = new GifOptions
                {
                    // Enable lossy compression by setting MaxDiff > 0
                    MaxDiff = 80,
                    // Optional: improve palette quality
                    DoPaletteCorrection = true
                };

                // Save the high‑contrast GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to improve the visual impact of an animated GIF banner while reducing its download size for faster page loads, they can use this C# code with Aspose.Imaging to boost contrast and apply lossy GIF compression.
 * 2. When an e‑learning platform needs to enhance the readability of instructional GIFs and store them efficiently on a CDN, the code can adjust contrast and compress the animation using Aspose.Imaging’s GifOptions in .NET.
 * 3. When a mobile app generates user‑created GIF stickers and must keep the file size under a limit without losing the high‑contrast effect, developers can call AdjustContrast and set MaxDiff in GifOptions as shown.
 * 4. When a digital marketing team automates batch processing of promotional GIFs to make colors pop and meet email size restrictions, this C# snippet provides a repeatable workflow with Aspose.Imaging’s contrast and lossy compression features.
 * 5. When a social media analytics tool extracts GIFs from posts and wants to standardize their appearance and storage footprint, the code demonstrates how to programmatically increase contrast and apply lossy compression in .NET.
 */