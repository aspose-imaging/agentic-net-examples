using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.tif";
            string outputPath = @"C:\Temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Export to APNG with infinite looping (NumPlays = 0)
                image.Save(outputPath, new ApngOptions { NumPlays = 0 });
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
 * 1. When a developer needs to display a scanned multi‑page TIFF document as a continuously looping animated PNG on a website, they can use this C# code with Aspose.Imaging to convert the TIFF to an APNG with infinite looping.
 * 2. When creating an interactive product catalog, a developer can transform a multi‑page TIFF of product images into an animated APNG that loops forever, providing a seamless preview in a web app.
 * 3. When building a splash screen or loading animation for a desktop application, a developer can convert a multi‑page TIFF sprite sheet into an APNG that repeats endlessly using the NumPlays = 0 setting.
 * 4. When reviewing a series of medical imaging slices stored as a multi‑page TIFF, a developer can generate an animated APNG that loops infinitely for quick visual assessment without manual navigation.
 * 5. When preparing layered map data saved as a multi‑page TIFF, a developer can produce an animated APNG that continuously cycles through the layers, enabling an engaging map overlay in a GIS web portal.
 */