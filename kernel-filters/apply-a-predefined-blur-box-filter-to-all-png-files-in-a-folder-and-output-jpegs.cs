// HOW-TO: Apply Blur Box Filter to PNGs and Save as JPEGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    double[,] blurBoxKernel = new double[,]
                    {
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 },
                        { 0.04, 0.04, 0.04, 0.04, 0.04 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(blurBoxKernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically blur sensitive areas in a batch of PNG images before publishing them as JPEGs on a website.
 * 2. When you want to reduce file size and protect privacy by applying a uniform blur to all PNG assets and converting them to JPEG for faster loading.
 * 3. When you are preparing product screenshots in PNG format for an e‑commerce catalog and require a soft blur effect before saving them as JPEG thumbnails.
 * 4. When you must process a folder of PNG graphics on a server, apply a box convolution filter for a smoothing effect, and store the results as JPEG files for downstream workflows.
 * 5. When you need a simple C# script that iterates through a directory, blurs each PNG image, and outputs JPEG versions for use in email newsletters or social media.
 */
