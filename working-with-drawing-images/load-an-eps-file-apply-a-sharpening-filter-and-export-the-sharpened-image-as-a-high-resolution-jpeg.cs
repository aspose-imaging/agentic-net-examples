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
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string tempPngPath = "temp.png";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories for temporary and final output exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and rasterize to a high‑resolution PNG
            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    // Configure rasterization to achieve high resolution
                    VectorRasterizationOptions = new Aspose.Imaging.ImageOptions.EpsRasterizationOptions
                    {
                        PageWidth = 2000,   // desired width in pixels
                        PageHeight = 2000   // desired height in pixels
                    }
                };
                epsImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG as a RasterImage
            using (var image = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)image;

                // Apply sharpening filter to the entire image
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Prepare high‑quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the sharpened image as JPEG
                raster.Save(outputPath, jpegOptions);
            }

            // Clean up temporary PNG file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}