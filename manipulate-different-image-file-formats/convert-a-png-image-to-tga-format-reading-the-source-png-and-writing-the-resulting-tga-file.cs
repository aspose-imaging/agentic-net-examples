using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.tga";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image as a RasterImage
        using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
        {
            // Convert the raster image to a TGA image and save it
            using (TgaImage tgaImage = new TgaImage(rasterImage))
            {
                tgaImage.Save(outputPath);
            }
        }
    }
}