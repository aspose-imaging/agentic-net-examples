// HOW-TO: Batch Convert Multiple CDR Files to 256‑Color GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".gif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    var gifOptions = new GifOptions
                    {
                        ColorResolution = 8,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        }
                    };

                    cdrImage.Save(outputPath, gifOptions);
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
 * 1. When you need to automate the conversion of a folder of CorelDRAW (CDR) designs into web‑friendly 256‑color GIFs for faster page loads.
 * 2. When a legacy graphics pipeline requires rasterizing vector CDR artwork to GIF with a fixed palette for compatibility with older browsers.
 * 3. When you must create static GIF thumbnails from many CDR files in one run to populate a product catalog.
 * 4. When a reporting tool expects images in GIF format with a limited color depth, and you need to convert all source CDR files programmatically.
 * 5. When you are building a CI/CD step that validates CDR assets by converting them to GIF and checking the output size automatically.
 */
