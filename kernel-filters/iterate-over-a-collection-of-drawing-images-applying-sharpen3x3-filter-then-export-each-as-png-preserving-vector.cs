using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));
                    }

                    PngOptions pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to batch‑process a folder of vector‑based drawing files (e.g., SVG, EMF, WMF) in a C# application, sharpen each image with a 3×3 convolution filter, and save the results as PNG while keeping the original vector information intact.
 * 2. When an automated build pipeline must enhance the visual clarity of engineering schematics before publishing them to a web portal, applying Aspose.Imaging’s Sharpen3x3 filter to every source drawing and exporting the output as high‑quality PNG files.
 * 3. When a desktop utility is required to prepare a collection of scanned technical drawings for OCR or annotation tools, using the ConvolutionFilterOptions to improve edge definition and then converting the images to PNG format with Aspose.Imaging for .NET.
 * 4. When a SaaS platform offers on‑the‑fly image sharpening for user‑uploaded vector graphics, iterating through the uploaded files, applying the Sharpen3x3 filter, and delivering PNG previews that retain the original vector data.
 * 5. When a legacy CAD system exports drawings as raster images and a developer needs to programmatically re‑sharpen and re‑encode them as PNGs in a .NET service, leveraging Aspose.Imaging’s raster image filtering and PNGOptions to maintain scalability and quality.
 */