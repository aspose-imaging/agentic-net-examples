using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string tempRasterPath = "temp.png";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Save the vector CDR as a raster PNG (temporary file)
            cdrImage.Save(tempRasterPath, new PngOptions());
        }

        // Load the temporary raster image
        using (RasterImage rasterImage = (RasterImage)Image.Load(tempRasterPath))
        {
            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Verify transparency: check if any pixel has alpha less than 255
            bool hasTransparency = false;
            int width = rasterImage.Width;
            int height = rasterImage.Height;
            for (int y = 0; y < height && !hasTransparency; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int argb = rasterImage.GetArgb32Pixel(x, y);
                    int alpha = (argb >> 24) & 0xFF;
                    if (alpha != 255)
                    {
                        hasTransparency = true;
                        break;
                    }
                }
            }

            Console.WriteLine(hasTransparency
                ? "The image contains transparency."
                : "The image does not contain transparency.");

            // Prepare GIF save options (optional palette correction)
            var gifOptions = new GifOptions
            {
                DoPaletteCorrection = true
            };

            // Save the blurred image as GIF
            rasterImage.Save(outputPath, gifOptions);
        }

        // Clean up temporary raster file
        if (File.Exists(tempRasterPath))
        {
            try
            {
                File.Delete(tempRasterPath);
            }
            catch
            {
                // Ignored: if deletion fails, it's not critical for the main task
            }
        }
    }
}