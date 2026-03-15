using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output PNG file path
        string outputPath = "output.png";
        // Desired dimensions after resizing
        int newWidth = 800;
        int newHeight = 600;

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Resize the WMF image using nearest neighbour resampling
            wmfImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Prepare PNG save options with vector rasterization settings
            var pngOptions = new PngOptions();
            var rasterOptions = new WmfRasterizationOptions
            {
                // Set the page size to match the resized image dimensions
                PageSize = wmfImage.Size
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the resized image as PNG
            wmfImage.Save(outputPath, pngOptions);
        }
    }
}