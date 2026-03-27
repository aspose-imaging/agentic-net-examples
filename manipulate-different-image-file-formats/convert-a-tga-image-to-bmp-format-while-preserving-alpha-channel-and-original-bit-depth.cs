using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.tga";
        string outputPath = "output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image as a raster image
        using (RasterImage tgaImage = (RasterImage)Image.Load(inputPath))
        {
            // Create a BMP image from the loaded raster image
            using (BmpImage bmpImage = new BmpImage(tgaImage))
            {
                // Save the BMP image, preserving alpha channel and original bit depth
                bmpImage.Save(outputPath);
            }
        }
    }
}