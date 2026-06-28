using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Resize the image to 150x150 pixels
                image.Resize(150, 150, ResizeType.NearestNeighbourResample);

                // Prepare JPEG save options
                var jpegOptions = new JpegOptions();

                // Save the resized image as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to display preview thumbnails of uploaded EPS vector logos in a product catalog, the developer can use this code to convert each EPS to a 150 × 150 JPEG thumbnail.
 * 2. When an automated document processing pipeline must generate small preview images for EPS illustrations to embed in PDF reports, the code resizes the EPS and saves it as a JPEG thumbnail.
 * 3. When a content management system stores EPS artwork and wants to show quick visual cues in the UI, the developer can create 150 × 150 JPEG thumbnails using this snippet.
 * 4. When a batch job processes a folder of EPS files to create image assets for mobile apps, the code provides a fast way to produce 150 pixel square JPEG thumbnails for each file.
 * 5. When an e‑commerce platform receives EPS files from vendors and needs to display them on product listing pages, this code converts the EPS to a 150 × 150 JPEG thumbnail for fast loading.
 */