using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image data into a memory stream
            byte[] inputBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(inputBytes))
            {
                using (Image image = Image.Load(inputStream))
                {
                    // Cast to RasterImage for filtering
                    RasterImage raster = (RasterImage)image;

                    // Apply a Gaussian blur convolution filter
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image to a memory stream, then write to file
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        raster.Save(outputStream, pngOptions);
                        File.WriteAllBytes(outputPath, outputStream.ToArray());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}