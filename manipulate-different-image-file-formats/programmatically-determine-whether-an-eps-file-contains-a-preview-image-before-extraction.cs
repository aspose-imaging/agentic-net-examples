using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.eps";
            string outputPath = "output/preview.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Determine if a raster preview is present
                if (epsImage.HasRasterPreview)
                {
                    Console.WriteLine("Raster preview is present.");

                    // Retrieve the preview image (default format)
                    using (var preview = epsImage.GetPreviewImage())
                    {
                        if (preview != null)
                        {
                            // Save the preview image as PNG
                            var pngOptions = new PngOptions();
                            preview.Save(outputPath, pngOptions);
                            Console.WriteLine($"Preview saved to {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("Preview image could not be retrieved.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No raster preview found in the EPS file.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}