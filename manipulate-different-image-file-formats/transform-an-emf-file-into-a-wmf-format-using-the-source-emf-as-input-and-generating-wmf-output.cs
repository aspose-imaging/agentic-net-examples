using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class EmfToWmfConverter
{
    static void Main()
    {
        // Path to the source EMF file
        string inputFile = @"C:\Images\source.emf";

        // Path for the generated WMF file
        string outputFile = @"C:\Images\converted.wmf";

        // Load the EMF image using the unified Image.Load method
        using (Image image = Image.Load(inputFile))
        {
            // Prepare rasterization options for WMF output.
            // PageSize is set to the original image size to preserve dimensions.
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the loaded image as WMF using WmfOptions.
            image.Save(outputFile, new WmfOptions { VectorRasterizationOptions = rasterizationOptions });
        }
    }
}