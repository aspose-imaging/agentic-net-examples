using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "blurred.jpg";
        string outputPath = "restored.png";

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

            // Load the blurred JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Create a motion Wiener deconvolution filter
                // Parameters: length = 10, sigma = 1.0, angle = 90 degrees
                var deconvolutionFilter = new MotionWienerFilterOptions(10, 1.0, 90.0)
                {
                    // Optional: adjust brightness and SNR if needed
                    Brightness = 1.15,
                    Snr = 0.007
                };

                // Apply the filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, deconvolutionFilter);

                // Save the restored image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to automatically improve the quality of user‑uploaded blurred JPEG photos before displaying them, a developer can use this C# Aspose.Imaging deconvolution filter to restore the image and save it as a PNG for web‑friendly delivery.
 * 2. When a digital forensics tool must recover details from a motion‑blurred surveillance JPEG frame, a developer can apply the MotionWienerFilterOptions in C# to deblur the image and export the result as a lossless PNG for analysis.
 * 3. When an e‑commerce platform wants to enhance product images that were unintentionally blurred during batch processing, a developer can run this Aspose.Imaging code to perform deconvolution on the JPEG files and store the sharpened versions as PNG thumbnails.
 * 4. When a medical imaging system receives scanned JPEG slides with slight motion blur, a developer can employ the motion Wiener deconvolution filter in C# to restore diagnostic details and save the cleaned image as a PNG for archival purposes.
 * 5. When an automated photo‑restoration service processes large collections of legacy JPEG photographs, a developer can integrate this Aspose.Imaging C# routine to deblur each picture using deconvolution and output high‑quality PNG files for client download.
 */