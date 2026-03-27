using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input EPS file path
        string inputPath = "input.eps";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output preview image path (will be used only if a preview exists)
        string outputPath = "output\\preview.png";

        // Ensure the output directory exists (unconditional as required)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Determine whether the EPS file contains a raster preview
            bool hasPreview = epsImage.HasRasterPreview;

            Console.WriteLine($"Has raster preview: {hasPreview}");

            if (hasPreview)
            {
                // Retrieve the preview image (default format)
                using (Image preview = epsImage.GetPreviewImage())
                {
                    if (preview != null)
                    {
                        // Save the preview image to the specified output path
                        var pngOptions = new PngOptions();
                        preview.Save(outputPath, pngOptions);
                        Console.WriteLine($"Preview image saved to: {outputPath}");
                    }
                    else
                    {
                        // This case should not occur when HasRasterPreview is true, but handle gracefully
                        Console.WriteLine("Preview image could not be retrieved.");
                    }
                }
            }
        }
    }
}