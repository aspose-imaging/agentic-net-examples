using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                var filterOptions = new GaussWienerFilterOptions(5, 4.0);
                filterOptions.Brightness = 1.2; // increase brightness

                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                var saveOptions = new BmpOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to enhance the visibility of scanned documents by brightening and softly blurring BMP images before OCR processing.
 * 2. When an application must prepare legacy BMP graphics for web display by applying a 5×5 Gaussian blur and increasing brightness to improve visual appeal.
 * 3. When a batch‑processing tool has to normalize lighting conditions across a collection of BMP screenshots by adjusting kernel coefficients for brightness and blur.
 * 4. When a game asset pipeline requires smoothing and brightening BMP textures to reduce harsh edges and improve in‑game lighting.
 * 5. When a medical imaging system must pre‑process BMP X‑ray images with a Gauss‑Wiener filter to reduce noise while making details clearer through brightness enhancement.
 */