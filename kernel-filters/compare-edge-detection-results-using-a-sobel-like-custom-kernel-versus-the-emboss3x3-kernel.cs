using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string sobelOutputPath = "output\\sobel.png";
            string embossOutputPath = "output\\emboss.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(sobelOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(embossOutputPath));

            // Apply Sobel-like custom kernel
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(sobelKernel));

                // Save Sobel result as PNG
                Source sobelSource = new FileCreateSource(sobelOutputPath, false);
                PngOptions sobelOptions = new PngOptions { Source = sobelSource };
                raster.Save(sobelOutputPath, sobelOptions);
            }

            // Apply Emboss3x3 kernel
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save Emboss result as PNG
                Source embossSource = new FileCreateSource(embossOutputPath, false);
                PngOptions embossOptions = new PngOptions { Source = embossSource };
                raster.Save(embossOutputPath, embossOptions);
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
 * 1. When a developer wants to highlight edges in a PNG photograph for a computer‑vision preprocessing step, they can apply a Sobel‑like custom kernel using Aspose.Imaging’s ConvolutionFilterOptions.
 * 2. When a developer needs to create a stylized emboss effect on an input image for UI thumbnails, they can use the built‑in Emboss3x3 kernel and save the result as a PNG.
 * 3. When a developer must compare two edge‑detection techniques side‑by‑side to choose the best algorithm for a document‑scanning pipeline, they can run both Sobel and Emboss filters on the same source image and store the outputs in separate files.
 * 4. When a developer is building an automated test that verifies raster‑image filtering across different file formats, they can load a PNG, apply the Sobel kernel, then the Emboss3x3 kernel, and compare the saved PNG results.
 * 5. When a developer wants to integrate custom convolution kernels into a C# image‑processing service that processes uploaded PNG files, this code shows how to load the image, apply a Sobel matrix, apply Emboss3x3, and write the filtered images to an output folder.
 */