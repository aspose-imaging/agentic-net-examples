// HOW-TO: Deconvolution Filter to Sharpen Blurred JPEG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int size = 3;
                double sigma = 1.0;

                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(size, sigma));

                image.Filter(image.Bounds, deconvOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to restore details in a JPEG photo that was blurred during capture and output a loss‑less PNG for further editing.
 * 2. When processing a batch of scanned documents where each JPEG suffers from motion blur and you must apply a deconvolution filter before archiving them as PNG files.
 * 3. When building a C# web service that receives blurred JPEG uploads, sharpens them using a Gaussian deconvolution filter, and returns high‑quality PNG thumbnails.
 * 4. When integrating image enhancement into a desktop application that corrects blurry JPEG screenshots and saves the corrected images in PNG format for reporting.
 * 5. When automating a workflow that converts low‑resolution, blurred JPEG assets into sharpened PNG assets for use in print‑ready graphics.
 */
