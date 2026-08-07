using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\photo.png";
        string outputPath = "output\\denoised.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with sigma 0.8
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions()
                    {
                        Sigma = 0.8
                    });

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a developer needs to automatically reduce noise in low‑light PNG photos before uploading them to a web gallery, they can apply a Gaussian blur with sigma 0.8 using Aspose.Imaging for .NET.
 * 2. When building a desktop C# application that processes batches of user‑submitted images, the code can be used to denoise each PNG file by applying a Gaussian blur filter.
 * 3. When integrating image preprocessing into a machine‑learning pipeline, a developer can use this snippet to smooth low‑light PNG inputs and improve model accuracy.
 * 4. When creating a photo‑editing tool that offers a quick “noise reduction” button, the code demonstrates how to implement the feature with Aspose.Imaging’s RasterImage filter API.
 * 5. When preparing PNG screenshots captured in dim environments for documentation, a developer can run this routine to apply a subtle Gaussian blur and enhance visual clarity.
 */