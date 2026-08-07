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
            // Input URL and temporary local path
            string inputUrl = "http://example.com/sample.jpg";
            string tempInputPath = "temp_input.jpg";

            // Download the image from the URL to a temporary file
            using (var webClient = new System.Net.WebClient())
            {
                webClient.DownloadFile(inputUrl, tempInputPath);
            }

            // Verify the temporary file exists
            if (!File.Exists(tempInputPath))
            {
                Console.Error.WriteLine($"File not found: {tempInputPath}");
                return;
            }

            // Output path
            string outputPath = "output_embossed.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG options with bound output source
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 100 };

            // Load the image, apply Emboss5x5 filter, and save
            using (RasterImage rasterImage = (RasterImage)Image.Load(tempInputPath))
            {
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to download a JPEG image from a remote URL, apply the Emboss5x5 convolution filter, and save the enhanced picture locally for further processing.
 * 2. When building a .NET web application that automatically creates stylized product thumbnails by fetching images from external URLs, embossing them, and storing the high‑quality results in a CDN.
 * 3. When writing a batch image‑processing script that retrieves pictures from an API, adds depth with the Emboss5x5 filter, and outputs JPEG files ready for print catalogs.
 * 4. When integrating Aspose.Imaging into a Windows service that monitors a feed of image URLs, applies edge‑enhancement via the Emboss5x5 convolution, and archives the processed images for compliance.
 * 5. When developing a desktop utility that lets users enter an image URL, instantly preview an embossed version, and save the result with configurable JPEG quality using C# and Aspose.Imaging.
 */