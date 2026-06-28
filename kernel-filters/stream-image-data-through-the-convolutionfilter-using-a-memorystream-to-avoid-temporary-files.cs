using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
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

            byte[] inputBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(inputBytes))
            {
                using (Image image = Image.Load(inputStream))
                {
                    RasterImage raster = (RasterImage)image;

                    double[,] kernel = new double[,]
                    {
                        { 0, -1, 0 },
                        { -1, 5, -1 },
                        { 0, -1, 0 }
                    };
                    int factor = 1;
                    int bias = 0;
                    var filterOptions = new ConvolutionFilterOptions(kernel, factor, bias);

                    raster.Filter(raster.Bounds, filterOptions);

                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        raster.Save(outputStream, new PngOptions());
                        File.WriteAllBytes(outputPath, outputStream.ToArray());
                    }
                }
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
 * 1. When a web API receives a PNG upload and needs to apply a sharpening convolution filter in C# without creating temporary files, this MemoryStream‑based code processes the image entirely in memory.
 * 2. When a desktop application lets users drag‑and‑drop photos and wants to enhance edges using Aspose.Imaging’s ConvolutionFilterOptions before saving the result, the in‑memory raster filtering avoids disk I/O.
 * 3. When a background service reads image BLOBs from a database, applies a custom kernel to improve contrast, and writes the processed PNG back to storage, the MemoryStream workflow keeps the operation fast and file‑system independent.
 * 4. When a batch job processes scanned documents stored as PNG files, applies a sharpening filter to improve OCR accuracy, and streams the output directly to another service, this code eliminates the need for intermediate files.
 * 5. When an e‑commerce platform generates product thumbnails with edge enhancement on the fly, using C# and Aspose.Imaging’s ConvolutionFilter, the MemoryStream approach ensures low latency and no temporary image files on the server.
 */