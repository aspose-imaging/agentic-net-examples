using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class SvgToBmpConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Temp\example.svg";

        // Desired output BMP file path
        string outputBmpPath = @"C:\Temp\example.bmp";

        // Load the SVG image using the unified Image.Load method
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Save the loaded image as BMP using default BMP options
            svgImage.Save(outputBmpPath, new BmpOptions());
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}