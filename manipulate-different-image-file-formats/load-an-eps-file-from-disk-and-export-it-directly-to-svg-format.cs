using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions();

                // If the image is a vector type, set rasterization options based on its size
                if (image is VectorImage vectorImage)
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    };
                }

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}