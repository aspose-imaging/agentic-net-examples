// HOW-TO: Check Image Dimensions Remain Same After Applying Convolution Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.RasterImage raster)
                {
                    int originalWidth = raster.Width;
                    int originalHeight = raster.Height;

                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                    if (raster.Width == originalWidth && raster.Height == originalHeight)
                    {
                        Console.WriteLine("Dimensions unchanged after filter.");
                    }
                    else
                    {
                        Console.WriteLine("Dimensions changed after filter.");
                    }

                    raster.Save(outputPath, new JpegOptions());
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When you need to apply an emboss convolution filter to a JPEG while ensuring the original width and height are preserved for downstream layout calculations.
 * 2. When validating that a raster image processed with Aspose.Imaging does not change dimensions before uploading to a content management system that expects fixed‑size assets.
 * 3. When creating a batch image processing pipeline that applies filters but must keep the original dimensions for consistent thumbnail generation.
 * 4. When debugging a custom image filter implementation and want to confirm that the filter operation does not unintentionally resize the image.
 * 5. When integrating Aspose.Imaging into a C# application that applies artistic effects but must maintain the original canvas size for UI overlay alignment.
 */
