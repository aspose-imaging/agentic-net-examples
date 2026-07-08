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
            // Hard‑coded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name, .png extension)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save it as APNG with 3 loops
                using (Image image = Image.Load(inputPath))
                {
                    var apngOptions = new ApngOptions
                    {
                        NumPlays = 3 // default loop count
                    };
                    image.Save(outputPath, apngOptions);
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
 * 1. When a developer needs to use Aspose.Imaging for .NET to batch convert a folder of multi‑page TIFF scans into animated PNGs that automatically loop three times for web galleries.
 * 2. When an automated C# script must process medical imaging TIFF files and output APNGs with a default NumPlays value of three for inclusion in presentation slides.
 * 3. When a content management system requires converting uploaded TIFF assets to APNG format using ApngOptions so that each animation repeats exactly three times across browsers.
 * 4. When a desktop utility built in C# has to generate lightweight animated PNGs from high‑resolution TIFF textures for game UI assets, limiting the animation to three cycles with Aspose.Imaging.
 * 5. When a nightly build pipeline needs to transform archived TIFF documentation into APNG files that play three loops, ensuring consistent playback in interactive PDFs.
 */