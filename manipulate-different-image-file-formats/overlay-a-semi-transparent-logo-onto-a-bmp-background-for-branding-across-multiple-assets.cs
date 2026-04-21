using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string logoPath = "logo.png";
        string[] backgroundPaths = { "bg1.bmp", "bg2.bmp", "bg3.bmp" };
        string outputDirectory = "output";

        // Validate logo file
        if (!File.Exists(logoPath))
        {
            Console.Error.WriteLine($"File not found: {logoPath}");
            return;
        }

        // Ensure output directory exists (null‑safe)
        if (!string.IsNullOrEmpty(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        // Load the logo once
        using (RasterImage logoImage = (RasterImage)Image.Load(logoPath))
        {
            // Position where the logo will be placed (top‑left corner)
            var logoPosition = new Point(50, 50); // adjust as needed
            byte opacity = 128; // 50% transparent

            foreach (string bgPath in backgroundPaths)
            {
                // Validate background file
                if (!File.Exists(bgPath))
                {
                    Console.Error.WriteLine($"File not found: {bgPath}");
                    continue;
                }

                // Load background BMP
                using (RasterImage background = (RasterImage)Image.Load(bgPath))
                {
                    // Blend the logo onto the background
                    background.Blend(logoPosition, logoImage, opacity);

                    // Prepare output path
                    string outputPath = Path.Combine(outputDirectory,
                        Path.GetFileNameWithoutExtension(bgPath) + "_branded.bmp");

                    // Save the result (default BMP options)
                    background.Save(outputPath);
                }
            }
        }
    }
}