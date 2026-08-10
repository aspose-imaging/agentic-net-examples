// HOW-TO: Apply Motion Blur Filter to Each Frame of an APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page (animated) PNG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access pages
                ApngImage apngImage = image as ApngImage;
                if (apngImage == null)
                {
                    Console.Error.WriteLine("The input file is not a valid APNG image.");
                    return;
                }

                // Iterate through each page/frame
                for (int i = 0; i < apngImage.PageCount; i++)
                {
                    // Retrieve the frame as a RasterImage
                    RasterImage frame = apngImage.Pages[i] as RasterImage;
                    if (frame == null)
                    {
                        Console.Error.WriteLine($"Page {i} is not a raster image.");
                        continue;
                    }

                    // Apply convolution filter using GetBlurMotion (size 5, angle 225)
                    frame.Filter(frame.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(5, 225)));

                    // Prepare output path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the filtered page as PNG
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    frame.Save(outputPath, pngOptions);
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
 * 1. When you need to add a directional motion blur effect to every frame of an animated PNG for a web animation.
 * 2. When you must process a multi‑page APNG and export each blurred frame as separate image files for further editing.
 * 3. When you want to programmatically enhance video‑like PNG sequences with a consistent blur angle and size in a C# backend.
 * 4. When you are building a batch image pipeline that applies the same convolution filter to all pages of an APNG before publishing.
 * 5. When you need to verify that an APNG’s individual frames can be accessed, filtered, and saved individually using Aspose.Imaging.
 */
