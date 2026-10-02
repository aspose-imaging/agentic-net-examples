// HOW-TO: Batch Sharpen All PNG Images In A Folder Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    double[,] kernel = new double[,]
                    {
                        {  0, -1,  0 },
                        { -1,  5, -1 },
                        {  0, -1,  0 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + "_sharpened.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically enhance the clarity of a large set of product photos stored as PNGs before uploading them to an e‑commerce site.
 * 2. When you want to preprocess scanned PNG documents by applying a sharpening filter to improve text readability for OCR pipelines.
 * 3. When you are building a desktop utility that prepares game asset sprites by batch‑sharpening PNG files to make edges more defined.
 * 4. When you have a folder of PNG screenshots that require a quick visual boost before embedding them into a PowerPoint presentation.
 * 5. When you need to integrate an automated image‑processing step into a CI/CD workflow that sharpens all PNG assets before packaging a mobile app.
 */
