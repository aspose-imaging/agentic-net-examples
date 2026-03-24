using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG file paths
        string[] inputPaths = new string[]
        {
            @"C:\temp\img1.jpg",
            @"C:\temp\img2.jpg",
            @"C:\temp\img3.jpg"
        };

        // Hardcoded output PNG file path
        string outputPath = @"C:\temp\combined.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load all input images
        List<Image> images = new List<Image>();
        try
        {
            foreach (string inputPath in inputPaths)
            {
                Image img = Image.Load(inputPath);
                images.Add(img);
            }

            // Determine combined image dimensions (horizontal concatenation)
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Image img in images)
            {
                totalWidth += img.Width;
                if (img.Height > maxHeight)
                    maxHeight = img.Height;
            }

            // Create a new PNG image with the calculated dimensions
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image combined = Image.Create(pngOptions, totalWidth, maxHeight))
            {
                // Draw each source image onto the combined canvas
                Graphics graphics = new Graphics(combined);
                int offsetX = 0;
                foreach (Image img in images)
                {
                    graphics.DrawImage(img, offsetX, 0);
                    offsetX += img.Width;
                }

                // Save the combined image (output path already set in options)
                combined.Save();
            }
        }
        finally
        {
            // Dispose all loaded images
            foreach (Image img in images)
            {
                img.Dispose();
            }
        }
    }
}