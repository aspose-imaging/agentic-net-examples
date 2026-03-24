using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\Multipage.tif";
        string outputPath = @"C:\Images\MultipageEdited.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        // Load the multipage image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to IMultipageImage to access pages
            if (image is IMultipageImage multipageImage)
            {
                // Set a batch operation that will be executed before each page is saved
                // Here we rotate every page by 90 degrees
                multipageImage.PageExportingAction = (int index, Image page) =>
                {
                    // Rotate the current page
                    page.Rotate(90);
                };
            }

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}