using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (Image loadedImage = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel data
                using (RasterImage raster = (RasterImage)loadedImage)
                {
                    // Create a BMP image from the raster image.
                    // This constructor preserves the alpha channel and original bit depth when possible.
                    using (BmpImage bmpImage = new BmpImage(raster))
                    {
                        // Save the BMP image to the specified output path
                        bmpImage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}