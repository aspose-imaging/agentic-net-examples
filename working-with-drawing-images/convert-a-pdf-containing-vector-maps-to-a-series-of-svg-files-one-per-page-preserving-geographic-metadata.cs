using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.pdf");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PngOptions options = new PngOptions())
                    {
                        image.Save(outputPath, options);
                    }
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
 * 1. When a GIS analyst needs to generate raster thumbnails of each page of a multi‑page PDF map for quick preview in a web portal, they can use this C# routine to batch‑convert the PDFs to PNG images.
 * 2. When an e‑learning platform must display printable PDF worksheets as responsive images on mobile devices, the code can automatically transform the PDFs in an input folder into PNG files for faster loading.
 * 3. When a document management system requires archiving scanned PDF contracts as lossless PNGs to preserve visual fidelity while enabling image‑based search, developers can employ this script to process all PDFs in a directory.
 * 4. When a marketing team wants to repurpose PDF brochures as high‑resolution PNG assets for social media ads, the program provides a simple way to convert each brochure page to a PNG file.
 * 5. When a legacy reporting tool only accepts PNG images for chart rendering, developers can use this code to convert generated PDF reports into PNGs before feeding them into the tool.
 */