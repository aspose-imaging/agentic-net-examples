using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "sample_converted.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to OdgImage to access pages
                OdgImage odgImage = (OdgImage)image;

                // Assume the ODG has at least one page
                if (odgImage.Pages.Length == 0)
                {
                    Console.Error.WriteLine("No pages found in the ODG image.");
                    return;
                }

                // Get the first page and treat it as a raster image
                Image pageImage = odgImage.Pages[0];
                RasterImage rasterPage = (RasterImage)pageImage;

                // Apply a median filter with size 5 to the entire page
                rasterPage.Filter(rasterPage.Bounds, new MedianFilterOptions(5));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered raster page as JPEG
                rasterPage.Save(outputPath, new JpegOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}