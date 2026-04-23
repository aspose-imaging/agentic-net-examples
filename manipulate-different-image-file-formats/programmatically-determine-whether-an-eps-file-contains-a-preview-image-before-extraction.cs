using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "preview.png";

        // Ensure any runtime exception is caught and reported
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output directory
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Determine if a raster preview is present
                if (epsImage.HasRasterPreview)
                {
                    // Retrieve the preview image (default format)
                    using (Image preview = epsImage.GetPreviewImage())
                    {
                        if (preview != null)
                        {
                            // Save the preview image to the specified output path
                            preview.Save(outputPath, new PngOptions());
                            Console.WriteLine($"Preview image extracted and saved to: {outputPath}");
                        }
                        else
                        {
                            // HasRasterPreview was true but GetPreviewImage returned null (unlikely)
                            Console.WriteLine("Raster preview indicated but could not retrieve the preview image.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No raster preview image found in the EPS file.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}