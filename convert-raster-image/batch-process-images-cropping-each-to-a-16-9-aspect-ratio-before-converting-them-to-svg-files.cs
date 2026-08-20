// HOW-TO: Batch Crop Images To 16:9 Aspect Ratio And Convert To SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of input image files to process
            string[] inputFiles = new[]
            {
                @"C:\Images\photo1.jpg",
                @"C:\Images\photo2.png",
                @"C:\Images\photo3.bmp"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image (supports raster formats)
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access width, height and cropping
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image type: {inputPath}");
                        continue;
                    }

                    int originalWidth = raster.Width;
                    int originalHeight = raster.Height;

                    // Desired 16:9 aspect ratio
                    const double targetRatio = 16.0 / 9.0;
                    double currentRatio = (double)originalWidth / originalHeight;

                    int cropX = 0, cropY = 0, cropWidth = originalWidth, cropHeight = originalHeight;

                    if (currentRatio > targetRatio)
                    {
                        // Image is too wide – crop width
                        cropWidth = (int)(originalHeight * targetRatio);
                        cropX = (originalWidth - cropWidth) / 2;
                    }
                    else if (currentRatio < targetRatio)
                    {
                        // Image is too tall – crop height
                        cropHeight = (int)(originalWidth / targetRatio);
                        cropY = (originalHeight - cropHeight) / 2;
                    }
                    // Define the cropping rectangle
                    var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                    raster.Crop(cropRect);

                    // Prepare output path – same folder, same name, .svg extension
                    string outputPath = Path.ChangeExtension(inputPath, ".svg");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set up SVG rasterization options (use the cropped size as page size)
                    var vectorOptions = new SvgRasterizationOptions
                    {
                        PageSize = raster.Size
                    };

                    // Configure SVG save options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        Compress = false // plain SVG
                    };

                    // Save the cropped image as SVG
                    raster.Save(outputPath, svgOptions);
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
 * 1. When you need to prepare a series of product photos for a web gallery that requires a uniform 16:9 view and scalable SVG output.
 * 2. When converting legacy raster assets such as JPG, PNG, or BMP into vector SVG files for responsive design while ensuring the correct aspect ratio.
 * 3. When automating thumbnail generation for a video platform where each thumbnail must be 16:9 and stored as SVG for lightweight rendering.
 * 4. When processing scanned documents to fit a widescreen layout and exporting them as SVG for further editing in vector graphics tools.
 * 5. When building a batch script to standardize marketing banners by cropping them to 16:9 and saving them as SVG to maintain quality at any resolution.
 */
