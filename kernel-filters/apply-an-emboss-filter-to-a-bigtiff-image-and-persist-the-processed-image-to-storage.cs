using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Images\input.bigtiff";
        string outputPath = @"C:\Images\output_emboss.tiff";

        // Load the BigTiff image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to BigTiffImage to access TIFF-specific functionality
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Apply the Emboss filter to the entire image
            // The EmbossFilterOptions class provides the emboss effect parameters.
            bigTiff.Filter(
                bigTiff.Bounds,
                new EmbossFilterOptions());

            // Save the processed image using TIFF options (preserves original format)
            bigTiff.Save(outputPath, new TiffOptions());
        }
    }
}