using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class DeconvolutionExample
{
    static void Main()
    {
        // Paths to the source TGA image and the destination file
        string inputPath = "input.tga";
        string outputPath = "output.tga";

        // Load the TGA image using Aspose.Imaging's lifecycle pattern
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to a TgaImage to access TGA‑specific members
            TgaImage tgaImage = (TgaImage)image;

            // Create deconvolution filter options (Gauss‑Wiener filter)
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the entire image bounds
            tgaImage.Filter(tgaImage.Bounds, deconvOptions);

            // Save the processed image to the specified output file
            tgaImage.Save(outputPath);
        }
    }
}