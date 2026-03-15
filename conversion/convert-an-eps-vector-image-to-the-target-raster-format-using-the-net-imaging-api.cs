using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        // Input EPS file path (default or from command line)
        string inputPath = args.Length > 0 ? args[0] : "input.eps";
        // Output raster image path (default or from command line)
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Set rasterization options to define output size
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = image.Width,   // preserve original width
                PageHeight = image.Height  // preserve original height
            };

            // Configure PNG options with the vector rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the EPS as a raster PNG image
            image.Save(outputPath, pngOptions);
        }
    }
}