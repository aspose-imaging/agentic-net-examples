using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\face_input.png";
            string outputPath = @"C:\Images\face_embossed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the 5x5 emboss convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                // Save the processed image
                raster.Save(outputPath);
            }

            // TODO: Run face detection on the embossed image
            // FaceDetectionAlgorithm.Detect(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to enhance the texture of PNG face photos before feeding them to a face detection algorithm to improve edge contrast.
 * 2. When building a security camera system that preprocesses JPEG snapshots with an Emboss5x5 convolution in C# to highlight facial features for more reliable detection.
 * 3. When creating a mobile app that automatically applies an emboss filter to user‑uploaded selfie images before running a .NET face recognition routine.
 * 4. When testing a machine‑learning face detection model and needs to compare detection accuracy on original versus embossed BMP images using Aspose.Imaging’s ConvolutionFilterOptions.
 * 5. When integrating a batch processing pipeline that loads images from a folder, applies the Emboss5x5 filter via raster.Filter, saves the results, and then passes the embossed files to a downstream face detection service.
 */