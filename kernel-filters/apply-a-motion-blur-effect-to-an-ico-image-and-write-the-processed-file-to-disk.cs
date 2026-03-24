using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (creates even if path is null -> current directory)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to IcoImage to access ICO‑specific members
            IcoImage icoImage = image as IcoImage;
            if (icoImage == null)
            {
                Console.Error.WriteLine("Loaded image is not an ICO image.");
                return;
            }

            // Create motion blur (motion Wiener) filter options
            // Length = 10, Brightness = 1.0, Angle = 90 degrees
            var motionBlurOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);

            // Apply the filter to the whole image bounds
            icoImage.Filter(icoImage.Bounds, motionBlurOptions);

            // Save the processed ICO image
            icoImage.Save(outputPath);
        }
    }
}