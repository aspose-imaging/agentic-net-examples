using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input directory containing JPG files and output PNG path
        string inputDirectory = "InputJpgs";
        string outputPath = "Output/combined.png";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Get JPG files
        string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found to process.");
            return;
        }

        // Verify each input file exists (redundant after GetFiles but follows rule)
        foreach (string file in jpgFiles)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }
        }

        // Load images and collect sizes
        List<RasterImage> images = new List<RasterImage>();
        List<Size> sizes = new List<Size>();
        foreach (string file in jpgFiles)
        {
            RasterImage img = (RasterImage)Image.Load(file);
            images.Add(img);
            sizes.Add(img.Size);
        }

        // Calculate canvas dimensions (horizontal concatenation)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Prepare PNG options with bound source
        PngOptions pngOptions = new PngOptions
        {
            Source = new FileCreateSource(outputPath, false)
        };

        // Optional: set OTG rasterization options for in‑memory processing
        pngOptions.VectorRasterizationOptions = new OtgRasterizationOptions
        {
            PageSize = new Size(canvasWidth, canvasHeight)
        };

        // Create canvas image
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            for (int i = 0; i < images.Count; i++)
            {
                RasterImage img = images[i];
                // Define destination rectangle on the canvas
                Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                // Copy pixel data
                canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                offsetX += img.Width;
            }

            // Save the bound canvas (no path needed)
            canvas.Save();
        }

        // Dispose loaded images
        foreach (var img in images)
        {
            img.Dispose();
        }

        Console.WriteLine($"Combined image saved to: {outputPath}");
    }
}