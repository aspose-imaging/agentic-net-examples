using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToSvgConverter
{
    static void Main()
    {
        // Path to the source TIFF raster image
        string inputFile = @"C:\Images\source.tif";

        // Desired path for the resulting SVG vector graphic
        string outputFile = @"C:\Images\result.svg";

        // Load the TIFF image using Aspose.Imaging's unified loader
        using (Image tiffImage = Image.Load(inputFile))
        {
            // Configure rasterization options: set the page size to match the source image dimensions
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = tiffImage.Size,
                // Optional: define background color if needed
                // BackgroundColor = Color.White
            };

            // Prepare SVG save options and attach the rasterization settings
            var svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Render all text as vector shapes to preserve fidelity
                TextAsShapes = true
            };

            // Save the image as SVG using the configured options
            tiffImage.Save(outputFile, svgSaveOptions);
        }
    }
}