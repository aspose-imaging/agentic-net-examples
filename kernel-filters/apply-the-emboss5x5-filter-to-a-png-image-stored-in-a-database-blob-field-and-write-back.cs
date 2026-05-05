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
            string outputPath = "output\\result.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read image data from the "database" BLOB (simulated by file read)
            byte[] blobData = File.ReadAllBytes(inputPath);

            // Load image from memory stream
            using (MemoryStream inputStream = new MemoryStream(blobData))
            using (Image image = Image.Load(inputStream))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Emboss5x5 convolution filter
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));

                // Save the processed image back to a memory stream
                using (MemoryStream outputStream = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    raster.Save(outputStream, pngOptions);

                    // Write the result back to the "database" BLOB (simulated by file write)
                    File.WriteAllBytes(outputPath, outputStream.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}