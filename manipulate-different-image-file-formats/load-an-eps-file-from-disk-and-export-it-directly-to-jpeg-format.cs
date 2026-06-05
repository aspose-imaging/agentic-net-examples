using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\Result\sample.jpg";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG export options (default settings)
                var jpegOptions = new JpegOptions();

                // Save the image as JPEG
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
 * 1. When a desktop publishing application needs to generate preview thumbnails of vector EPS artwork for a file‑browser, a developer can load the EPS with Aspose.Imaging and save it as a JPEG.
 * 2. When an e‑commerce platform receives product logos in EPS format from vendors and must display them on web pages, the code can convert each EPS to a web‑friendly JPEG on the server.
 * 3. When a document‑management system archives scanned documents as EPS but requires quick visual indexing, a developer can use this snippet to render the EPS as JPEG thumbnails for search results.
 * 4. When a batch‑processing script runs nightly to prepare print‑ready assets, the code enables automatic conversion of a folder of EPS files to JPEGs for client review.
 * 5. When a REST API endpoint accepts an uploaded EPS file and needs to return a JPEG preview to the client, the developer can load the EPS with Aspose.Imaging and stream the JPEG output directly.
 */