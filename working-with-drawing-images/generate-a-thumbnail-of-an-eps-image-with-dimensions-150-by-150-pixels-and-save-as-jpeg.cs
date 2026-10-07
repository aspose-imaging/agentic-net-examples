// HOW-TO: Create 150x150 JPEG Thumbnail from EPS Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/thumbnail.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = 150,
                    PageHeight = 150
                };
                jpegOptions.VectorRasterizationOptions = rasterOptions;

                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to display a small preview of a vector EPS logo on a web page, you can generate a 150 × 150 JPEG thumbnail using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform stores product artwork as EPS files but requires fast‑loading thumbnail images for catalog listings, this code creates the required JPEG previews.
 * 3. When a document management system must convert uploaded EPS drawings into uniform-sized JPEG thumbnails for search‑result thumbnails, the snippet provides a simple solution.
 * 4. When a desktop application needs to show a quick preview of a user's EPS file in a file‑picker dialog, the code rasterizes the vector to a 150 px square JPEG.
 * 5. When automating batch processing of EPS assets to generate consistent thumbnail sizes for a mobile app’s gallery, this C# routine produces the JPEG thumbnails efficiently.
 */
