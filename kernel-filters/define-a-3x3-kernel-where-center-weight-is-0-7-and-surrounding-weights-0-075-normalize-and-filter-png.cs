using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer wants to reduce noise in a PNG screenshot by applying a custom 3x3 smoothing kernel with a dominant center weight, they can use this code to normalize the kernel and filter the image.
 * 2. When building a web service that automatically enhances uploaded PNG avatars, the code can apply the defined kernel to subtly sharpen edges while preserving overall brightness.
 * 3. When creating a batch processing tool that prepares PNG assets for mobile games, the developer can use the kernel to achieve consistent visual quality across different resolutions.
 * 4. When integrating image preprocessing into a machine‑learning pipeline that expects normalized PNG inputs, the code provides a simple way to apply a custom convolution filter before feeding the data to the model.
 * 5. When developing a desktop application that lets users adjust the emphasis of the central pixel in a PNG filter effect, the code demonstrates how to define, normalize, and apply a 3x3 kernel using Aspose.Imaging for .NET.
 */