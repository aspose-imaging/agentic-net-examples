using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ApngToSvgConverter
{
    static void Main()
    {
        // Path to the source APNG file
        string inputPath = "input.apng";

        // Desired output SVG file path
        string outputPath = "output.svg";

        // Load the APNG image using Aspose.Imaging's unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Obtain default vector rasterization options based on the image dimensions.
            // The first argument is the background color (white), followed by width and height.
            VectorRasterizationOptions vectorOptions = (VectorRasterizationOptions)
                image.GetDefaultOptions(new object[] { Color.White, image.Width, image.Height });

            // Configure SVG saving options and attach the rasterization settings.
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save the loaded APNG as a scalable SVG vector file.
            image.Save(outputPath, svgOptions);
        }
    }
}