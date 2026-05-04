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

            // Get all image files in the input folder (common raster formats)
            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Work only with raster images for cropping
                    if (image is RasterImage rasterImage)
                    {
                        int width = rasterImage.Width;
                        int height = rasterImage.Height;

                        // Desired aspect ratio 16:9
                        const int targetRatioWidth = 16;
                        const int targetRatioHeight = 9;

                        // Calculate target dimensions
                        int targetWidth = height * targetRatioWidth / targetRatioHeight;
                        int targetHeight = width * targetRatioHeight / targetRatioWidth;

                        Rectangle cropArea;

                        if (width > targetWidth)
                        {
                            // Crop horizontally: center the crop area
                            int cropX = (width - targetWidth) / 2;
                            cropArea = new Rectangle(cropX, 0, targetWidth, height);
                        }
                        else if (height > targetHeight)
                        {
                            // Crop vertically: center the crop area
                            int cropY = (height - targetHeight) / 2;
                            cropArea = new Rectangle(0, cropY, width, targetHeight);
                        }
                        else
                        {
                            // Image already matches or is smaller than the target ratio; no cropping needed
                            cropArea = new Rectangle(0, 0, width, height);
                        }

                        // Perform cropping
                        rasterImage.Crop(cropArea);
                    }

                    // Prepare output SVG path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set up SVG save options with rasterization settings
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    // Save the (cropped) image as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}