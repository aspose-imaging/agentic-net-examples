// HOW-TO: Batch Convert DjVu Pages to PNG Using Rectangle Crop in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    // Define the region to export (example values)
                    Rectangle exportArea = new Rectangle(0, 0, 500, 500);
                    int pageIndex = 0; // first page

                    PngOptions options = new PngOptions();
                    options.MultiPageOptions = new DjvuMultiPageOptions(pageIndex, exportArea);

                    string outputPath = Path.Combine(outputDirectory,
                        $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    djvu.Save(outputPath, options);
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
 * 1. When you need to extract a specific region from scanned DjVu documents and save it as PNG thumbnails for a web gallery.
 * 2. When processing a batch of DjVu files to generate preview images of the first page for a document management system.
 * 3. When automating the creation of PNG assets from DjVu archives for inclusion in a mobile app that only supports PNG.
 * 4. When you want to programmatically extract a defined rectangle from each DjVu file to feed into an OCR pipeline that requires PNG input.
 * 5. When converting multiple DjVu files on a server into PNGs with consistent dimensions for printing or further image analysis.
 */
