using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                CmxImage cmxImage = image as CmxImage;
                if (cmxImage == null)
                {
                    Console.Error.WriteLine("Failed to load CMX image.");
                    return;
                }

                // Configure SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // Preserve text as vector shapes
                };

                // Set rasterization options based on the CMX canvas size
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    PageSize = cmxImage.Size
                };
                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                cmxImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}