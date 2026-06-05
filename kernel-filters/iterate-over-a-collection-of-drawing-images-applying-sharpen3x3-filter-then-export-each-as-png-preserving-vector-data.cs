using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is VectorImage)
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageWidth = image.Width,
                                PageHeight = image.Height
                            }
                        };

                        using (Image pngImage = Image.Create(pngOptions, image.Width, image.Height))
                        {
                            RasterImage raster = (RasterImage)pngImage;
                            raster.Filter(raster.Bounds, new SharpenFilterOptions(3, 0.0));
                            pngImage.Save();
                        }
                    }
                    else if (image is RasterImage rasterImage)
                    {
                        rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 0.0));
                        PngOptions saveOptions = new PngOptions();
                        rasterImage.Save(outputPath, saveOptions);
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
 * 1. When a CAD application needs to batch‑process engineering drawings (DWG, SVG) to enhance edge clarity with a Sharpen3x3 filter and deliver high‑resolution PNG previews while keeping the original vector geometry intact.
 * 2. When an e‑learning platform automatically converts a library of vector‑based illustration files into web‑ready PNG assets, applying sharpening to improve readability on low‑resolution screens.
 * 3. When a GIS system exports multiple map layers stored as vector images, sharpening the rasterized output and saving them as PNG tiles for fast client‑side rendering.
 * 4. When a marketing team prepares a set of logo files in various vector formats for email newsletters, using the code to batch sharpen and export them as PNGs that retain scalability for future edits.
 * 5. When a document management workflow ingests scanned vector PDFs, applies a 3×3 sharpen filter to each page, and stores the results as PNG files while preserving the underlying vector data for archival purposes.
 */