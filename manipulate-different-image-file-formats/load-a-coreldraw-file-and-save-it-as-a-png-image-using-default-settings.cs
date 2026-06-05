using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.png";

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

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Use default PNG options
                var pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to display a CorelDRAW illustration on a browser, a developer can use this code to convert the .cdr file to a PNG image that browsers natively support.
 * 2. When an automated batch job must generate thumbnail previews for a library of CorelDRAW designs, the code can load each .cdr file and save a PNG snapshot with default compression.
 * 3. When integrating a document management system that stores vector graphics as .cdr files, a developer can use this snippet to render those files as PNGs for quick visual search results.
 * 4. When creating a reporting tool that embeds graphics from legacy CorelDRAW files into PDF or Word reports, the code provides a simple way to rasterize the .cdr into a PNG before insertion.
 * 5. When building a cross‑platform mobile app that consumes image assets, a developer can pre‑process CorelDRAW assets on the server by converting them to PNG using Aspose.Imaging’s default settings.
 */