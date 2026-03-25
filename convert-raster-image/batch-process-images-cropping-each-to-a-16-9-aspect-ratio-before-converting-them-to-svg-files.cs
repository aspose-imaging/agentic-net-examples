using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded list of input image files
        string[] inputFiles = {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.png",
            @"C:\Images\photo3.bmp"
        };

        foreach (var inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output SVG path (same folder, .svg extension)
            string outputPath = Path.ChangeExtension(inputPath, ".svg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image (raster or vector)
            using (Image image = Image.Load(inputPath))
            {
                // Cache data for raster images for better performance
                if (!image.IsCached)
                    image.CacheData();

                // Calculate crop rectangle to achieve 16:9 aspect ratio (centered)
                int width = image.Width;
                int height = image.Height;
                double targetRatio = 16.0 / 9.0;
                double currentRatio = (double)width / height;

                int cropX = 0, cropY = 0, cropWidth = width, cropHeight = height;

                if (currentRatio > targetRatio)
                {
                    // Image is too wide – reduce width
                    cropWidth = (int)(height * targetRatio);
                    cropX = (width - cropWidth) / 2;
                }
                else if (currentRatio < targetRatio)
                {
                    // Image is too tall – reduce height
                    cropHeight = (int)(width / targetRatio);
                    cropY = (height - cropHeight) / 2;
                }

                Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                image.Crop(cropRect);

                // Prepare SVG save options with proper page size
                SvgOptions svgOptions = new SvgOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the cropped image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}