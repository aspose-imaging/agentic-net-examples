using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenApngExample
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = @"c:\temp\";
        string inputPath = Path.Combine(dataDir, "input.apng");
        string outputPath = Path.Combine(dataDir, "output_sharpened.apng");

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage to access APNG‑specific members
            ApngImage apng = (ApngImage)image;

            // Apply a sharpen filter to the whole image area
            // SharpenFilterOptions(radius, sigma) – radius = 5, sigma = 4.0
            apng.Filter(apng.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            apng.Save(outputPath);
        }
    }
}