using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.otg";
        string outputPath = @"C:\Temp\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load OTG file into a memory stream
        byte[] fileBytes = File.ReadAllBytes(inputPath);
        using (MemoryStream memoryStream = new MemoryStream(fileBytes))
        {
            // Load the image from the memory stream
            using (Image image = Image.Load(memoryStream))
            {
                // Prepare PNG save options with OTG rasterization settings
                PngOptions pngOptions = new PngOptions();
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
    }
}