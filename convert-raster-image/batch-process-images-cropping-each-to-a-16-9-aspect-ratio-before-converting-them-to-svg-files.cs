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
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each image file in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder))
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path with .svg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to perform cropping
                    RasterImage rasterImage = image as RasterImage;
                    if (rasterImage == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format for cropping: {inputPath}");
                        continue;
                    }

                    // Calculate crop rectangle to achieve 16:9 aspect ratio (centered)
                    int originalWidth = rasterImage.Width;
                    int originalHeight = rasterImage.Height;

                    // Desired width based on height
                    int targetWidth = (originalHeight * 16) / 9;
                    // Desired height based on width
                    int targetHeight = (originalWidth * 9) / 16;

                    int cropWidth, cropHeight;
                    if (targetWidth <= originalWidth)
                    {
                        // Height is the limiting factor
                        cropWidth = targetWidth;
                        cropHeight = originalHeight;
                    }
                    else
                    {
                        // Width is the limiting factor
                        cropWidth = originalWidth;
                        cropHeight = targetHeight;
                    }

                    // Center the crop rectangle
                    int left = (originalWidth - cropWidth) / 2;
                    int top = (originalHeight - cropHeight) / 2;
                    var cropArea = new Rectangle(left, top, cropWidth, cropHeight);

                    // Perform cropping
                    rasterImage.Crop(cropArea);

                    // Prepare SVG save options with rasterization settings
                    var vectorOptions = new SvgRasterizationOptions
                    {
                        PageSize = rasterImage.Size
                    };
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };

                    // Save as SVG
                    rasterImage.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}