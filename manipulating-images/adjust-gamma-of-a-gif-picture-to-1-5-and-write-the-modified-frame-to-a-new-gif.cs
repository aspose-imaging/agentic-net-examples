using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.gif";
        string outputPath = @"c:\temp\sample.adjusted.gif";

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

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Adjust gamma to 1.5 for all channels
                gifImage.AdjustGamma(1.5f);

                // Save the modified image as a new GIF
                gifImage.Save(outputPath, new GifOptions());
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
 * 1. When a web developer wants to improve the brightness of animated GIF icons for a dark‑themed website by increasing gamma to 1.5 before publishing.
 * 2. When a desktop application processes user‑uploaded GIF stickers and needs to standardize their contrast by applying a 1.5 gamma correction and saving the result as a new file.
 * 3. When a game developer prepares sprite animations stored as GIFs and must boost their visual intensity for better visibility on low‑light screens using Aspose.Imaging’s AdjustGamma method.
 * 4. When an e‑learning platform automatically enhances the legibility of instructional GIF diagrams by adjusting gamma to 1.5 and storing the adjusted version in a separate folder.
 * 5. When a batch‑processing script in C# needs to correct the exposure of multiple GIF frames in a marketing email campaign by applying a 1.5 gamma shift and outputting the modified GIFs.
 */