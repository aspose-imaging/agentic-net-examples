using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage (fully qualified to avoid extra using)
            var apngImage = (Aspose.Imaging.FileFormats.Apng.ApngImage)image;

            // Apply Gaussian blur filter to each frame
            foreach (var page in apngImage.Pages)
            {
                var frame = (RasterImage)page;
                frame.Filter(frame.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            }

            // Save the processed APNG using ApngOptions
            ApngOptions saveOptions = new ApngOptions();
            apngImage.Save(outputPath, saveOptions);
        }
    }
}