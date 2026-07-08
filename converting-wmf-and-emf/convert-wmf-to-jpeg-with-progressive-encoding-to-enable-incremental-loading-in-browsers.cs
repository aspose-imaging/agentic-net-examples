using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.jpg";

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

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with progressive compression
                var jpegOptions = new JpegOptions
                {
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    Quality = 100,
                    // Set rasterization options so the vector WMF is rendered to raster JPEG
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

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
 * 1. When a web application must display legacy WMF vector graphics in browsers that only support raster images, a developer can use this code to convert the WMF files to progressive JPEGs for faster incremental loading.
 * 2. When optimizing a content management system that stores user‑uploaded WMF diagrams, the code enables automatic conversion to high‑quality progressive JPEGs so the images load progressively on slow connections.
 * 3. When building an e‑learning platform that embeds WMF illustrations in HTML pages, developers can employ this snippet to rasterize the vectors and save them as progressive JPEGs to improve perceived page load speed.
 * 4. When migrating a legacy desktop reporting tool to a web‑based interface, the code helps transform WMF charts into progressive JPEGs that browsers can render while the file is still downloading.
 * 5. When creating a batch processing service in C# that prepares marketing assets, this example shows how to convert multiple WMF logos to progressive JPEG format to ensure smooth, incremental display on product pages.
 */