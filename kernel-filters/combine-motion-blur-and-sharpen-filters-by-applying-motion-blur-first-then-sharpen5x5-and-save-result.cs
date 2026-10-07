// HOW-TO: Apply Motion Blur Followed by Sharpen Filter to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

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
                var motionOptions = new MotionWienerFilterOptions(5, 1.0, 0.0);
                image.Filter(image.Bounds, motionOptions);

                var sharpenOptions = new ConvolutionFilterOptions(ConvolutionFilter.Sharpen5x5);
                image.Filter(image.Bounds, sharpenOptions);

                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to soften motion in a photo while preserving edge detail for a product catalog, you can apply a motion blur then a sharpen filter using Aspose.Imaging in C#.
 * 2. When preparing frames for a video game cutscene where motion streaks should appear smooth but still look crisp, this code adds motion blur followed by sharpening to the JPEG assets.
 * 3. When cleaning up scanned documents that contain slight camera shake, applying motion blur first and then a 5x5 sharpen restores readability before saving as JPEG.
 * 4. When creating artistic thumbnails that require a subtle motion effect without losing overall sharpness, the combined filters can be applied programmatically in a .NET application.
 * 5. When automating batch processing of wildlife photos to emphasize movement while keeping feathers or fur detailed, the code demonstrates how to chain filters and export the result as a JPEG file.
 */
