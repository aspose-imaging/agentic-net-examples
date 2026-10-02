// HOW-TO: Increase Brightness and Apply 5x5 Blur to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                double[,] customKernel = new double[,]
                {
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 },
                    { 0.05, 0.05, 0.05, 0.05, 0.05 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));

                BmpOptions options = new BmpOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to preprocess scanned BMP documents by softening details and slightly brightening them before OCR, you can use this code.
 * 2. When creating a thumbnail gallery where each BMP image should appear smoother and lighter, this approach quickly applies a 5x5 blur with increased brightness.
 * 3. When preparing BMP assets for a game UI and you want to reduce harsh edges while making the background appear more luminous, the convolution filter can be applied programmatically.
 * 4. When automating batch conversion of BMP photos to a uniform look for a marketing campaign, the custom kernel ensures consistent blur and brightness across all files.
 * 5. When integrating Aspose.Imaging into a C# service that adjusts image exposure and applies a gentle blur to BMP files uploaded by users, this snippet demonstrates the required steps.
 */
