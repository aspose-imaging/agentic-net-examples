// HOW-TO: Resize EPS to 1024x768 and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output\\result.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to the required dimensions using Mitchell interpolation
                image.Resize(1024, 768, ResizeType.Mitchell);

                // Prepare TIFF save options (default format)
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the resized image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert a vector EPS logo to a fixed‑size TIFF for inclusion in a printed catalog.
 * 2. When a web service must generate 1024×768 preview thumbnails from EPS artwork and store them as TIFF files.
 * 3. When automating a batch workflow that resizes EPS diagrams to match a standard document layout before archiving them as TIFF.
 * 4. When integrating Aspose.Imaging in a C# application to downscale EPS drawings for a GIS system that only accepts TIFF images.
 * 5. When preparing EPS illustrations for a medical imaging system that requires TIFF format with specific pixel dimensions.
 */
