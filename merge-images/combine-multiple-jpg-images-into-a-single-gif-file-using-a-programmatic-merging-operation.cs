using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputDirectory = "Input";
        string outputDirectory = "Output";
        string outputPath = Path.Combine(outputDirectory, "combined.gif");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Get all JPG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*")
            .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        if (files.Length == 0)
        {
            Console.WriteLine("No JPG files found in the input directory.");
            return;
        }

        // Validate the first file exists
        if (!File.Exists(files[0]))
        {
            Console.Error.WriteLine($"File not found: {files[0]}");
            return;
        }

        // Load the first image and create the GIF with it
        using (RasterImage firstFrame = (RasterImage)Image.Load(files[0]))
        {
            using (GifImage gif = new GifImage(new GifFrameBlock(firstFrame)))
            {
                // Add remaining frames
                for (int i = 1; i < files.Length; i++)
                {
                    string filePath = files[i];
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage frame = (RasterImage)Image.Load(filePath))
                    {
                        gif.AddPage(frame);
                    }
                }

                // Save the combined GIF
                gif.Save(outputPath);
            }
        }
    }
}