using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
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

            // Load the CorelDRAW (CDR) image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access vector-specific functionality
                CdrImage cdrImage = (CdrImage)image;

                // Define a 200x200 rectangle starting at the top-left corner (0,0)
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Crop the image to the defined rectangle
                cdrImage.Crop(cropArea);

                // Save the cropped image as GIF
                cdrImage.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to extract a thumbnail from a CorelDRAW (CDR) design for a web gallery, they can load the CDR file, crop a 200×200 region, and save it as a GIF.
 * 2. When an e‑commerce platform must generate small preview images of vector logos stored in CDR format for product listings, this code can crop the logo to a 200×200 square and output a GIF.
 * 3. When a reporting tool requires embedding a fixed‑size graphic from a CorelDRAW source into PDF reports, the developer can use this snippet to crop the CDR to 200×200 pixels and convert it to a GIF.
 * 4. When a mobile app needs a lightweight animated or static icon derived from a CDR illustration, the code can crop the vector to a 200×200 area and save it as a GIF for fast loading.
 * 5. When a content management system must automatically generate consistent 200×200 preview thumbnails for uploaded CDR files, this C# example shows how to crop and convert the image to GIF format.
 */