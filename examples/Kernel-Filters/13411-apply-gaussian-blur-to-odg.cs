using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = @"c:\temp\";
        string inputPath = Path.Combine(dataDir, "sample.odg");
        string outputPath = Path.Combine(dataDir, "sample.GaussianBlur.odg");

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to OdgImage to access ODG‑specific members
            OdgImage odgImage = (OdgImage)image;

            // ODG files can contain multiple pages; each page is a RasterImage.
            // Apply the Gaussian blur filter to every page.
            foreach (Image page in odgImage.Pages)
            {
                // Cast the page to RasterImage to use the Filter method
                RasterImage rasterPage = (RasterImage)page;

                // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole page
                rasterPage.Filter(rasterPage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            }

            // Save the modified ODG image back to disk
            odgImage.Save(outputPath);
        }
    }
}