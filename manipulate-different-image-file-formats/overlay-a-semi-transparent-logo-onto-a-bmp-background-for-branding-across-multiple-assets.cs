using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string logoPath = @"C:\Images\logo.png";
        string[] backgroundPaths = new[]
        {
            @"C:\Images\background1.bmp",
            @"C:\Images\background2.bmp",
            @"C:\Images\background3.bmp"
        };
        string outputDirectory = @"C:\Images\Output";

        // Verify logo file exists
        if (!File.Exists(logoPath))
        {
            Console.Error.WriteLine($"File not found: {logoPath}");
            return;
        }

        // Load logo once
        using (RasterImage logo = (RasterImage)Image.Load(logoPath))
        {
            // Optional: ensure logo is cached for faster access
            if (!logo.IsCached) logo.CacheData();

            // Process each background image
            foreach (string bgPath in backgroundPaths)
            {
                if (!File.Exists(bgPath))
                {
                    Console.Error.WriteLine($"File not found: {bgPath}");
                    continue;
                }

                using (RasterImage background = (RasterImage)Image.Load(bgPath))
                {
                    if (!background.IsCached) background.CacheData();

                    // Determine position (bottom‑right with 10px margin)
                    int offsetX = background.Width - logo.Width - 10;
                    int offsetY = background.Height - logo.Height - 10;
                    if (offsetX < 0) offsetX = 0;
                    if (offsetY < 0) offsetY = 0;

                    // Blend logo onto background with 50% opacity (128 out of 255)
                    background.Blend(new Point(offsetX, offsetY), logo, 128);

                    // Prepare output path
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(bgPath) + "_branded.bmp");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create BMP save options with a file source
                    Source source = new FileCreateSource(outputPath, false);
                    BmpOptions bmpOptions = new BmpOptions { Source = source };

                    // Save the composited image
                    background.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}