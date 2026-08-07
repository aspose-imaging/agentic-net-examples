using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Resize to half of the original dimensions
                image.Resize(image.Width / 2, image.Height / 2);

                // Apply Emboss3x3 filter using convolution filter options
                image.Filter(
                    image.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When creating thumbnail previews for a web gallery and want a stylized embossed effect on the reduced‑size PNG images using C# and Aspose.Imaging.
 * 2. When generating printable product labels that must be half the original resolution but still retain a textured look by applying the Emboss3x3 convolution filter to the PNG.
 * 3. When developing a mobile app that downloads high‑resolution PNG assets, resizes them to save bandwidth, and enhances visual depth with an emboss filter before displaying them.
 * 4. When automating a batch process that prepares PNG icons for a UI theme, scaling them down to 50 % and adding an emboss effect to improve their perceived sharpness.
 * 5. When building a document conversion pipeline that converts source PNG diagrams to smaller, embossed PNGs for inclusion in PDF reports using Aspose.Imaging in .NET.
 */