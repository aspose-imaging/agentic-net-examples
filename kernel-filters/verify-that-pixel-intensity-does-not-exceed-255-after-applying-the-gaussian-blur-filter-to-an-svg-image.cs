using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Failed to rasterize the SVG image.");
                    return;
                }

                // Apply Gaussian blur filter (size=5, sigma=4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Verify that no pixel intensity exceeds 255
                bool exceeds = false;
                for (int y = 0; y < rasterImage.Height && !exceeds; y++)
                {
                    for (int x = 0; x < rasterImage.Width; x++)
                    {
                        var color = rasterImage.GetPixel(x, y);
                        if (color.R > 255 || color.G > 255 || color.B > 255)
                        {
                            exceeds = true;
                            break;
                        }
                    }
                }

                if (exceeds)
                {
                    Console.WriteLine("Pixel intensity exceeds 255 after applying Gaussian blur.");
                }
                else
                {
                    Console.WriteLine("All pixel intensities are within the 0-255 range.");
                }

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}