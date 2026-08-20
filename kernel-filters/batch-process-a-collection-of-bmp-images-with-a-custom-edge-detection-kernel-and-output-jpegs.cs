// HOW-TO: Batch Convert BMP Images to JPEG with Custom Edge Detection in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories (relative paths)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path (same name with .jpg extension)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering
                    RasterImage raster = (RasterImage)image;

                    // Define a custom edge detection kernel (3x3)
                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Apply the convolution filter with the custom kernel
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                    // Save the processed image as JPEG
                    using (var jpegOptions = new JpegOptions())
                    {
                        raster.Save(outputPath, jpegOptions);
                    }
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
 * 1. When you need to automatically enhance a folder of scanned BMP photos by highlighting edges before archiving them as smaller JPEG files.
 * 2. When a web service must preprocess user‑uploaded BMP graphics to detect outlines and store them in JPEG format for faster delivery.
 * 3. When a desktop utility has to batch‑apply an edge‑detect filter to legacy BMP assets for use in a machine‑vision pipeline that expects JPEG input.
 * 4. When you want to convert a collection of BMP screenshots into JPEGs while emphasizing edges for documentation or presentation purposes.
 * 5. When an automated build script must transform BMP design mockups into edge‑enhanced JPEGs for inclusion in marketing materials.
 */
