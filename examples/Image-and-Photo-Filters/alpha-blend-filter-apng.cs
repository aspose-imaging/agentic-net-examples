using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output APNG file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the existing APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Apply Alpha Blending filter to the whole image
            apng.Filter(
                apng.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ImageBlendingFilterOptions());

            // Save the modified APNG image
            apng.Save(outputPath, new ApngOptions());
        }
    }
}