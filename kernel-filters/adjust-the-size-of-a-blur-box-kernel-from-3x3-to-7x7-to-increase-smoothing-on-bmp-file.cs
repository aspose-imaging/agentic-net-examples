// HOW-TO: Increase BMP Smoothing By Applying 7x7 Blur Kernel In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.bmp";
            string outputPath = "Output\\blurred.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                double[,] kernel = new double[7, 7];
                double value = 1.0 / 49.0;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        kernel[i, j] = value;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, filterOptions);
                image.Save(outputPath);
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
 * 1. When you need to soften harsh edges in a BMP photograph for a printing workflow, you can use a 7×7 convolution blur with Aspose.Imaging in C#.
 * 2. When preparing BMP assets for a game’s background, applying a larger blur kernel reduces visual noise without changing the file format.
 * 3. When creating a pre‑processing step for OCR on scanned BMP documents, increasing the blur size helps eliminate speckles that hinder text recognition.
 * 4. When generating thumbnail previews of BMP images for a web gallery, a 7×7 blur can smooth details to achieve a consistent visual style.
 * 5. When integrating image smoothing into an automated C# batch job that processes BMP files, the convolution filter provides a simple way to enhance overall image quality.
 */
