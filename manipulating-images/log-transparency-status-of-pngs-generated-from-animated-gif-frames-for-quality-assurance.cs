using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "animated.gif";
            string outputDirectory = "output_pngs";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (called before each save as required)
            Directory.CreateDirectory(outputDirectory);

            // Load the animated GIF
            using (Image gifImage = Image.Load(inputPath))
            {
                // Cast to GifImage to access page count (frames)
                GifImage gif = gifImage as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("The input file is not a GIF image.");
                    return;
                }

                int frameCount = gif.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    // Prepare PNG save options with MultiPageOptions to export a single frame
                    var pngOptions = new PngOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(i, i + 1))
                    };

                    // Build output path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");

                    // Ensure the directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as PNG
                    gif.Save(outputPath, pngOptions);

                    // Load the saved PNG to check transparency (alpha channel)
                    using (Image pngImage = Image.Load(outputPath))
                    {
                        var png = pngImage as PngImage;
                        bool hasAlpha = png?.HasAlpha ?? false;
                        Console.WriteLine($"Frame {i}: PNG has alpha = {hasAlpha}");
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
 * 1. When a QA engineer needs to confirm that each frame extracted from an animated GIF keeps its original alpha channel after conversion to PNG, they can run this C# Aspose.Imaging code to save the frames and log the transparency status for every PNG file.
 * 2. When a web developer wants to ensure that animated GIF assets used on a website are correctly transformed into transparent PNG sprites for faster loading, this code provides a repeatable way to generate the PNGs and record whether transparency was preserved.
 * 3. When a mobile app team is building a feature that replaces GIF animations with PNG sequences and must verify that no opaque pixels are introduced, they can use this script to export each frame and automatically log any loss of transparency.
 * 4. When a digital archivist is migrating legacy GIF animations to a lossless PNG format and requires an audit trail of transparency integrity, the code extracts each frame, saves it as PNG, and writes a transparency log for quality assurance.
 * 5. When a CI/CD pipeline includes image processing validation steps, this C# example can be integrated to convert animated GIF frames to PNG, check the alpha channel of each output, and log the results to detect transparency issues before release.
 */