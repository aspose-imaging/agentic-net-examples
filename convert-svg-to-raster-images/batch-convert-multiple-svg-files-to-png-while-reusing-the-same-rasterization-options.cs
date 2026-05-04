using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input folder and SVG files to process
            string inputFolder = @"C:\Images\Input";
            string[] svgFiles = new[]
            {
                "image1.svg",
                "image2.svg",
                "image3.svg"
            };

            // Prepare a single instance of rasterization options to be reused
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();

            // Loop through each SVG file
            foreach (string fileName in svgFiles)
            {
                string inputPath = Path.Combine(inputFolder, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set page size based on the loaded image (first iteration sets it, subsequent reuse)
                    rasterOptions.PageSize = image.Size;

                    // Prepare PNG save options with the shared rasterization options
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Determine output path (same name with .png extension)
                    string outputPath = inputPath + ".png";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the rasterized PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}