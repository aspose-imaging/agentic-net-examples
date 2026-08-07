using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output BMP file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, resize, and save the image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                    {
                        image.CacheData();
                    }

                    // Resize to 640x480 using nearest neighbour resampling
                    image.Resize(640, 480, ResizeType.NearestNeighbourResample);

                    // Save as BMP using default options
                    image.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to convert a collection of user‑uploaded PNG screenshots into BMP format for legacy Windows applications that only accept BMP files, they can batch load, resize to 640×480, and save them using Aspose.Imaging for .NET.
 * 2. When an e‑learning platform must generate uniformly sized thumbnail images from a folder of high‑resolution PNG diagrams for faster page loads, this C# code resizes each to 640×480 and stores them as BMPs for compatibility with older browsers.
 * 3. When a digital signage system requires all promotional PNG assets to be pre‑processed into 640×480 BMP files to meet hardware constraints, developers can automate the conversion with the provided batch processing routine.
 * 4. When a medical imaging workflow needs to standardize PNG scans to a fixed resolution and BMP format before feeding them into a legacy analysis tool, the code demonstrates how to load, resize, and save the images in bulk using Aspose.Imaging.
 * 5. When a game development pipeline must prepare PNG textures for an engine that only supports BMP at 640×480 resolution, this example shows how to programmatically batch convert and resize the assets in C#.
 */