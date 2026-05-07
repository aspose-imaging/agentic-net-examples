using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Prepare TIFF options with high resolution
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                // Create a raster TIFF image with the same dimensions as the vector image
                using (Image rasterImage = Image.Create(tiffOptions, vectorImage.Width, vectorImage.Height))
                {
                    // Draw the vector image onto the raster canvas
                    Graphics graphics = new Graphics(rasterImage);
                    graphics.DrawImage(vectorImage, new Point(0, 0));

                    // Apply emboss filter using convolution kernel
                    TiffImage tiffImage = (TiffImage)rasterImage;
                    tiffImage.Filter(tiffImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                    // Save the rasterized and filtered TIFF (output path already bound)
                    rasterImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}