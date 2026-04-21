using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output_blurred.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;

                // Apply Gaussian blur to the entire GIF
                gif.Filter(gif.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Set lossy compression options
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 80 // Enable lossy compression
                };

                // Save the blurred GIF with lossy compression
                gif.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}