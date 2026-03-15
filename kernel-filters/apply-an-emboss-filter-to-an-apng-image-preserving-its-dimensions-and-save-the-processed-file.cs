using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output APNG files
        string inputPath = "input.apng";
        string outputPath = "output_embossed.apng";

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Apply emboss filter to each frame while preserving dimensions
            foreach (var page in apngImage.Pages)
            {
                RasterImage frame = (RasterImage)page;
                frame.Filter(frame.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
            }

            // Save the processed APNG image
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}