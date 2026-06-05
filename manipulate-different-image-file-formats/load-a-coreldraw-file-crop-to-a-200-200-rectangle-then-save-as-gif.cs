using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_cropped.gif";

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

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access vector-specific features
                CdrImage cdrImage = (CdrImage)image;

                // Define a 200x200 rectangle starting at (0,0)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Crop the image
                cdrImage.Crop(cropArea);

                // Save the cropped image as GIF
                GifOptions gifOptions = new GifOptions();
                cdrImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to generate a 200 × 200 thumbnail GIF from a CorelDRAW (CDR) illustration for a web catalog, they can load the CDR file, crop the region, and save it as a GIF using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform requires a fixed‑size preview of a product design stored in a CorelDRAW file, this code extracts a 200 px square area and outputs it as a lightweight GIF for quick loading.
 * 3. When automating the creation of animated email banners that start with a static 200 × 200 frame taken from a CDR source, the snippet loads the vector file, crops the desired region, and saves it as a GIF.
 * 4. When a content management system must display a consistent 200 px square icon derived from a CorelDRAW logo, developers can use this code to crop the logo and convert it to a GIF for cross‑browser compatibility.
 * 5. When a batch‑processing tool needs to convert multiple CorelDRAW drawings into small GIF snapshots for documentation, the example shows how to load each CDR, crop a 200 × 200 area, and save the result as a GIF with Aspose.Imaging.
 */