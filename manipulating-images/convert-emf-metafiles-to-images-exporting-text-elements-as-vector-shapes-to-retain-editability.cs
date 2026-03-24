using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\input.emf";
        string outputPath = @"C:\Temp\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options based on the source image size
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG save options: export text as vector shapes
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true,
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as SVG with text converted to shapes
            image.Save(outputPath, saveOptions);
        }
    }
}