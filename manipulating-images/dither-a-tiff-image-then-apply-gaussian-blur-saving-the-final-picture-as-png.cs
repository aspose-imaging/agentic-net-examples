using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            TiffImage tiff = (TiffImage)image;

            // Apply dithering (Floyd‑Steinberg, 8‑bit palette)
            tiff.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8, null);

            // Apply Gaussian blur (radius 5, sigma 4.0)
            tiff.Filter(tiff.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the result as PNG
            PngOptions pngOptions = new PngOptions();
            tiff.Save(outputPath, pngOptions);
        }
    }
}