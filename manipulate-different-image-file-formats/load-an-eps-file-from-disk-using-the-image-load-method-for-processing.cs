using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.eps";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load EPS image with default load options
            var loadOptions = new EpsLoadOptions();
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Example processing: output basic info
                Console.WriteLine($"Loaded EPS image. Width: {image.Width}, Height: {image.Height}");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the image as PNG
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
 * 1. When a developer needs to convert an EPS vector file to a PNG raster image for web display, they can use Image.Load with EpsLoadOptions and save with PngOptions.
 * 2. When a developer wants to verify that an EPS file exists on disk and retrieve its width and height before performing further image processing, this code provides a simple C# solution.
 * 3. When a developer automates a batch job in a .NET build pipeline to transform multiple EPS logos into PNGs, the Image.Load and Save pattern can be applied repeatedly.
 * 4. When a developer extracts basic metadata such as dimensions from an EPS file to generate thumbnail previews, the loaded Image object supplies the required information.
 * 5. When a developer integrates EPS to PNG conversion into a desktop application that previews vector graphics, this code demonstrates the necessary C# operations and file‑format handling.
 */