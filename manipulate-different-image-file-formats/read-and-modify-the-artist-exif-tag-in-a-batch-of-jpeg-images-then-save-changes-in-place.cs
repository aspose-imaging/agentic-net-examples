// HOW-TO: Update Artist EXIF Tag in Multiple JPEG Images Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.AllDirectories);
            foreach (string inputPath in files)
            {
                string extension = Path.GetExtension(inputPath);
                if (!string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = inputPath;
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    var exif = image.ExifData;
                    if (exif != null)
                    {
                        exif.Artist = "New Artist";
                    }

                    image.Save(outputPath);
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
 * 1. When a photographer wants to add or replace the artist name across a whole collection of JPEG photos before uploading to a portfolio site.
 * 2. When a digital asset management system requires a consistent Artist EXIF field for all images to enable proper search and categorization.
 * 3. When a batch of legacy JPEG files lacks proper attribution and needs the correct photographer name embedded automatically.
 * 4. When preparing images for a stock‑photo marketplace that mandates the Artist tag to match the contributor’s registered name.
 * 5. When a software tool must programmatically correct metadata after renaming or moving JPEG files to ensure compliance with copyright metadata standards.
 */
