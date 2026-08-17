// HOW-TO: Apply Lossy Compression to Animated GIF Created from TIFF Sequence in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input/Output directory validation (mandatory block)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            var tiffFiles = files.Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                                             f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                                 .ToArray();

            if (tiffFiles.Length == 0)
            {
                Console.WriteLine("No TIFF files found in input directory.");
                return;
            }

            // Verify first input file exists
            string firstPath = tiffFiles[0];
            if (!File.Exists(firstPath))
            {
                Console.Error.WriteLine($"File not found: {firstPath}");
                return;
            }

            using (RasterImage firstFrame = (RasterImage)Image.Load(firstPath))
            {
                // Create GIF with dimensions of the first frame
                using (GifImage gif = new GifImage(new GifFrameBlock((ushort)firstFrame.Width, (ushort)firstFrame.Height)))
                {
                    // Add first frame
                    gif.AddPage(firstFrame);

                    // Add remaining frames
                    for (int i = 1; i < tiffFiles.Length; i++)
                    {
                        string framePath = tiffFiles[i];
                        if (!File.Exists(framePath))
                        {
                            Console.Error.WriteLine($"File not found: {framePath}");
                            return;
                        }

                        using (RasterImage frame = (RasterImage)Image.Load(framePath))
                        {
                            gif.AddPage(frame);
                        }
                    }

                    // Configure lossy compression
                    GifOptions gifOptions = new GifOptions
                    {
                        MaxDiff = 80 // recommended lossy compression level
                    };

                    string outputPath = Path.Combine(outputDirectory, "output.gif");
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    gif.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to reduce the file size of an animated GIF generated from multiple TIFF frames while keeping the animation smooth.
 * 2. When a web application must serve lightweight animated images created from high‑resolution TIFF scans to improve page load times.
 * 3. When an e‑learning platform wants to convert a series of TIFF lecture slides into a compressed GIF for offline viewing without losing frame order.
 * 4. When a digital archiving system requires lossy compression of TIFF‑based animations to meet storage quotas while preserving visual fidelity.
 * 5. When a mobile app processes TIFF image sequences into GIFs and needs to apply compression to stay within bandwidth limits.
 */
