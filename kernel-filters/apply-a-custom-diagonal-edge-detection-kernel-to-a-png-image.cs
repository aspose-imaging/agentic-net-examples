using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] kernel = new double[,]
                {
                    { -1, -1, 0 },
                    { -1,  0, 1 },
                    {  0,  1, 1 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);

                image.Save(outputPath, options);
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
 * 1. When a developer needs to highlight diagonal edges in a PNG screenshot for visual inspection, they can apply a custom convolution kernel using Aspose.Imaging in C#.
 * 2. When an image‑processing pipeline must detect slanted lines in scanned PNG documents before OCR, the code can run a diagonal edge‑detection filter on the raster image.
 * 3. When a game‑asset workflow requires automatic edge enhancement of PNG sprite sheets, the developer can use this convolution filter to accentuate diagonal contours.
 * 4. When a medical‑imaging application wants to emphasize diagonal structures in PNG‑encoded X‑ray images for diagnostic review, the code provides a quick C# solution.
 * 5. When a web service generates thumbnails with highlighted diagonal features from user‑uploaded PNG images, the developer can employ this Aspose.Imaging filter to preprocess the images.
 */