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
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output thumbnail path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_thumb.bmp");

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image, resize, and save as thumbnail
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to a fixed thumbnail size (e.g., 150x150 pixels)
                    image.Resize(150, 150, ResizeType.NearestNeighbourResample);

                    // Save using default BMP options
                    BmpOptions options = new BmpOptions();
                    image.Save(outputPath, options);
                }

                Console.WriteLine($"Thumbnail saved: {outputPath}");
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
 * 1. When building a web gallery that shows preview thumbnails of user‑uploaded BMP files, a developer can use this code to generate fixed‑size 150×150 BMP thumbnails for fast loading.
 * 2. When creating a desktop photo‑management application that needs to display small previews of high‑resolution BMP images in a list view, this snippet resizes each image and saves a thumbnail in the same format.
 * 3. When automating a batch‑processing pipeline that converts a folder of BMP scans into uniform thumbnail images for inclusion in PDF reports, the code provides a simple C# solution using Aspose.Imaging.
 * 4. When developing an e‑commerce platform that stores product drawings as BMP files and requires consistent thumbnail icons for catalog pages, the example shows how to generate and store those icons programmatically.
 * 5. When implementing a content‑management system that validates incoming BMP uploads and creates preview images for editors, this routine resizes the original files and saves the thumbnails to a designated output directory.
 */