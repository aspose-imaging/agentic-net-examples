using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample_blurred.odg";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage to access ODG‑specific members
            OdgImage odgImage = (OdgImage)image;

            // Iterate through all pages (each page is a raster image)
            foreach (Image page in odgImage.Pages)
            {
                // Cast the page to RasterImage to use the Filter method
                var rasterPage = (RasterImage)page;

                // Apply a Gaussian blur filter to the whole page
                // Radius = 5 pixels, Sigma = 4.0 (adjust as needed)
                rasterPage.Filter(
                    rasterPage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));
            }

            // Save the modified ODG image to the specified file
            odgImage.Save(outputPath);
        }
    }
}