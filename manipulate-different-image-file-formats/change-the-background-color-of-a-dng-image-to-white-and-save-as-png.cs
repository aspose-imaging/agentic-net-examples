using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.dng";
        string outputPath = @"c:\temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access DNG-specific properties
                DngImage dngImage = (DngImage)image;

                // Set background color to white
                dngImage.HasBackgroundColor = true;
                dngImage.BackgroundColor = Color.White;

                // Save as PNG
                dngImage.Save(outputPath, new PngOptions());
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
 * 1. When a photographer needs to embed raw DNG files into a web gallery that only supports PNG, they can use Aspose.Imaging for .NET to set a white background and convert the images to PNG format.
 * 2. When an e‑commerce platform receives product photos in DNG format and must display them on a white background across browsers, developers can apply this C# code to replace transparent areas with white and save as PNG.
 * 3. When a digital archiving system must standardize legacy raw DNG scans to a lossless PNG with a consistent white canvas for printing, the code provides a straightforward way to adjust the background color and export the file.
 * 4. When a mobile app backend processes user‑uploaded raw DNG images and needs to generate PNG thumbnails with a solid white background for consistent UI rendering, this Aspose.Imaging snippet handles the conversion.
 * 5. When a scientific imaging pipeline requires converting raw DNG microscope captures to PNG while ensuring any empty pixel regions appear white for analysis, developers can use this C# example to set the background color and save the result.
 */