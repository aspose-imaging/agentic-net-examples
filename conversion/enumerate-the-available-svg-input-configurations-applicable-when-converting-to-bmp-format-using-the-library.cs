using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the SVG file (replace with your actual file path)
        string svgPath = "input.svg";

        // Load the SVG image using Aspose.Imaging
        using (Image image = Image.Load(svgPath))
        {
            // Verify that the loaded image is an SVG image
            if (image is SvgImage)
            {
                Console.WriteLine("Available SVG input configurations (SvgImageType) for BMP conversion:");
                
                // Enumerate all values of the SvgImageType enumeration
                foreach (SvgImageType type in Enum.GetValues(typeof(SvgImageType)))
                {
                    // All enum values represent possible SVG input types; they can be rasterized to BMP.
                    Console.WriteLine($"- {type}");
                }
            }
            else
            {
                Console.WriteLine("The specified file is not an SVG image.");
            }
        }
    }
}