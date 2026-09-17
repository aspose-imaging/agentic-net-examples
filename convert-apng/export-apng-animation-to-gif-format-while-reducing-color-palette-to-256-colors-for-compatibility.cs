// HOW-TO: Convert APNG Animation to GIF with 256‑Color Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
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

            string inputPath = Path.Combine(inputDirectory, "input.apng");
            string outputPath = Path.Combine(outputDirectory, "output.gif");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    image.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to serve animated images to browsers that only support GIF, they can convert APNG files to GIF while limiting colors to 256 for compatibility.
 * 2. When an email marketing system must embed animated graphics that conform to the 256‑color GIF standard, this code transforms APNG assets into compliant GIFs.
 * 3. When a legacy desktop application only reads GIF animations, developers can use this snippet to import modern APNG animations by converting them to GIF format.
 * 4. When optimizing file size for mobile apps that require small animated assets, converting APNG to a 256‑color GIF reduces bandwidth while preserving animation.
 * 5. When a content management workflow automates batch processing of user‑uploaded APNGs, this code enables automatic conversion to GIF for consistent display across all platforms.
 */
